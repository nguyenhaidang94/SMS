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
using WEB.Models;
using System.Text;
using SMS.CORE;
using SMS.DATA.Models;

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
        private readonly ILopHocService _LopHocService;

        public QDKhenThuongController()
        {
            _QDKhenThuongService = new QDKhenThuongService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
            _CTKhenThuongService = new CTQDKhenThuongService(_UnitOfWork);
            _LopHocService = new LopHocService(_UnitOfWork);
        }

        /// <summary>
        /// view quan ly qdkhenthuong
        /// </summary>
        /// <returns>view</returns>
        public ActionResult QuanLyQDKhenThuong()
        {
            ViewBag.dsNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll()
                .Select(e => new { value = e.MaNamHoc, text = e.NamBatDau + "-" + e.NamKetThuc }));
            ViewBag.dsLopHoc = JsonConvert.SerializeObject(_LopHocService.GetAll()
                .Select(e => new { value = e.MaLopHoc, text = e.TenLop }));
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
        /// create ds ctkhenthuong
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult CreateCTKhenThuong(string models)
        {
            try
            {
                return Json(null);
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
        public JsonResult ReadCTKhenThuong(GridFilters filter = null)
        {
            try
            {
                IEnumerable<CTKhenThuongViewModel> dsCTKhenThuong = null;

                //filter
                if (filter != null && filter.Filters != null && filter.Filters.Count > 0)
                {
                    var field = filter.Filters[0].Field;
                    var operate = filter.Filters[0].Operator;
                    var value = filter.Filters[0].Value;
                    int maqd;

                    if (field == "MaQuyetDinh" && operate == "eq"
                        && int.TryParse(value, out maqd))
                    {
                        dsCTKhenThuong = _CTKhenThuongService.GetCTKhenThuongInQDKhenThuong(maqd);
                    }
                }
                if (dsCTKhenThuong == null)
                {
                    dsCTKhenThuong = _CTKhenThuongService.GetAllCTKhenThuongVM();
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
                var dsCTKhenThuong = JsonConvert.DeserializeObject<IEnumerable<CTKhenThuongViewModel>>(models);

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
                var dsCTKhenThuong = JsonConvert.DeserializeObject<IEnumerable<CTKhenThuongViewModel>>(models);

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

        /// <summary>
        /// read list hocsinh to select and create qdkhenthuong
        /// </summary>
        /// <returns>list hocsinh as json</returns>
        public JsonResult ReadHocSinh()
        {
            try
            {
                var dsHocSinh = _QDKhenThuongService.GetAllSelectHocSinhVM();

                return Json(dsHocSinh);
            }
            catch (Exception ex)
            { 
                //show message here
                return Json(null);
            }
        }

        /// <summary>
        /// select hocsinh for qdkhenthuong
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        public JsonResult SelectHocSinh(string models, int? maqd)
        {
            try
            {
                var dsHocSinh = JsonConvert.DeserializeObject<List<SelectHocSinhViewModel>>(models);
                if (dsHocSinh == null)
                    return Json(null);
                try
                {
                    if (maqd != null)
                    {
                        dsHocSinh = dsHocSinh.Where(e => e.Checked).ToList();
                        _QDKhenThuongService.AddDsCTKhenThuong(maqd.Value, dsHocSinh);
                    }
                    else
                    {
                        foreach (var hs in dsHocSinh)
                            hs.Checked = false;
                    }
                }
                catch (Exception e)
                {
                    foreach (var hs in dsHocSinh)
                        hs.Checked = false;
                    return Json(dsHocSinh);
                }

                return Json(dsHocSinh);
            }
            catch (Exception ex)
            { 
                //show message here
                return Json(null);
            }
        }

    }
}