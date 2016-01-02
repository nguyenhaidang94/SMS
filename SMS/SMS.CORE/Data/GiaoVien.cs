using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    public partial class GiaoVien: Nguoi
    {
        public ICollection<CT_LichGiangDay> dsCT_LichGiangDay { get; set; }
        public ICollection<ThongTinKhenThuong> dsThongTinKhenThuong { get; set; }
        public ICollection<ThongTinKyLuat> dsThongTinKyLuat { get; set; }

        public GiaoVien()
        {
            dsCT_LichGiangDay = new HashSet<CT_LichGiangDay>();
            dsThongTinKhenThuong = new HashSet<ThongTinKhenThuong>();
            dsThongTinKyLuat = new HashSet<ThongTinKyLuat>();
        }
    }
}
