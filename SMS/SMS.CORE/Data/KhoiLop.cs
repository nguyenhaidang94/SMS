using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("KhoiLop")]
    public partial class KhoiLop: BaseEntity
    {
        [Key]
        public int MaKhoi { get; set; }

        [StringLength(100), Column(TypeName = "nvarchar")]
        public string TenKhoi { get; set; }

        [Required, StringLength(100), Column(TypeName = "nvarchar")]
        public string BuoiHoc { get; set; }

        public virtual ICollection<LopHoc> dsLopHoc { get; set; }
        public virtual ICollection<MonHocKhoi> dsMonHocKhoi { get; set; }

        public KhoiLop()
        {
            dsLopHoc = new HashSet<LopHoc>();
            dsMonHocKhoi = new HashSet<MonHocKhoi>();
        }
    }
}
