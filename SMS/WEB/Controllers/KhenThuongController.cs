using System;
using System.Web.Mvc;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WEB.Controllers
{

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

        [HttpPost]
        public JsonResult ReadHocSinh()
        {
            try
            {
                var hocsinhViewModels = _HocSinhService.GetHocSinhViewModels();
                if (hocsinhViewModels == null)
                {
                    return Json(null);
                }
                return Json(hocsinhViewModels);
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