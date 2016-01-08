using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("HocKyNamHoc")]
    public partial class HocKyNamHoc: BaseEntity
    {
        [Key, Column(Order=0)]
        public int MaNamHoc { get; set; }

        [Key, StringLength(50), Column(TypeName="varchar", Order=1)]
        public string MaHocKy { get; set; }

        public virtual NamHoc NamHoc { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual ICollection<LichGiangDay> dsLichGiangDay { get; set; }
        public virtual ICollection<BangDiemHKMH> dsBangDiemHKMH { get; set; }

        public HocKyNamHoc()
        {
            dsLichGiangDay = new HashSet<LichGiangDay>();
            dsBangDiemHKMH = new HashSet<BangDiemHKMH>();
        }
    }
}
