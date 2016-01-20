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
    public class MonHocController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IMonHocService _MonHocService;
        private readonly IMonHocKhoiService _MonHocKhoiService;
        private readonly IKhoiLopService _KhoiLopService;

        public MonHocController()
        {
            _MonHocService = new MonHocService(_UnitOfWork);
            _MonHocKhoiService = new MonHocKhoiService(_UnitOfWork);
            _KhoiLopService = new KhoiLopService(_UnitOfWork);
        }

        #region MonHoc
        //
        // GET: /MonHoc/
        public ActionResult Index()
        {
            ViewBag.listKhoiLop = JsonConvert.SerializeObject(_KhoiLopService.GetAll().Select(m => new { value = m.MaKhoi, text = m.TenKhoi }));
            return View();
        }

        /// <summary>
        /// Get list of MonHoc
        /// </summary>
        /// <returns>List MonHoc in Json</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                List<MonHocViewModel> models = new List<MonHocViewModel>();
                IEnumerable<MonHoc> monHocs = _MonHocService.GetAllWithChild();

                if (monHocs == null)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

                foreach (MonHoc monHoc in monHocs)
                {
                    models.Add(new MonHocViewModel(monHoc));
                }

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Get list of inactive MonHoc
        /// </summary>
        /// <returns>List inactive MonHoc in Json</returns>
        [HttpPost]
        public JsonResult ReadInactive()
        {
            try
            {
                IEnumerable<MonHoc> models = _MonHocService.GetAllInactive();

                if (models == null)
                {
                    return Json(null);
                }

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update MonHoc to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var monHocs = JsonConvert.DeserializeObject<IEnumerable<MonHoc>>(models);
                if (monHocs != null)
                {
                    foreach (MonHoc monHoc in monHocs)
                    {
                        _MonHocService.Update(monHoc);
                    }
                }
                return Json(monHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set MonHoc to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Destroy(string models)
        {
            try
            {
                var monHocs = JsonConvert.DeserializeObject<IEnumerable<MonHoc>>(models);

                if (monHocs != null)
                {
                    foreach (MonHoc monHoc in monHocs)
                    {
                        _MonHocService.FakeDelete(monHoc);
                    }
                }
                return Json(monHocs);
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
                var monHocs = JsonConvert.DeserializeObject<IEnumerable<MonHoc>>(models);

                if (monHocs != null)
                {
                    foreach (MonHoc monHoc in monHocs)
                    {
                        _MonHocService.Delete(monHoc);
                    }
                }
                return Json(monHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Add new MonHoc in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string models)
        {
            try
            {
                var monHocs = JsonConvert.DeserializeObject<IEnumerable<MonHoc>>(models);

                if (monHocs != null)
                {
                    foreach (MonHoc monHoc in monHocs)
                    {
                        _MonHocService.Insert(monHoc);
                    }
                }
                return Json(monHocs);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message});
            }
        }
        #endregion

        #region MonHocKhoi
        /// <summary>
        /// Get list of relationship of MonHoc and Khoi
        /// </summary>
        /// <returns>List MonHocKhoi in Json</returns>
        [HttpPost]
        public JsonResult ReadMonHocKhoi()
        {
            try
            {
                IEnumerable<MonHocKhoi> models = _MonHocKhoiService.GetAll();

                if (models == null)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

                return Json(models);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Update MonHocKhoi to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateMonHocKhoi(string models)
        {
            try
            {
                var monHocKhois = JsonConvert.DeserializeObject<IEnumerable<MonHocKhoi>>(models);
                if (monHocKhois != null)
                {
                    foreach (MonHocKhoi monHocKhoi in monHocKhois)
                    {
                        _MonHocKhoiService.Update(monHocKhoi);
                    }
                }
                return Json(monHocKhois);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Set MonHocKhoi to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DestroyMonHocKhoi(string models)
        {
            var monHocKhois = JsonConvert.DeserializeObject<IEnumerable<MonHocKhoi>>(models);
            if (monHocKhois != null)
            {
                foreach (MonHocKhoi monHocKhoi in monHocKhois)
                {
                    _MonHocKhoiService.Delete(monHocKhoi);
                }
            }
            return Json(monHocKhois);
        }

        /// <summary>
        /// Add new MonHocKhoi in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateMonHocKhoi(string models)
        {
            try
            {
                var monHocKhois = JsonConvert.DeserializeObject<IEnumerable<MonHocKhoi>>(models);

                if (monHocKhois != null)
                {
                    foreach (MonHocKhoi monHocKhoi in monHocKhois)
                    {
                        _MonHocKhoiService.Insert(monHocKhoi);
                    }
                }
                return Json(monHocKhois);
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