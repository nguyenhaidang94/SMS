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
    [Authorize(Roles = "Admin, Hiệu Trưởng")]
    public class NamHocController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly INamHocService _NamHocService;
        private readonly IHocKyNamHocService _HocKyNamHocService;
        private readonly IHocKyService _HocKyService;

        public NamHocController()
        {
            _NamHocService = new NamHocService(_UnitOfWork);
            _HocKyNamHocService = new HocKyNamHocService(_UnitOfWork);
            _HocKyService = new HocKyService(_UnitOfWork);
        }

        //
        // GET: /NamHoc/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get list of NamHoc
        /// </summary>
        /// <returns>List NamHoc in Json</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                IEnumerable<NamHoc> models = _NamHocService.GetAll();

                if (models == null)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

                models = models.OrderByDescending(m => m.MaNamHoc);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Get list of inactive NamHoc
        /// </summary>
        /// <returns>List inactive NamHoc in Json</returns>
        [HttpPost]
        public JsonResult ReadInactive()
        {
            try
            {
                IEnumerable<NamHoc> models = _NamHocService.GetAllInactive();

                if (models == null)
                {
                    return Json(null);
                }

                models = models.OrderByDescending(m => m.MaNamHoc);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update NamHoc to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var namhocs = JsonConvert.DeserializeObject<IEnumerable<NamHoc>>(models);
                if (namhocs != null)
                {
                    foreach (NamHoc namhoc in namhocs)
                    {
                        _NamHocService.Update(namhoc);
                    }
                }
                return Json(namhocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set NamHoc to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Destroy(string models)
        {
            try
            {
                var namhocs = JsonConvert.DeserializeObject<IEnumerable<NamHoc>>(models);

                if (namhocs != null)
                {
                    foreach (NamHoc namhoc in namhocs)
                    {
                        _NamHocService.FakeDelete(namhoc);
                    }
                }
                return Json(namhocs);
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
        public ActionResult RealDestroy(string models)
        {
            try
            {
                var namhocs = JsonConvert.DeserializeObject<IEnumerable<NamHoc>>(models);

                if (namhocs != null)
                {
                    foreach (NamHoc namhoc in namhocs)
                    {
                        _NamHocService.Delete(namhoc);
                    }
                }
                return Json(namhocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Add new NamHoc in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string models)
        {
            try
            {
                var namhocs = JsonConvert.DeserializeObject<IEnumerable<NamHoc>>(models);

                if (namhocs != null)
                {
                    foreach (NamHoc namhoc in namhocs)
                    {
                        _NamHocService.Insert(namhoc);
                        foreach(HocKy hocKy in _HocKyService.GetAll())
                        {
                            HocKyNamHoc hocKyNamHoc = new HocKyNamHoc();
                            hocKyNamHoc.MaHocKy = hocKy.MaHocKy;
                            hocKyNamHoc.MaNamHoc = namhoc.MaNamHoc;
                            _HocKyNamHocService.Insert(hocKyNamHoc);
                        }
                    }
                }
                return Json(namhocs);
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