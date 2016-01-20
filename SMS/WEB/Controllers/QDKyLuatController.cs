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
    /// controller quyetdinh kyluat
    /// </summary>
    [Authorize(Roles = "Admin, Hiệu Trưởng")]
    public class QDKyLuatController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IQDKyLuatService _QDKyLuatService;
        private readonly INamHocService _NamHocService;
        private readonly ICTQDKyLuatService _CTKyLuatService;
        private readonly ILopHocService _LopHocService;
        private readonly IHocSinhService _HocSinhService;

        public QDKyLuatController()
        {
            _QDKyLuatService = new QDKyLuatService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
            _CTKyLuatService = new CTQDKyLuatService(_UnitOfWork);
            _LopHocService = new LopHocService(_UnitOfWork);
            _HocSinhService = new HocSinhService(_UnitOfWork);
        }

        /// <summary>
        /// view quan ly qdkyluat
        /// </summary>
        /// <returns>view</returns>
        public ActionResult QuanLyQDKyLuat()
        {
            ViewBag.dsNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll()
                .Select(e => new { value = e.MaNamHoc, text = e.NamBatDau + "-" + e.NamKetThuc }));
            ViewBag.dsLopHoc = JsonConvert.SerializeObject(_LopHocService.GetAllLopHocViewModel()
                .Select(e => new { value = e.MaLopHoc, text = e.TenLopHoc, MaNamHoc = e.MaNamHoc }));
            return View();
        }

        /// <summary>
        /// create ds qdkyluat
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Create(string models)
        {
            try
            {
                var dsqdkyluat = JsonConvert.DeserializeObject<IEnumerable<QuyetDinhKyLuat>>(models);

                if (dsqdkyluat != null)
                {
                    _QDKyLuatService.AddDsQDKyLuat(dsqdkyluat);
                }
                return Json(dsqdkyluat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// read qdkyluat
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                var dsQdKyLuat = _QDKyLuatService.GetAllQDKyLuat();
                if (dsQdKyLuat == null)
                {
                    return Json(null);
                }
                return Json(dsQdKyLuat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// update ds qdkyluat
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var dsqdkyluat = JsonConvert.DeserializeObject<IEnumerable<QuyetDinhKyLuat>>(models);

                if (dsqdkyluat != null)
                {
                    _QDKyLuatService.UpdateDsQDKyLuat(dsqdkyluat);
                }
                return Json(dsqdkyluat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// delete ds qdkyluat
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                var dsqdkyluat = JsonConvert.DeserializeObject<IEnumerable<QuyetDinhKyLuat>>(models);

                if (dsqdkyluat != null)
                {
                    _QDKyLuatService.DeleteDsQdKyLuat(dsqdkyluat);
                }
                return Json(dsqdkyluat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// get all ctkyluat
        /// </summary>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult ReadCTKyLuat(GridFilters filter = null)
        {
            try
            {
                IEnumerable<CTKyLuatViewModel> dsCTKyLuat = null;

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
                        dsCTKyLuat = _CTKyLuatService.GetCTKyLuatInQDKyLuat(maqd);
                    }
                }
                if (dsCTKyLuat == null)
                {
                    dsCTKyLuat = _CTKyLuatService.GetAllCTKyLuatVM();
                }

                return Json(dsCTKyLuat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// update ds ctkyluat
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult UpdateCTKyLuat(string models)
        {
            try
            {
                var dsCTKyLuat = JsonConvert.DeserializeObject<IEnumerable<CTKyLuatViewModel>>(models);

                if (dsCTKyLuat != null)
                {
                    _CTKyLuatService.UpdateDsCTQDKyLuat(dsCTKyLuat);
                }
                return Json(dsCTKyLuat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// delete ds ctkyluat
        /// </summary>
        /// <param name="models">data json</param>
        /// <returns>data json</returns>
        [HttpPost]
        public JsonResult DeleteCTKyLuat(string models)
        {
            try
            {
                var dsCTKyLuat = JsonConvert.DeserializeObject<IEnumerable<CTKyLuatViewModel>>(models);

                if (dsCTKyLuat != null)
                {
                    _CTKyLuatService.DeleteDsCTQDKyLuat(dsCTKyLuat);
                }
                return Json(dsCTKyLuat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// read list hocsinh to select and create qdkyluat
        /// </summary>
        /// <returns>list hocsinh as json</returns>
        public JsonResult ReadHocSinh()
        {
            try
            {
                var dsHocSinh = _HocSinhService.GetAllSelectHocSinhVM();

                return Json(dsHocSinh);
            }
            catch (Exception ex)
            { 
                //show message here
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// select hocsinh for qdkyluat
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
                        _QDKyLuatService.AddDsCTKyLuat(maqd.Value, dsHocSinh);
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
                return Json(new { error = ex.Message });
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