using SMS.CORE;
using System.ComponentModel.DataAnnotations;

namespace SMS.DATA.Models
{
    public class CTKyLuatViewModel : BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MaQuyetDinh { get; set; }

        [Required]
        public int MaHocSinh { get; set; }

        [Required]
        public string HoTen { get; set; }

        [Required, StringLength(200)]
        public string LyDoKyLuat { get; set; }

        [Required, StringLength(200)]
        public string HinhThucKyLuat { get; set; }

        [Required]
        public bool GhiVaoHocBa { get; set; }
    }
}
