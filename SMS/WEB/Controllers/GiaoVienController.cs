using Newtonsoft.Json;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class GiaoVienController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IGiaoVienService _GiaoVienService;

        public GiaoVienController()
        {
            _GiaoVienService = new GiaoVienService(_UnitOfWork);
        }

        /// <summary>
        /// return view QuanLyGiaoVien
        /// </summary>
        /// <returns>QuanLyGiaoVien.cshtml</returns>
        public ActionResult QuanLyGiaoVien()
        {
            ViewBag.dsGiaoVien = JsonConvert.SerializeObject(_GiaoVienService.GetAllGiaoVien());

            return View();
        }

        /// <summary>
        /// get all Giao Vien
        /// </summary>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                var dsGiaoVien = _GiaoVienService.GetAllGiaoVien();
                if (dsGiaoVien == null)
                {
                    return Json(null);
                }
                return Json(dsGiaoVien);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }


        /// <summary>
        /// create ho so giao vien
        /// </summary>
        /// <param name="models">json data</param>
        [HttpPost]
        public JsonResult Create(string models)
        {
            try
            {
                var dsGiaoVien = JsonConvert.DeserializeObject<IEnumerable<GiaoVien>>(models);

                if (dsGiaoVien != null)
                {
                   _GiaoVienService.AddDsGiaoVien(dsGiaoVien);
                }
                return Json(dsGiaoVien);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// update ho so giao vien
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var dsGiaoVien = JsonConvert.DeserializeObject<IEnumerable<GiaoVien>>(models);
                if (dsGiaoVien != null)
                {
                    _GiaoVienService.UpdateDsGiaoVien(dsGiaoVien);
                }
                return Json(dsGiaoVien);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }

        /// <summary>
        /// delete giao vien
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                var dsGiaoVien = JsonConvert.DeserializeObject<IEnumerable<GiaoVien>>(models);
                if (dsGiaoVien != null)
                {
                    _GiaoVienService.DeleteDsGiaoVien(dsGiaoVien);
                }
                return Json(dsGiaoVien);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
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