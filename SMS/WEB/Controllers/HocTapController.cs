using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using Newtonsoft.Json;
using SMS.DATA.Models;

namespace WEB.Controllers
{
    [Authorize(Roles = "Admin, Hiệu Trưởng")]
    public class HocTapController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IHocTapService _HocTapService;
        private readonly INamHocService _NamHocService;
        private readonly IHocKyService _HocKyService;
        private readonly IHocSinhService _HocSinhService;
        private readonly ILopHocService _LopHocService;
        private readonly IMonHocService _MonHocService;

        public HocTapController()
        {
            _HocTapService = new HocTapService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
            _HocKyService = new HocKyService(_UnitOfWork);
            _HocSinhService = new HocSinhService(_UnitOfWork);
            _LopHocService = new LopHocService(_UnitOfWork);
            _MonHocService = new MonHocService(_UnitOfWork);
        }

        //
        // GET: /BangDiem/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BangDiem/
        public ActionResult DanhSachBangDiem()
        {
            ViewBag.listNamHoc = _NamHocService.GetAll().Select(m => new { value = m.MaNamHoc, text = m.NamBatDau + " - " + m.NamKetThuc });
            ViewBag.listHocKy = _HocKyService.GetAll().Select(m => new { value = m.MaHocKy, text = m.TenHocKy });
            ViewBag.listLopHoc = JsonConvert.SerializeObject(_LopHocService.GetAll().Select(m => new { value = m.MaLopHoc, text = m.TenLop }));
            ViewBag.listMonHoc = JsonConvert.SerializeObject(_MonHocService.GetAll().Select(m => new { value = m.MaMonHoc, text = m.TenMonHoc }));
            return View();
        }

        /// <summary>
        /// Get list of PhongHoc
        /// </summary>
        /// <returns>List PhongHoc in Json</returns>
        [HttpPost]
        public JsonResult ReadBangDiem(int idNam, string idHocKy)
        {
            try
            {
                List<BangDiemViewModel> result = new List<BangDiemViewModel>();

                IEnumerable<BangDiemHKMH> listBangDiem = _HocTapService.GetAllBangDiem().Where(m => m.MaNamHoc == idNam && m.MaHocKy == idHocKy);
                IEnumerable<LopHoc> listLopHoc = _LopHocService.GetAllWithChild().Where(m => m.MaNamHoc == idNam);
                IEnumerable<MonHoc> listMonHoc = _MonHocService.GetAll();

                int countMaBangDiemGia = 1; //Mã giả cho các bảng điểm giả
                foreach (LopHoc lop in listLopHoc)
                {
                    foreach (HocSinh hs in lop.dsHocSinh)
                    {
                        foreach (MonHoc monHoc in listMonHoc)
                        {
                            //da có bảng điểm
                            if (listBangDiem.Where(m => m.MaHocSinh == hs.MaHocSinh && m.MaMonHoc == monHoc.MaMonHoc).Count() > 0)
                            {
                                result.Add(new BangDiemViewModel(listBangDiem.Where(m => m.MaHocSinh == hs.MaHocSinh &&
                                    m.MaMonHoc == monHoc.MaMonHoc).FirstOrDefault(), hs.HoTen, lop.MaLopHoc));
                            }
                            else    //chưa có tạo bảng giả
                            {
                                result.Add(new BangDiemViewModel(countMaBangDiemGia, hs.MaHocSinh, hs.HoTen, monHoc.MaMonHoc, lop.MaLopHoc));
                                countMaBangDiemGia++;
                            }
                        }
                    }
                }

                return Json(result);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update PhongHoc to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateBangDiem(string models, int idNam, string idHocKy)
        {
            try
            {
                var viewModels = JsonConvert.DeserializeObject<IEnumerable<BangDiemViewModel>>(models);

                foreach (BangDiemViewModel model in viewModels)
                {
                    //normal case, BangDiem already exist
                    if (model.MaBangDiem > 0)
                    {
                        BangDiemHKMH bangDiem =_HocTapService.GetBangDiemByID(model.MaBangDiem);
                        bangDiem.DiemTB = (float)model.DiemTrungBinh;
                        //Mieng 1
                        if (model.MaDiemMieng_1 != -1)
                        {
                            if (model.DiemMieng_1 != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiemMieng_1);
                                cotDiem.GiaTri = (float)model.DiemMieng_1;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiemMieng_1);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiemMieng_1 == -1 && model.DiemMieng_1 != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.DiemMieng_1;
                                cotDiem.MaLoaiDiem = 1; //hard code, 1 is Mieng
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }

                        //Mieng 2
                        if (model.MaDiemMieng_2 != -1)
                        {
                            if (model.DiemMieng_2 != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiemMieng_2);
                                cotDiem.GiaTri = (float)model.DiemMieng_2;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiemMieng_2);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiemMieng_2 == -1 && model.DiemMieng_2 != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.DiemMieng_2;
                                cotDiem.MaLoaiDiem = 1; //hard code, 1 is Mieng
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }

                        //15' 1
                        if (model.MaDiem15_1 != -1)
                        {
                            if (model.Diem15_1 != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem15_1);
                                cotDiem.GiaTri = (float)model.Diem15_1;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem15_1);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiem15_1 == -1 && model.Diem15_1 != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.Diem15_1;
                                cotDiem.MaLoaiDiem = 2; //hard code, 2 is 15'
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }

                        //15' 2
                        if (model.MaDiem15_2 != -1)
                        {
                            if (model.Diem15_2 != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem15_2);
                                cotDiem.GiaTri = (float)model.Diem15_2;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem15_2);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiem15_2 == -1 && model.Diem15_2 != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.Diem15_2;
                                cotDiem.MaLoaiDiem = 2; //hard code, 2 is 15'
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }

                        //1 Tiet 1
                        if (model.MaDiem1T_1 != -1)
                        {
                            if (model.Diem1T_1 != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem1T_1);
                                cotDiem.GiaTri = (float)model.Diem1T_1;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem1T_1);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiem1T_1 == -1 && model.Diem1T_1 != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.Diem1T_1;
                                cotDiem.MaLoaiDiem = 3; //hard code, 3 is 1 tiet
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }

                        //1 Tiet 2
                        if (model.MaDiem1T_2 != -1)
                        {
                            if (model.Diem1T_2 != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem1T_2);
                                cotDiem.GiaTri = (float)model.Diem1T_2;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiem1T_2);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiem1T_2 == -1 && model.Diem1T_2 != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.Diem1T_2;
                                cotDiem.MaLoaiDiem = 3; //hard code, 3 is 1 tiet
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }

                        //Hoc ky
                        if (model.MaDiemHK != -1)
                        {
                            if (model.DiemHK != null)
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiemHK);
                                cotDiem.GiaTri = (float)model.DiemHK;
                                _HocTapService.UpdateCotDiem(cotDiem);
                            }
                            else
                            {
                                CotDiem cotDiem = _HocTapService.GetCotDiemByID(model.MaDiemHK);
                                _HocTapService.DeleteCotDiem(cotDiem);
                            }
                        }
                        else
                        {
                            if (model.MaDiemHK == -1 && model.DiemHK != null)
                            {
                                CotDiem cotDiem = new CotDiem();
                                cotDiem.GiaTri = (float)model.DiemHK;
                                cotDiem.MaLoaiDiem = 4; //hard code, 4 is hk
                                cotDiem.TenCotDiem = "cot diem";
                                _HocTapService.InsertCotDiem(cotDiem);
                            }
                        }
                    }
                    else    //bang diem moi
                    {
                        BangDiemHKMH bangDiem = new BangDiemHKMH();
                        bangDiem.MaHocKy = idHocKy;
                        bangDiem.MaHocSinh = model.MaHocSinh;
                        bangDiem.MaMonHoc = model.MaMonHoc;
                        bangDiem.MaNamHoc = idNam;
                        bangDiem.DiemTB = (float)model.DiemTrungBinh;
                        List<CotDiem> temps = new List<CotDiem>();
                        //mieng 1
                        if(model.DiemMieng_1 != null)
                        { 
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.DiemMieng_1,
                                MaLoaiDiem = 1, //hard code, 1 is mieng
                                TenCotDiem = "cot diem",
                            });
                        }

                        //1 tiet 1
                        if (model.DiemMieng_2 != null)
                        {
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.DiemMieng_2,
                                MaLoaiDiem = 1, //hard code, 1 is mieng
                                TenCotDiem = "cot diem",
                            });
                        }

                        //15' 1
                        if (model.Diem15_1 != null)
                        {
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.Diem15_1,
                                MaLoaiDiem = 2, //hard code, 2 is 15'
                                TenCotDiem = "cot diem",
                            });
                        }

                        //15' 2
                        if (model.Diem15_2 != null)
                        {
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.Diem15_2,
                                MaLoaiDiem = 2, //hard code, 2 is 15'
                                TenCotDiem = "cot diem",
                            });
                        }

                        //1 tiet 1
                        if (model.Diem1T_1 != null)
                        {
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.Diem1T_1,
                                MaLoaiDiem = 3, //hard code, 4 is hk
                                TenCotDiem = "cot diem",
                            });
                        }

                        //1 tiet 2
                        if (model.Diem1T_2 != null)
                        {
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.Diem1T_2,
                                MaLoaiDiem = 3, //hard code, 3 is 1 tiet
                                TenCotDiem = "cot diem",
                            });
                        }

                        //hk
                        if (model.DiemHK != null)
                        {
                            temps.Add(new CotDiem()
                            {
                                GiaTri = (float)model.DiemHK,
                                MaLoaiDiem = 4, //hard code, 3 is 1 tiet
                                TenCotDiem = "cot diem",
                            });
                        }
                    }
                }
                return Json(viewModels);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set PhongHoc to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DestroyBangDiem(string models)
        {
            try
            {
                var phongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);

                if (phongHocs != null)
                {
                    foreach (PhongHoc phongHoc in phongHocs)
                    {
                        //_PhongHocService.FakeDelete(phongHoc);
                    }
                }
                return Json(phongHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Delete NamHoc from database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RealDestroyBangDiem(string models)
        {
            try
            {
                var phongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);

                if (phongHocs != null)
                {
                    foreach (PhongHoc phongHoc in phongHocs)
                    {
                        //_PhongHocService.Delete(phongHoc);
                    }
                }
                return Json(phongHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Add new PhongHoc in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateBangDiem(string models)
        {
            try
            {
                var PhongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);

                if (PhongHocs != null)
                {
                    foreach (PhongHoc PhongHoc in PhongHocs)
                    {
                        //_PhongHocService.Insert(PhongHoc);
                    }
                }
                return Json(PhongHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// override function Dispose
        /// Dispose _UnitOfWork
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            _UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}