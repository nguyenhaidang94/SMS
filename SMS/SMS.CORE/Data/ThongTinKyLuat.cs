using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("ThongTinKyLuat")]
    public partial class ThongTinKyLuat: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTTKyLuat { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string MaGiaoVien { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string MaHocSinh { get; set; }

        [Required]
        public int MaTietHoc { get; set; }

        [Required, StringLength(500), Column(TypeName = "nvarchar")]
        public string NoiDungKyLuat { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime NgayKyLuat { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }
        public virtual HocSinh HocSinh { get; set; }
        public virtual TietHoc TietHoc { get; set; }
    }
}
