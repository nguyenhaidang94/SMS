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

namespace WEB.Controllers
{
    public class LopHocController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly ILopHocService _LopHocService;
        private readonly IKhoiLopService _KhoiLopService;
        private readonly IPhongHocService _PhongHocService;
        private readonly INamHocService _NamHocService;

        public LopHocController()
        {
            _LopHocService = new LopHocService(_UnitOfWork);
            _KhoiLopService = new KhoiLopService(_UnitOfWork);
            _PhongHocService = new PhongHocService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
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
                        //LopHoc.MaLopHoc = "NH" + LopHoc.NamBatDau.ToString().Substring(2) + "-" + LopHoc.NamKetThuc.ToString().Substring(2);
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