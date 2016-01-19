using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("CT_QuyetDinhKyLuat")]
    public partial class CT_QuyetDinhKyLuat: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MaQuyetDinh { get; set; }

        [Required]
        public int MaHocSinh { get; set; }

        [StringLength(200)]
        public string LyDoKyLuat { get; set; }

        [StringLength(200)]
        public string HinhThucKyLuat { get; set; }

        [Required]
        public bool GhiVaoHocBa { get; set; }

        public virtual QuyetDinhKyLuat QDKyLuat { get; set; }
        public virtual HocSinh HocSinh { get; set; }
    }
}
