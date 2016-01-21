using Newtonsoft.Json;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.DATA.Models;
using SMS.SERVICE.IService;
using SMS.SERVICE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
     [Authorize(Roles = " Hiệu Trưởng")]

    public class ThoiKhoaBieuController : Controller
    {
        private readonly UnitOfWork _UnitOfWork = new UnitOfWork();
        private readonly ILapThoiKhoaBieuService _ThoiKhoaBieuService;
        private readonly IMonHocService _MonHocService;
        private ILapThoiKhoaBieuService _LapThoiKhoaBieu;
        private readonly IGiaoVienService _GiaoVienService;
        private readonly ILopHocService _LopHocService;
        private readonly INamHocService _NamHocService;
        private readonly IHocKyService _HocKyService;
        private IEnumerable<ThoiKhoaBieuViewModel> listThoiKhoaBieuViewModel;
        

        public ThoiKhoaBieuController()
        {
            _ThoiKhoaBieuService = new LapThoiKhoaBieuService(_UnitOfWork);
            _GiaoVienService = new GiaoVienService(_UnitOfWork);
            _MonHocService = new MonHocService(_UnitOfWork);
            _LopHocService = new LopHocService(_UnitOfWork);
            _NamHocService = new NamHocService(_UnitOfWork);
            _HocKyService = new HocKyService(_UnitOfWork);
        }

        /// <summary>
        /// return view ThoiKhoaBieu
        /// </summary>
        /// <returns>ThoiKhoaBieu.cshtml</returns>
        public ActionResult LapThoiKhoaBieu()
        {
            ViewBag.dsTKB = JsonConvert.SerializeObject(_ThoiKhoaBieuService.GetAll());
            ViewBag.dsNamHoc =  JsonConvert.SerializeObject(_NamHocService.GetAll());
            ViewBag.dsHocKy = JsonConvert.SerializeObject(_HocKyService.GetAll()); 
            ViewBag.dsGiaoVien = JsonConvert.SerializeObject(_GiaoVienService.GetAllGiaoVien());
          
            ViewBag.dsMonHoc = JsonConvert.SerializeObject(_MonHocService.GetAll()
                 .Select(e => new { value = e.MaMonHoc, text = e.TenMonHoc}));

            //ViewBag.dsLopHoc = JsonConvert.SerializeObject(_LopHocService.GetAll());

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
                
                listThoiKhoaBieuViewModel = _ThoiKhoaBieuService.KhoiTaoViewModel();

                var dsTKB = _ThoiKhoaBieuService.GetAll();
               
                if (dsTKB == null)
                {
                    return Json(null);
                }
                return Json(listThoiKhoaBieuViewModel);
                
            }
            catch (Exception ex)
            {
                //ShowMessage here
                return Json(null);
            }
        }

        /// <summary>
        /// Tao TKB
        /// </summary>
        /// <param name="models">json data</param>
        [HttpPost]
        public JsonResult Create(string models)
        {
            var dsLichGiangDay = JsonConvert.DeserializeObject<IEnumerable<LichGiangDay>>(models);

            List<GiaoVien> listGiaoVien = _GiaoVienService.GetAllGiaoVien().ToList();
            List<LichGiangDay> listGiangDay = new List<LichGiangDay>();

            try
            {
                _LapThoiKhoaBieu = new LapThoiKhoaBieuService(listGiaoVien, _MonHocService.GetAll().ToList(), _LopHocService.GetAll().ToList(), listGiangDay, _UnitOfWork);
                _LapThoiKhoaBieu.CreateQuanTheBanDau(dsLichGiangDay.First().MaNamHoc, dsLichGiangDay.First().MaHocKy); // khởi tạo thời khóa biểu random

                if (_LapThoiKhoaBieu.CapNhatMonHocBiTrungTKB()) // cập nhật lai thời khóa biểu sao cho không có tiết học bi trùng
                {
                    var dsTKB = _LapThoiKhoaBieu.layThoiKhoaBieu();

                    //_LapThoiKhoaBieu.AddDsGiangDay(_LapThoiKhoaBieu.layThoiKhoaBieu());
                    return Json(dsTKB);
                }
                return Json(null);
          
            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }

        [HttpPost]
        public JsonResult TaoThoiKhoaBieu(int NamHoc, String HocKy)
        {
            List<GiaoVien> listGiaoVien = new List<GiaoVien>();
            List<LichGiangDay> listGiangDay = new List<LichGiangDay>();

            try
            {
                _LapThoiKhoaBieu = new LapThoiKhoaBieuService(listGiaoVien, _MonHocService.GetAll().ToList(), _LopHocService.GetAll().ToList(), listGiangDay, _UnitOfWork);
                _LapThoiKhoaBieu.CreateQuanTheBanDau(NamHoc, HocKy); // khởi tạo thời khóa biểu random

                if (_LapThoiKhoaBieu.CapNhatMonHocBiTrungTKB()) // cập nhật lai thời khóa biểu sao cho không có tiết học bi trùng
                {
                    var dsTKB = _LapThoiKhoaBieu.layThoiKhoaBieu();

                    _LapThoiKhoaBieu.AddDsGiangDay(_LapThoiKhoaBieu.layThoiKhoaBieu());
                    return Json(dsTKB);
                }
                return Json(null);

            }
            catch (Exception ex)
            {
                //Show Message here
                return Json(null);
            }
        }
    }
}