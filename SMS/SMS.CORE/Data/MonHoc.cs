using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("MonHoc")]
    public partial class MonHoc: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMonHoc { get; set; }

        [Required, StringLength(100)]
        public string TenMonHoc { get; set; }

        [Required]
        public float HeSo { get; set; }

        public int? SoTiet { get; set; }

        public virtual ICollection<LichGiangDay> dsLichGiangDay { get; set; }
        public virtual ICollection<BangDiemHKMH> dsBangDiemHKMH { get; set; }
        public virtual ICollection<KhoiLop> dsKhoi { get; set; }
        public virtual ICollection<GiaoVienMonHoc> dsGiaoVienMonHoc { get; set; }

        public MonHoc()
        {
            dsLichGiangDay = new HashSet<LichGiangDay>();
            dsBangDiemHKMH = new HashSet<BangDiemHKMH>();
            dsKhoi = new HashSet<KhoiLop>();
            dsGiaoVienMonHoc = new HashSet<GiaoVienMonHoc>();
        }
    }
}
