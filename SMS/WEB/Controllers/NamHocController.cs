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
    public class NamHocController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly INamHocService _NamHocService;

        public NamHocController()
        {
            _NamHocService = new NamHocService(_UnitOfWork);
        }

        //
        // GET: /NamHoc/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            IEnumerable<NamHoc> models = _NamHocService.GetAllNamHoc();

            if (models == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            models = models.OrderByDescending(m => m.MaNamHoc);

            return Json(models);
        }

        [HttpPost]
        public JsonResult Update(string models)
        {
            var namhocs = JsonConvert.DeserializeObject<IEnumerable<NamHoc>>(models);
            if (namhocs != null)
            {
                foreach (NamHoc namhoc in namhocs)
                {
                    _NamHocService.UpdateNamHoc(namhoc);
                }
            }
            return Json(namhocs);
        }

        [HttpPost]
        public ActionResult Destroy(string models)
        {
            var namhocs = JsonConvert.DeserializeObject<IEnumerable<NamHoc>>(models);

            if (namhocs != null)
            {
                foreach (NamHoc namhoc in namhocs)
                {
                    _NamHocService.DeleteNamHoc(namhoc);
                }
            }
            return Json(namhocs);
        }

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
                        namhoc.MaNamHoc = "NH" + namhoc.NamBatDau.ToString().Substring(2) + "-" + namhoc.NamKetThuc.ToString().Substring(2);
                        _NamHocService.AddNamHoc(namhoc);
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