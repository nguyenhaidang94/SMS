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
    /// controller report
    /// </summary>
    [Authorize(Roles = "Admin, Hiệu Trưởng, Giáo Viên")]
    public class BaoCaoController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly INamHocService _NamHocService;
        private readonly IKhoiLopService _KhoiLopService;
        private readonly IBaoCaoService _BaoCaoService;

        public BaoCaoController()
        {
            _NamHocService = new NamHocService(_UnitOfWork);
            _KhoiLopService = new KhoiLopService(_UnitOfWork);
            _BaoCaoService = new BaoCaoService(_UnitOfWork);
        }

        /// <summary>
        /// redirect to view ThongKeDiemMonHocTheoKhoi
        /// </summary>
        /// <returns>view ThongKeDiemMonHocTheoKhoi</returns>
        public ActionResult ThongKeNhomDiem()
        {
            ViewBag.dsNamHoc = JsonConvert.SerializeObject(_NamHocService.GetAll()
                .Select(e => new { value = e.MaNamHoc, text = e.NamBatDau + "-" + e.NamKetThuc }));
            ViewBag.dsKhoiLop = JsonConvert.SerializeObject(_KhoiLopService.GetAll()
                .Select(m => new { value = m.MaKhoi, text = m.TenKhoi }));

            return View();
        }

        /// <summary>
        /// read data for ThongKeNhomDiem
        /// </summary>
        /// <returns></returns>
        public JsonResult ReadNhomDiem()
        {
            try
            {
                var dsThongKe = _BaoCaoService.BaoCaoNhomDiem();
                return Json(dsThongKe, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //show message here
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
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