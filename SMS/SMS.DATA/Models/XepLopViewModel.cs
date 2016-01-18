using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE.Data;

namespace SMS.DATA.Models
{
    public class XepLopViewModel
    {
        public int MaHocSinh { get; set; }

        public int PersonId { get; set; }

        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public int MaLopHoc { get; set; }

        public int MaNamHoc { get; set; }

        public int MaKhoi { get; set; }

        public XepLopViewModel() { }

        public XepLopViewModel(HocSinh hocSinh, LopHoc lopHoc)
        {
            PersonId = hocSinh.PersonId;
            MaHocSinh = hocSinh.MaHocSinh;
            HoTen = hocSinh.HoTen;
            GioiTinh = hocSinh.GioiTinh;
            NgaySinh = hocSinh.NgaySinh;
            MaLopHoc = lopHoc.MaLopHoc;
            MaNamHoc = lopHoc.MaNamHoc;
            MaKhoi = lopHoc.MaKhoi;
        }

        public XepLopViewModel(HocSinh hocSinh, int maNamHoc)
        {
            PersonId = hocSinh.PersonId;
            MaHocSinh = hocSinh.MaHocSinh;
            HoTen = hocSinh.HoTen;
            GioiTinh = hocSinh.GioiTinh;
            NgaySinh = hocSinh.NgaySinh;
            MaLopHoc = -1;
            MaNamHoc = maNamHoc;
            MaKhoi = -1;
        }
    }
}
