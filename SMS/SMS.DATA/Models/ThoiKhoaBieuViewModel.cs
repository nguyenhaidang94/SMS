using SMS.CORE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DATA.Models
{
    public class ThoiKhoaBieuViewModel
    {
      
        public int MaLichGiangDay { get; set; }

        public int MaNamHoc { get; set; }

        public string MaHocKy { get; set; }

        public int MaLopHoc { get; set; }

        public int MaMonHoc { get; set; }

        public int MaTietHoc { get; set; }

        public int MaPhongHoc { get; set; }

        public string Thu { get; set; }

        public int MaGiaoVien { get; set; }

        public string TenGiaoVien { get; set; }

        public string TenMonHoc { get; set; }

        public string TenLopHoc { get; set; }

        public string TenPhongHoc { get; set; }

        public string TenNamHoc { get; set; }

        public string TenHocKy { get; set; }

        public ThoiKhoaBieuViewModel()
        {

        }
    }
}
