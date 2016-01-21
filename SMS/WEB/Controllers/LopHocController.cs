using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.DATA.Models;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using Newtonsoft.Json;

namespace WEB.Controllers
{
    [Authorize(Roles = "Admin, Hiệu Trưởng")]
    public class LopHocController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly ILopHocService _LopHocService;
        private readonly IKhoiLopService _KhoiLopService;
        private readonly IPhongHocService _PhongHocService;
        private readonly INamHocService _NamHocService;
        private readonly IHocSinhService _HocSinhService;

        public LopHocController()
        {
            _LopHocService = new LopHocService(_UnitOfWork);
            _KhoiLopService = new KhoiLopService(_UnitOfWork);
            _PhongHocService = new PhongHocService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
            _HocSinhService = new HocSinhService(_UnitOfWork);
        }

        //
        // GET: /LopHoc/
        public ActionResult Index()
        {
            ViewBag.listKhoiLop = JsonConvert.SerializeObject(_KhoiLopService.GetAll().Select(m => new { value = m.MaKhoi, text = m.TenKhoi }));
            ViewBag.listPhongHoc = JsonConvert.SerializeObject(_PhongHocService.GetAll().Select(m => new { value = m.MaPhong, text = m.TenPhong }));
            ViewBag.listNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll().Select(m => new { value = m.MaNamHoc, text = m.NamBatDau + " - " + m.NamKetThuc }));
            return View();
        }

        public ActionResult XepLop()
        {
            ViewBag.listKhoiLop = JsonConvert.SerializeObject(_KhoiLopService.GetAll().Select(m => new { value = m.MaKhoi, text = m.TenKhoi }));
            ViewBag.listLopHoc = JsonConvert.SerializeObject(_LopHocService.GetAll().Select(m => new { value = m.MaLopHoc, text = m.TenLop, MaNamHoc = m.MaNamHoc, MaKhoi = m.MaKhoi }));
            ViewBag.listNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll().Select(m => new { value = m.MaNamHoc, text = m.NamBatDau + " - " + m.NamKetThuc }));
            ViewBag.listPhongHoc = JsonConvert.SerializeObject(_PhongHocService.GetAll().Select(m => new { value = m.MaPhong, text = m.TenPhong }));
            return View();
        }

        #region Lop
        /// <summary>
        /// Get list of LopHoc
        /// </summary>
        /// <returns>List LopHoc in Json</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                IEnumerable<LopHoc> models = _LopHocService.GetAll();

                if (models == null)
                {
                    return Json(null);
                }

                models = models.OrderByDescending(m => m.MaLopHoc);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Get list of inactive LopHoc
        /// </summary>
        /// <returns>List inactive LopHoc in Json</returns>
        [HttpPost]
        public JsonResult ReadInactive()
        {
            try
            {
                IEnumerable<LopHoc> models = _LopHocService.GetAllInactive();

                if (models == null)
                {
                    return Json(null);
                }

                models = models.OrderByDescending(m => m.MaLopHoc);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update LopHoc to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var LopHocs = JsonConvert.DeserializeObject<IEnumerable<LopHoc>>(models);
                if (LopHocs != null)
                {
                    foreach (LopHoc LopHoc in LopHocs)
                    {
                        _LopHocService.Update(LopHoc);
                    }
                }
                return Json(LopHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set LopHoc to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Destroy(string models)
        {
            try
            {
                var lopHocs = JsonConvert.DeserializeObject<IEnumerable<LopHoc>>(models);

                if (lopHocs != null)
                {
                    foreach (LopHoc lopHoc in lopHocs)
                    {
                        _LopHocService.FakeDelete(lopHoc);
                    }
                }
                return Json(lopHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Delete LopHoc from database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RealDestroy(string models)
        {
            try
            {
                var lopHocs = JsonConvert.DeserializeObject<IEnumerable<LopHoc>>(models);

                if (lopHocs != null)
                {
                    foreach (LopHoc lopHoc in lopHocs)
                    {
                        _LopHocService.Delete(lopHoc);
                    }
                }
                return Json(lopHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Add new LopHoc in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string models)
        {
            try
            {
                var LopHocs = JsonConvert.DeserializeObject<IEnumerable<LopHoc>>(models);

                if (LopHocs != null)
                {
                    foreach (LopHoc LopHoc in LopHocs)
                    {
                        _LopHocService.Insert(LopHoc);
                    }
                }
                return Json(LopHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message});
            }
        }
        #endregion

        #region XepLop
        /// <summary>
        /// Get list of XepLop
        /// </summary>
        /// <returns>List XepLop in Json</returns>
        [HttpPost]
        public JsonResult ReadXepLop()
        {
            try
            {
                //IEnumerable<HocSinh> models = _HocSinhService.GetAllHocSinh().Where(m => (m.NgaySinh.Year - DateTime.Now.Year) > 11 && (m.NgaySinh.Year - DateTime.Now.Year) > 16);
                IEnumerable<HocSinh> models = _HocSinhService.GetAllWithChild();
                IEnumerable<NamHoc> namHocs = _NamHocService.GetAll();
                List<XepLopViewModel> xepLopViewModels = new List<XepLopViewModel>();
                if (models == null)
                {
                    return Json(null);
                }

                foreach (HocSinh hocSinh in models)
                {
                    foreach (NamHoc namHoc in namHocs)
                    {
                        //chi xep lop cho hoc sinh vao sau nam do
                        if (hocSinh.MaNamVaoTruong != null)
                        {
                            if (_NamHocService.GetByID((int)hocSinh.MaNamVaoTruong).NamBatDau >= namHoc.NamBatDau)
                            {
                                if (hocSinh.dsLopHoc.Where(m => m.MaNamHoc == namHoc.MaNamHoc).Count() > 0)
                                {
                                    foreach (LopHoc lopHoc in hocSinh.dsLopHoc)
                                    {
                                        xepLopViewModels.Add(new XepLopViewModel(hocSinh, lopHoc));
                                    }
                                }
                                else
                                {
                                    xepLopViewModels.Add(new XepLopViewModel(hocSinh, namHoc.MaNamHoc));
                                }
                            }
                        }
                    }
                }

                return Json(xepLopViewModels);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Base on XepLop to update LopHoc_HocSinh table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateXepLop(string models)
        {
            try
            {
                var xepLops = JsonConvert.DeserializeObject<IEnumerable<XepLopViewModel>>(models);
                if (xepLops != null)
                {
                    List<HocSinh> listHocSinh = new List<HocSinh>();
                    foreach (XepLopViewModel xeplop in xepLops)
                    {
                        //Chua xep lop truoc do
                        HocSinh temp = _HocSinhService.GetByIDWithChild(xeplop.PersonId);
                        if (temp.dsLopHoc.Where(m => m.MaNamHoc == xeplop.MaNamHoc).Count() == 0)
                        {
                            temp.dsLopHoc.Add(_LopHocService.GetByID(xeplop.MaLopHoc));
                            _HocSinhService.Update(temp);
                        }
                        else
                        {
                            LopHoc lopHoc = temp.dsLopHoc.Where(m => m.MaNamHoc == xeplop.MaNamHoc).FirstOrDefault();
                            temp.dsLopHoc.Remove(lopHoc);
                            if (xeplop.MaLopHoc != -1)
                            {
                                temp.dsLopHoc.Add(_LopHocService.GetByID(xeplop.MaLopHoc));
                            }
                            _HocSinhService.Update(temp);
                        }
                    }

                    //cap nhat si so
                    List<int> idLopChanged = xepLops.Select(m => m.MaLopHoc).Distinct().ToList();
                    foreach(int idLop in idLopChanged)
                    {
                        LopHoc lop = _LopHocService.GetByIDWithChild(idLop);
                        lop.SiSo = lop.dsHocSinh.Count;
                        _LopHocService.Update(lop);
                    }
                }
                return Json(xepLops);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Base on XepLop to delete data on LopHoc_HocSinh table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DestroyXepLop(string models)
        {
            try
            {
                var lopHocs = JsonConvert.DeserializeObject<IEnumerable<LopHoc>>(models);

                if (lopHocs != null)
                {
                    foreach (LopHoc lopHoc in lopHocs)
                    {
                        _LopHocService.FakeDelete(lopHoc);
                    }
                }
                return Json(lopHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }
        #endregion

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