using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace SMS.CORE.Data
{
    [Table("LichGiangDay")]
    public partial class LichGiangDay: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLichGiangDay { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string MaNamHoc { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string MaHocKy { get; set; }

        [Required]
        public int MaLopHoc { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string MaMonHoc { get; set; }

        [Required]
        public int MaTietHoc { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string MaPhongHoc { get; set; }

        [Required, StringLength(50)]
        public string Thu { get; set; }

        public virtual HocKyNamHoc HocKyNamHoc { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual TietHoc TietHoc { get; set; }
        public virtual PhongHoc PhongHoc { get; set; }

        public virtual ICollection<CT_LichGiangDay> dsCT_LichGiangDay { get; set; }

        public LichGiangDay()
        {
            dsCT_LichGiangDay = new HashSet<CT_LichGiangDay>();
        }
    }
}
