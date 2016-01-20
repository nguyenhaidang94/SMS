using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("KhoiLop")]
    public partial class KhoiLop: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhoi { get; set; }

        [StringLength(100), Column(TypeName = "nvarchar")]
        public string TenKhoi { get; set; }

        public virtual ICollection<LopHoc> dsLopHoc { get; set; }
        public virtual ICollection<MonHoc> dsMonHoc { get; set; }

        public KhoiLop()
        {
            dsLopHoc = new HashSet<LopHoc>();
            dsMonHoc = new HashSet<MonHoc>();
        }
    }
}
