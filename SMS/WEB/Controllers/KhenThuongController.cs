using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;

namespace WEB.Controllers
{

    public class KhenThuongController : Controller
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly IKhenThuongService _KhenThuongService;

        public KhenThuongController()
        {
            _KhenThuongService = new KhenThuongService(_UnitOfWork);
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
        /// Get all khenthuong
        /// </summary>
        /// <returns>list khen thuong</returns>
        [HttpPost]
        public JsonResult GetAllKhenThuong()
        {
            try
            {
                var khenthuong = _KhenThuongService.GetAllKhenThuong();
                if (khenthuong != null)
                    return Json(new { Result = "OK", Records = khenthuong });
                return Json(new { Result = "ERROR", Message = "entity is null" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }   
        }

        protected override void Dispose(bool disposing)
        {
            _UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}