using System;
using System.Web.Mvc;
using SMS.CORE.Data;
using SMS.DATA;
using System.Linq;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WEB.Controllers
{

    public class KyLuatController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IKyLuatService _KyLuatService;
        private readonly IHocSinhService _HocSinhService;
        private readonly IGiaoVienService _GiaoVienService;
        private readonly ITietHocService _TietHocService;

        public KyLuatController()
        {
            _KyLuatService = new KyLuatService(_UnitOfWork);
            _HocSinhService = new HocSinhService(_UnitOfWork);
            _GiaoVienService = new GiaoVienService(_UnitOfWork);
            _TietHocService = new TietHocService(_UnitOfWork);
        }

        /// <summary>
        /// return view QuanLyKhenThuong
        /// </summary>
        /// <returns>QuanLyKhenThuong.cshtml</returns>
        public ActionResult QuanLyKyLuat()
        {
            ViewBag.dsHocSinh = JsonConvert.SerializeObject(_HocSinhService.GetAllHocSinh()
                .Select(e => new { value = e.PersonId, text = e.HoTen }));
            ViewBag.dsGiaoVien = JsonConvert.SerializeObject(_GiaoVienService.GetAllGiaoVien()
                .Select(e => new { value = e.PersonId, text = e.HoTen }));
            ViewBag.dsTietHoc = JsonConvert.SerializeObject(_TietHocService.GetAllTietHoc()
               .Select(e => new { value = e.MaTietHoc, text = "Tiết " + e.MaTietHoc }));
            return View();
        }

        /// <summary>
        /// create khenthuong
        /// </summary>
        /// <param name="models">json data</param>
        [HttpPost]
        public JsonResult Create(string models)
        {
            try
            {
                var dsKyLuat = JsonConvert.DeserializeObject<IEnumerable<ThongTinKyLuat>>(models);

                if (dsKyLuat != null)
                {
                    _KyLuatService.AddDsKyLuat(dsKyLuat);
                }
                return Json(dsKyLuat);
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        /// <summary>
        /// get all khenthuong
        /// </summary>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Read()
        {
            try
            {
                var dsKyLuat = _KyLuatService.GetAllKyLuat();
                if (dsKyLuat == null)
                {
                    return Json(null);
                }
                return Json(dsKyLuat);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }

        /// <summary>
        /// update khenthuong
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Update(string models)
        {
            try
            {
                var dsKyLuat = JsonConvert.DeserializeObject<IEnumerable<ThongTinKyLuat>>(models);
                if (dsKyLuat != null)
                {
                    _KyLuatService.UpdateDsKyLuat(dsKyLuat);
                }
                return Json(dsKyLuat);
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }

        /// <summary>
        /// delete khenthuong
        /// </summary>
        /// <param name="models">json data</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                var dsKyLuat = JsonConvert.DeserializeObject<IEnumerable<ThongTinKyLuat>>(models);
                if (dsKyLuat != null)
                {
                    _KyLuatService.DeleteDsKyLuat(dsKyLuat);
                }
                return Json(dsKyLuat);
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