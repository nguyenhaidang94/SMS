using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("CT_QuyetDinhKhenThuong")]
    public partial class CT_QuyetDinhKhenThuong: BaseEntity
    {
        [Key, Column(Order=0)]
        public int MaQuyetDinh { get; set; }

        [Key, Column(Order=1)]
        public int MaHocSinh { get; set; }

        [Required, StringLength(200)]
        public string LyDoKhenThuong { get; set; }

        [Required, StringLength(200)]
        public string HinhThucKhenThuong { get; set; }

        public long? GiaTriKhenThuong { get; set; }

        [Required]
        public bool GhiVaoHocBa { get; set; }

        public virtual QuyetDinhKhenThuong QDKhenThuong { get; set; }
        public virtual HocSinh HocSinh { get; set; }
    }
}
