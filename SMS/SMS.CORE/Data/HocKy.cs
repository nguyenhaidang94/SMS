using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("HocKy")]
    public partial class HocKy: BaseEntity
    {
        [Key, StringLength(50), Column(TypeName="varchar")]
        public string MaHocKy { get; set; }

        [Required]
        [StringLength(100), Column(TypeName="nvarchar")]
        public string TenHocKy { get; set; }

        [Required]
        public float HeSo { get; set; }

        public virtual ICollection<HocKyNamHoc> dsHocKyNamHoc { get; set; }

        public HocKy()
        {
            dsHocKyNamHoc = new HashSet<HocKyNamHoc>();
        }
    }
}
