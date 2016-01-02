using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("TietHoc")]
    public partial class TietHoc: BaseEntity
    {
        [Key]
        public int MaTietHoc { get; set; }

        [Required]
        public TimeSpan GioBatDau { get; set; }

        [Required]
        public TimeSpan GioKetThuc { get; set; }

        public ICollection<ThongTinKhenThuong> dsTTKhenThuong { get; set; }
        public ICollection<ThongTinKyLuat> dsTTKyLuat { get; set; }
        public ICollection<LichGiangDay> dsLichGD { get; set; }

        public TietHoc()
        {
            dsTTKhenThuong = new HashSet<ThongTinKhenThuong>();
            dsTTKyLuat = new HashSet<ThongTinKyLuat>();
            dsLichGD = new HashSet<LichGiangDay>();
        }
    }
}
