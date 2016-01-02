using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("MonHoc")]
    public partial class MonHoc: BaseEntity
    {
        [Key, StringLength(50), Column(TypeName="varchar")]
        public string MaMonHoc { get; set; }

        [Required, StringLength(100)]
        public string TenMonHoc { get; set; }

        [Required]
        public float HeSo { get; set; }

        public int? SoTiet { get; set; }

        public virtual ICollection<LichGiangDay> dsLichGiangDay { get; set; }
        public virtual ICollection<BangDiemHKMH> dsBangDiemHKMH { get; set; }
        public virtual ICollection<MonHocKhoi> dsMonHocKhoi { get; set; }

        public MonHoc()
        {
            dsLichGiangDay = new HashSet<LichGiangDay>();
            dsBangDiemHKMH = new HashSet<BangDiemHKMH>();
            dsMonHocKhoi = new HashSet<MonHocKhoi>();
        }
    }
}
