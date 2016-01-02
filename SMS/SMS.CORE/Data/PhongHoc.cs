using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("PhongHoc")]
    public partial class PhongHoc: BaseEntity
    {
        [Key]
        [StringLength(50), Column(TypeName = "varchar")]
        public string MaPhong { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string TenPhong { get; set; }

        public int? SucChua { get; set; }

        public virtual ICollection<LichGiangDay> dsLichGiangDay { get; set; }
        public virtual ICollection<TTDKPhongHocChinh> dsTTDKPhongHocChinh { get; set; }

        public PhongHoc()
        {
            dsLichGiangDay = new HashSet<LichGiangDay>();
            dsTTDKPhongHocChinh = new HashSet<TTDKPhongHocChinh>();
        }
    }
}
