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
    public class PhongHocController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IPhongHocService _PhongHocService;

        public PhongHocController()
        {
            _PhongHocService = new PhongHocService(_UnitOfWork);
        }

        //
        // GET: /PhongHoc/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get list of PhongHoc
        /// </summary>
        /// <returns>List PhongHoc in Json</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                IEnumerable<PhongHoc> models = _PhongHocService.GetAll();

                if (models == null)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

                models = models.OrderByDescending(m => m.MaPhong);

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Get list of inactive PhongHoc
        /// </summary>
        /// <returns>List inactive PhongHoc in Json</returns>
        [HttpPost]
        public JsonResult ReadInactive()
        {
            try
            {
                IEnumerable<PhongHoc> models = _PhongHocService.GetAllInactive();

                if (models == null)
                {
                    return Json(null);
                }

                models = models.OrderByDescending(m => m.MaPhong);

                return Json(models);
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
        public JsonResult Update(string models)
        {
            try
            {
                var PhongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);
                if (PhongHocs != null)
                {
                    foreach (PhongHoc PhongHoc in PhongHocs)
                    {
                        _PhongHocService.Update(PhongHoc);
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
        public ActionResult Destroy(string models)
        {
            try
            {
                var phongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);

                if (phongHocs != null)
                {
                    foreach (PhongHoc phongHoc in phongHocs)
                    {
                        _PhongHocService.FakeDelete(phongHoc);
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
        public ActionResult RealDestroy(string models)
        {
            try
            {
                var phongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);

                if (phongHocs != null)
                {
                    foreach (PhongHoc phongHoc in phongHocs)
                    {
                        _PhongHocService.Delete(phongHoc);
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
        public ActionResult Create(string models)
        {
            try
            {
                var PhongHocs = JsonConvert.DeserializeObject<IEnumerable<PhongHoc>>(models);

                if (PhongHocs != null)
                {
                    foreach (PhongHoc PhongHoc in PhongHocs)
                    {
                        _PhongHocService.Insert(PhongHoc);
                    }
                }
                return Json(PhongHocs);
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