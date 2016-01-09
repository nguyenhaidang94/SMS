using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
     [Table("QuyetDinhKyLuat")]
    public partial class QuyetDinhKyLuat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaQuyetDinh { get; set; }

        [Required, Column(TypeName = "nvarchar")]
        public string SoQuyetDinh { get; set; }

        [Required]
        public int MaNamHoc { get; set; }

        [Required, Column(TypeName="date")]
        public DateTime NgayQD { get; set; }

        [Required, StringLength(200)]
        public string NoiDungQD { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime NgayHieuLuc { get; set; }

        public virtual ICollection<CT_QuyetDinhKyLuat> dsCTQDKyLuat { get; set; }
        public virtual NamHoc NamHoc { get; set; }

        public QuyetDinhKyLuat()
        {
            dsCTQDKyLuat = new HashSet<CT_QuyetDinhKyLuat>();
        }
    }
}
