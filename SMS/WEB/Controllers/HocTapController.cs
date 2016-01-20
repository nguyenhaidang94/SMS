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
        public JsonResult UpdateBangDiem(string models)
        {
            try
            {
                var PhongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);
                if (PhongHocs != null)
                {
                    foreach (PhongHoc PhongHoc in PhongHocs)
                    {
                        //_PhongHocService.Update(PhongHoc);
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