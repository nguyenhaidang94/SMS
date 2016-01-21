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
    public class HocSinhController :Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IHocSinhService _HocSinhService;
        private readonly INamHocService _NamHocService;

        public HocSinhController()
        {
            _HocSinhService = new HocSinhService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
        }

        /// <summary>
        /// return view QuanLyHoSoHocSinh
        /// </summary>
        /// <returns>QuanLyHocSinh.cshtml</returns>
        public ActionResult QuanLyHocSinh()
        {
            ViewBag.listNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll().Select(m => new { text = m.NamBatDau + " - " + m.NamKetThuc, value = m.MaNamHoc}));

            return View();
        }

        /// <summary>
        /// get all hoc sinh
        /// </summary>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                var dsHocSinh = _HocSinhService.GetAll();
                if (dsHocSinh == null)
                {
                    return Json(null);
                }
                return Json(dsHocSinh);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }

        /// <summary>
        /// create ho so hoc sinh
        /// </summary>
        /// <param name="models">json data</param>
        [HttpPost]
        public JsonResult Create(string models)
        {
            try
            {
                var dshocsinh = JsonConvert.DeserializeObject<IEnumerable<HocSinh>>(models);
                if (dshocsinh != null)
                {
                    _HocSinhService.Insert(dshocsinh);
                }
                return Json(dshocsinh);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message});
            }
        }

        /// <summary>
        /// update ho so hoc sinh
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var dsHocSinh = JsonConvert.DeserializeObject<IEnumerable<HocSinh>>(models);
                if (dsHocSinh != null)
                {
                    _HocSinhService.Update(dsHocSinh);
                }
                return Json(dsHocSinh);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }

        /// <summary>
        /// delete hoc sinh
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                var dsHocSinh = JsonConvert.DeserializeObject<IEnumerable<HocSinh>>(models);
                if (dsHocSinh != null)
                {
                    _HocSinhService.Delete(dsHocSinh);
                }
                return Json(dsHocSinh);
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