using SMS.CORE.Data;
using SMS.DATA.Models;
using SMS.SERVICE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.SERVICE.IService
{
    public enum KHOI
    {
        KHOI_6 = 0,
        KHOI_7,
        KHOI_8,
        KHOI_9
    }

   public interface ILapThoiKhoaBieuService
    {
       IEnumerable<LichGiangDay> GetAll();
       ChuongTrinhHocService TinhSoTietHocTrongTuan(KHOI Khoi, List<MonHoc> ListGiangDay);
       void CreateQuanTheBanDau(int MaNamHoc, string MaHocKy);
       LichGiangDay[][] CreateTKB_ToanTruong(int MaNamHoc, string MaHocKy);
       LichGiangDay[] CreateTKB_Lop(LopHoc lop, int MaNamHoc, string MaHocKy);
       void LayDanhSachGiaoVienTheoMon(ChuongTrinhHocService chuongTrinhHocLop);
       int KiemTraTietDayCoBiTrung(LichGiangDay[][] TKB_Truong, int column, int rows);
       Boolean CapNhatMonHocBiTrungTKB();

       List<LichGiangDay> layThoiKhoaBieu();

       void AddDsGiangDay(List<LichGiangDay> dsGiangDay);
       GiaoVien[][] TaoDanhSachGiaoVienTheoMon();
       IEnumerable<ThoiKhoaBieuViewModel> KhoiTaoViewModel();


    }

}
