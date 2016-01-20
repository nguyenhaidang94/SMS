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
                var viewModels = JsonConvert.DeserializeObject<IEnumerable<MonHocViewModel>>(models);
                if (viewModels != null)
                {
                    foreach (MonHocViewModel model in viewModels)
                    {
                        MonHoc monHoc = _MonHocService.GetByIDWithChild(model.MaMonHoc);
                        monHoc.HeSo = model.HeSo;
                        monHoc.SoTiet = model.SoTiet;
                        monHoc.TenMonHoc = model.TenMonHoc;
                        List<int> idAdd = model.KhoiLops.Select(m => m.value).ToList().Except(monHoc.dsKhoi.Select(m => m.MaKhoi).ToList()).ToList();
                        List<int> idDelete = monHoc.dsKhoi.Select(m => m.MaKhoi).ToList().Except(model.KhoiLops.Select(m => m.value).ToList()).ToList();
                        foreach (int id in idAdd)
                        {
                            monHoc.dsKhoi.Add(_KhoiLopService.GetByID(id));
                        }

                        foreach (int id in idDelete)
                        {
                            monHoc.dsKhoi.Remove(_KhoiLopService.GetByID(id));
                        }

                        _MonHocService.Update(monHoc);
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
        /// Set MonHoc to inactive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Destroy(string models)
        {
            try
            {
                var viewModels = JsonConvert.DeserializeObject<IEnumerable<MonHocViewModel>>(models);

                if (viewModels != null)
                {
                    foreach (MonHocViewModel monHoc in viewModels)
                    {
                        _MonHocService.FakeDelete(_MonHocService.GetByID(monHoc.MaMonHoc));
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
        /// Delete NamHoc from database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RealDestroy(string models)
        {
            try
            {
                var viewModels = JsonConvert.DeserializeObject<IEnumerable<MonHocViewModel>>(models);

                if (viewModels != null)
                {
                    foreach (MonHocViewModel monHoc in viewModels)
                    {
                        _MonHocService.Delete(_MonHocService.GetByID(monHoc.MaMonHoc));
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
        /// Add new MonHoc in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string models)
        {
            try
            {
                var viewModels = JsonConvert.DeserializeObject<IEnumerable<MonHocViewModel>>(models);
                if (viewModels != null)
                {
                    foreach (MonHocViewModel model in viewModels)
                    {
                        MonHoc monHoc = new MonHoc();
                        monHoc.HeSo = model.HeSo;
                        monHoc.SoTiet = model.SoTiet;
                        monHoc.TenMonHoc = model.TenMonHoc;
                        foreach (int id in model.KhoiLops.Select(m => m.value))
                        {
                            monHoc.dsKhoi.Add(_KhoiLopService.GetByID(id));
                        }

                        _MonHocService.Insert(monHoc);
                    }
                }
                return Json(viewModels);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message});
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