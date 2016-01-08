using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("ThongTinKhenThuong")]
    public partial class ThongTinKhenThuong: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTTKhenThuong { get; set; }

        [Required]
        public int MaGiaoVien { get; set; }

        [Required]
        public int MaHocSinh { get; set; }

        [Required]
        public int MaTietHoc { get; set; }

        [Required, StringLength(500), Column(TypeName = "nvarchar")]
        public string NoiDungKhenThuong { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime NgayKhenThuong { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }
        public virtual HocSinh HocSinh { get; set; }
        public virtual TietHoc TietHoc { get; set; }

        public ThongTinKhenThuong()
        { }
    }
}
