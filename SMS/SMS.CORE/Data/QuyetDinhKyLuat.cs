using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
     [Table("QuyetDinhKyLuat")]
    public partial class QuyetDinhKyLuat
    {
        [Key, StringLength(50), Column(TypeName="varchar")]
        public string SoQuyetDinh { get; set; }

        [Required, StringLength(50), Column(TypeName="varchar")]
        public string MaNamHoc { get; set; }

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
