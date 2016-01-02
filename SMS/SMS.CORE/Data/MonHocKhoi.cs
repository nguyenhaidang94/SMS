using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("MonHocKhoi")]
    public partial class MonHocKhoi: BaseEntity
    {
        [Key, StringLength(50), Column(Order = 0, TypeName = "varchar")]
        public string MaNamHoc { get; set; }

        [Key, Column(Order = 1)]
        public int MaKhoi { get; set; }

        [Key, StringLength(50), Column(Order = 2, TypeName = "varchar")]
        public string MaMonHoc { get; set; }

        public virtual KhoiLop KhoiLop { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual NamHoc NamHoc { get; set; }
    }
}
