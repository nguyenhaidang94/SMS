using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("MonHocKhoi")]
    public partial class MonHocKhoi: BaseEntity
    {
        [Key, Column(Order = 0)]
        public int MaNamHoc { get; set; }

        [Key, Column(Order = 1)]
        public int MaKhoi { get; set; }

        [Key, Column(Order = 2)]
        public int MaMonHoc { get; set; }

        public virtual KhoiLop KhoiLop { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual NamHoc NamHoc { get; set; }
    }
}
