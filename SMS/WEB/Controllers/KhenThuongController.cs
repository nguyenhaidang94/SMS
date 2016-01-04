using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;

namespace WEB.Controllers
{

    public class KhenThuongController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
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
        /// get hocsinh for options
        /// </summary>
        /// <returns>list hocsinh</returns>
        [HttpPost]
        public JsonResult GetHocSinhOptions()
        {
            try
            {
                var hocsinhOptions = _HocSinhService.GetAllHocSinhOptions();
                return Json(new { Result = "OK", Options = hocsinhOptions });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        /// <summary>
        /// get giaovien for options
        /// </summary>
        /// <returns>list giaovien options</returns>
        [HttpPost]
        public JsonResult GetGiaoVienOptions()
        {
            try
            {
                var giaovienOptions = _GiaoVienService.GetAllGiaoVienOptions();
                return Json(new { Result = "OK", Options = giaovienOptions });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        /// <summary>
        /// get tiethoc options
        /// </summary>
        /// <returns>list tiethoc service</returns>
        [HttpPost]
        public JsonResult GetTietHocOptions()
        {
            try
            {
                var tiethocOptions = _TietHocService.GetAllTietHocOptions();
                return Json(new { Result = "OK", Options = tiethocOptions });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all khenthuong
        /// </summary>
        /// <returns>list khen thuong</returns>
        [HttpPost]
        public JsonResult GetAllKhenThuong()
        {
            try
            {
                var dskhenthuong = _KhenThuongService.GetAllKhenThuong();
                if (dskhenthuong != null)
                    return Json(new { Result = "OK", Records = dskhenthuong });
                return Json(new { Result = "ERROR", Message = "entity is null" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }   
        }

        /// <summary>
        /// create thongtinkhenthuong
        /// </summary>
        /// <returns>json success or fail</returns>
        [HttpPost]
        public JsonResult CreateKhenThuong()
        {
            var khenthuong = new ThongTinKhenThuong();
            if (!TryUpdateModel(khenthuong))
            {
                return Json(new { Result = "ERROR", Message = "Dữ liệu khen thưởng không đúng. Vui lòng nhập lại!" });
            }

            return Json(new { Result = "ERROR", Message = "Chưa thêm dữ liệu" });
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