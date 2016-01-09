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
    public class KhoiLopController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IKhoiLopService _KhoiLopService;

        public KhoiLopController()
        {
            _KhoiLopService = new KhoiLopService(_UnitOfWork);
        }

        //
        // GET: /KhoiLop/
        public ActionResult Index()
        {
            return View();
        }

        //
        // View list deleted KhoiLop
        public ActionResult ViewDeleted()
        {
            return View();
        }

        /// <summary>
        /// Get list of KhoiLop
        /// </summary>
        /// <returns>List KhoiLop in Json</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                IEnumerable<KhoiLop> models = _KhoiLopService.GetAll();

                if (models == null)
                {
                    return Json(null);
                }

                models = models.OrderByDescending(m => m.MaKhoi);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Get list of inactive KhoiLop
        /// </summary>
        /// <returns>List inactive KhoiLop in Json</returns>
        [HttpPost]
        public JsonResult ReadInactive()
        {
            try
            {
                IEnumerable<KhoiLop> models = _KhoiLopService.GetAllInactive();

                if (models == null)
                {
                    return Json(null);
                }

                models = models.OrderByDescending(m => m.MaKhoi);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update KhoiLop to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var KhoiLops = JsonConvert.DeserializeObject<IEnumerable<KhoiLop>>(models);
                if (KhoiLops != null)
                {
                    foreach (KhoiLop KhoiLop in KhoiLops)
                    {
                        _KhoiLopService.Update(KhoiLop);
                    }
                }
                return Json(KhoiLops);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set KhoiLop to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Destroy(string models)
        {
            try
            {
                var khoiLops = JsonConvert.DeserializeObject<IEnumerable<KhoiLop>>(models);

                if (khoiLops != null)
                {
                    foreach (KhoiLop khoiLop in khoiLops)
                    {
                        _KhoiLopService.FakeDelete(khoiLop);
                    }
                }
                return Json(khoiLops);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Delete KhoiLop from database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RealDestroy(string models)
        {
            try
            {
                var khoiLops = JsonConvert.DeserializeObject<IEnumerable<KhoiLop>>(models);

                if (khoiLops != null)
                {
                    foreach (KhoiLop khoiLop in khoiLops)
                    {
                        _KhoiLopService.Delete(khoiLop);
                    }
                }
                return Json(khoiLops);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Add new KhoiLop in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string models)
        {
            try
            {
                var KhoiLops = JsonConvert.DeserializeObject<IEnumerable<KhoiLop>>(models);

                if (KhoiLops != null)
                {
                    foreach (KhoiLop KhoiLop in KhoiLops)
                    {         
                        _KhoiLopService.Insert(KhoiLop);
                    }
                }
                return Json(KhoiLops);
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