using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("BangDiemHKMH")]
    public partial class BangDiemHKMH: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBangDiem { get; set; }

        [Required]
        public int MaHocSinh { get; set; }

        [Required]
        public int MaNamHoc { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar")]
        public string MaHocKy { get; set; }

        [Required]
        public int MaMonHoc { get; set; }

        [Required]
        public float DiemTB { get; set; }

        public virtual HocKyNamHoc HocKyNamHoc { get; set; }
        public virtual HocSinh HocSinh { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual ICollection<CotDiem> dsCotDiem { get; set; }

        public BangDiemHKMH()
        {
            dsCotDiem = new HashSet<CotDiem>();
        }
    }
}
