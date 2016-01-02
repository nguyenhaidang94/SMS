using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("LopHoc")]
    public partial class LopHoc: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLopHoc { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar")]
        public string MaNamHoc { get; set; }

        [Required]
        public int MaKhoi { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar")]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string TenLop { get; set; }

        [Required]
        public int SiSo { get; set; }

        public virtual NamHoc NamHoc { get; set; }
        public virtual KhoiLop KhoiLop { get; set; }
        public virtual ICollection<TTDKPhongHocChinh> dsTTDKPhongHocChinh { get; set; }
        public virtual ICollection<LichGiangDay> dsLichGiangDay { get; set; }

        public LopHoc()
        {
            dsLichGiangDay = new HashSet<LichGiangDay>();
            dsTTDKPhongHocChinh = new HashSet<TTDKPhongHocChinh>();
        }

    }
}
