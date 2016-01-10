using SMS.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using SMS.CORE.Data;
using Newtonsoft.Json;
using System.Web;
using System.IO;

namespace WEB.Controllers
{
    /// <summary>
    /// controller quyetdinh khenthuong
    /// </summary>
    public class QDKhenThuongController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IQDKhenThuongService _QDKhenThuongService;
        private readonly INamHocService _NamHocService;
        private readonly ICTQDKhenThuongService _CTKhenThuongService;

        public QDKhenThuongController()
        {
            _QDKhenThuongService = new QDKhenThuongService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
            _CTKhenThuongService = new CTQDKhenThuongService(_UnitOfWork);

        }

        /// <summary>
        /// view quan ly qdkhenthuong
        /// </summary>
        /// <returns>view</returns>
        public ActionResult QuanLyQDKhenThuong()
        {
            ViewBag.dsNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll()
                .Select(e => new { value = e.MaNamHoc, text = e.NamBatDau + "-" + e.NamKetThuc }));
            return View();
        }

        /// <summary>
        /// create ds qdkhenthuong
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Create(string models)
        {
            try
            {
                var dsqdkhenthuong = JsonConvert.DeserializeObject<IEnumerable<QuyetDinhKhenThuong>>(models);

                if (dsqdkhenthuong != null)
                {
                    _QDKhenThuongService.AddDsQDKhenThuong(dsqdkhenthuong);
                }
                return Json(dsqdkhenthuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                var dsQdKhenThuong = _QDKhenThuongService.GetAllQDKhenThuong();
                if (dsQdKhenThuong == null)
                {
                    return Json(null);
                }
                return Json(dsQdKhenThuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// update ds qdkhenthuong
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var dsqdkhenthuong = JsonConvert.DeserializeObject<IEnumerable<QuyetDinhKhenThuong>>(models);

                if (dsqdkhenthuong != null)
                {
                    _QDKhenThuongService.UpdateDsQDKhenThuong(dsqdkhenthuong);
                }
                return Json(dsqdkhenthuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// delete ds qdkhenhthuong
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                var dsqdkhenthuong = JsonConvert.DeserializeObject<IEnumerable<QuyetDinhKhenThuong>>(models);

                if (dsqdkhenthuong != null)
                {
                    _QDKhenThuongService.DeleteDsQdKhenThuong(dsqdkhenthuong);
                }
                return Json(dsqdkhenthuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// view ctqd khenthuong
        /// </summary>
        /// <returns>view</returns>
        public ActionResult CTQDKhenThuong(int? maquyetdinh)
        {
            return View();
        }

        /// <summary>
        /// create ds ctkhenthuong
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult CreateCTKhenThuong(string models)
        {
            try
            {
                var dsctkhenthuong = JsonConvert.DeserializeObject<IEnumerable<CT_QuyetDinhKhenThuong>>(models);

                if (dsctkhenthuong != null)
                {
                    _CTKhenThuongService.AddDsCTQDKhenThuong(dsctkhenthuong);
                }
                return Json(dsctkhenthuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// get all ctkhenthuong
        /// </summary>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult ReadCTKhenThuong()
        {
            try
            {
                var dsCTKhenThuong = _CTKhenThuongService.GetAllCTQDKhenThuong();
                if (dsCTKhenThuong == null)
                {
                    return Json(null);
                }
                return Json(dsCTKhenThuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// update ds ctkhenthuong
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult UpdateCTKhenThuong(string models)
        {
            try
            {
                var dsCTKhenThuong = JsonConvert.DeserializeObject<IEnumerable<CT_QuyetDinhKhenThuong>>(models);

                if (dsCTKhenThuong != null)
                {
                    _CTKhenThuongService.UpdateDsCTQDKhenThuong(dsCTKhenThuong);
                }
                return Json(dsCTKhenThuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// delete ds ctkhenthuong
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult DeleteCTKhenThuong(string models)
        {
            try
            {
                var dsCTKhenThuong = JsonConvert.DeserializeObject<IEnumerable<CT_QuyetDinhKhenThuong>>(models);

                if (dsCTKhenThuong != null)
                {
                    _CTKhenThuongService.DeleteDsCTQDKhenThuong(dsCTKhenThuong);
                }
                return Json(dsCTKhenThuong);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }
    }
}