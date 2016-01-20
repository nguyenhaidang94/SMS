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
    [Authorize(Roles = "Admin,Giáo Viên")]
    public class KhenThuongController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IKhenThuongService _KhenThuongService;
        private readonly IHocSinhService _HocSinhService;
        private readonly IGiaoVienService _GiaoVienService;
        private readonly ITietHocService _TietHocService;

        public KhenThuongController()
        {
            _KhenThuongService = new KhenThuongService(_UnitOfWork);
            _HocSinhService = new HocSinhService(_UnitOfWork);
            _GiaoVienService = new GiaoVienService(_UnitOfWork);
            _TietHocService = new TietHocService(_UnitOfWork);
        }

        /// <summary>
        /// return view QuanLyKhenThuong
        /// </summary>
        /// <returns>QuanLyKhenThuong.cshtml</returns>
        public ActionResult QuanLyKhenThuong()
        {
            ViewBag.dsHocSinh = JsonConvert.SerializeObject(_HocSinhService.GetAll()
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
                var dskhenthuong = JsonConvert.DeserializeObject<IEnumerable<ThongTinKhenThuong>>(models);

                if (dskhenthuong != null)
                {
                    _KhenThuongService.AddDsKhenThuong(dskhenthuong);
                }
                return Json(dskhenthuong);
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
                var dsKhenThuong = _KhenThuongService.GetAllKhenThuong();
                if (dsKhenThuong == null)
                {
                    return Json(null);
                }
                return Json(dsKhenThuong);
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
                var dsKhenThuong = JsonConvert.DeserializeObject<IEnumerable<ThongTinKhenThuong>>(models);
                if (dsKhenThuong != null)
                {
                    _KhenThuongService.UpdateDsKhenThuong(dsKhenThuong);
                }
                return Json(dsKhenThuong);
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
                var dsKhenThuong = JsonConvert.DeserializeObject<IEnumerable<ThongTinKhenThuong>>(models);
                if (dsKhenThuong != null)
                {
                    _KhenThuongService.DeleteDsKhenThuong(dsKhenThuong);
                }
                return Json(dsKhenThuong);
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