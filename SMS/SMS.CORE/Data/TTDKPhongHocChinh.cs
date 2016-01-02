using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("TTDKPhongHocChinh")]
    public partial class TTDKPhongHocChinh: BaseEntity
    {
        [Key, StringLength(50), Column(Order=0, TypeName="varchar")]
        public string MaPhong { get; set; }

        [Key, Column(Order = 1)]
        public int MaLop { get; set; }

        [Required, Column(TypeName="date")]
        public DateTime NgayDangKy { get; set; }

        [Required, StringLength(50), Column(TypeName="nvarchar")]
        public string BuoiHoc { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }
        public virtual LopHoc LopHoc { get; set; }
    }
}
