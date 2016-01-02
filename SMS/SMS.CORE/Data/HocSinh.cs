using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    public partial class HocSinh: Nguoi
    {
        [Required, StringLength(100)]
        public string HoTenCha { get; set; }

        [Required, StringLength(100)]
        public string NgheNghiepCha { get; set; }

        [Required, StringLength(100)]
        public string HoTenMe { get; set; }

        [Required, StringLength(100)]
        public string NgheNghiepMe { get; set; }

        public virtual ICollection<BangDiemHKMH> dsBangDiemHKMH { get; set; }
        public ICollection<ThongTinKhenThuong> dsThongTinKhenThuong { get; set; }
        public ICollection<ThongTinKyLuat> dsThongTinKyLuat { get; set; }
        public ICollection<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong { get; set; }
        public ICollection<CT_QuyetDinhKyLuat> dsCTQDKyLuat { get; set; }

        public HocSinh()
        {
            dsBangDiemHKMH = new HashSet<BangDiemHKMH>();
            dsThongTinKhenThuong = new HashSet<ThongTinKhenThuong>();
            dsThongTinKyLuat = new HashSet<ThongTinKyLuat>();
            dsCTQDKyLuat = new HashSet<CT_QuyetDinhKyLuat>();
        }
    }
}
