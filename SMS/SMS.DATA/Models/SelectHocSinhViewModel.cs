using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DATA.Models
{
    public class SelectHocSinhViewModel
    {
        [Required]
        public int MaHocSinh { get; set; }

        [Required]
        public int MaNamHoc { get; set; }

        [Required]
        public int MaLop { get; set; }

        [Required, StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        public bool GioiTinh { get; set; }

        [Required]
        public bool Checked { get; set; }
    }
}
