using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("QuyetDinhKhenThuong")]
    public partial class QuyetDinhKhenThuong: BaseEntity
    {
        [Key, StringLength(50), Column(TypeName="varchar")]
        public string SoQuyetDinh { get; set; }

        [Required]
        public int MaNamHoc { get; set; }

        [Required, Column(TypeName="date")]
        public DateTime NgayQD { get; set; }

        [Required, StringLength(200)]
        public string NoiDungQD { get; set; }

        public virtual ICollection<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong { get; set; }
        public virtual NamHoc NamHoc { get; set; }

        public QuyetDinhKhenThuong()
        {
            dsCTQDKhenThuong = new HashSet<CT_QuyetDinhKhenThuong>();
        }
    }
}
