using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    public partial class GiaoVien: Nguoi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGiaoVien { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string CMND { get; set; }

        public virtual ICollection<CT_LichGiangDay> dsCT_LichGiangDay { get; set; }
        public virtual ICollection<ThongTinKhenThuong> dsThongTinKhenThuong { get; set; }
        public virtual ICollection<ThongTinKyLuat> dsThongTinKyLuat { get; set; }
        public virtual ICollection<GiaoVienMonHoc> dsGiaoVienMonHoc { get; set; }

        public GiaoVien()
        {
            dsCT_LichGiangDay = new HashSet<CT_LichGiangDay>();
            dsThongTinKhenThuong = new HashSet<ThongTinKhenThuong>();
            dsThongTinKyLuat = new HashSet<ThongTinKyLuat>();
            dsGiaoVienMonHoc = new HashSet<GiaoVienMonHoc>();
        }
    }
}
