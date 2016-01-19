using SMS.CORE;
using System.ComponentModel.DataAnnotations;

namespace SMS.DATA.Models
{
    public class CTKhenThuongViewModel: BaseEntity
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
        public string LyDoKhenThuong { get; set; }

        [Required, StringLength(200)]
        public string HinhThucKhenThuong { get; set; }

        public long? GiaTriKhenThuong { get; set; }

        [Required]
        public bool GhiVaoHocBa { get; set; }
    }
}
