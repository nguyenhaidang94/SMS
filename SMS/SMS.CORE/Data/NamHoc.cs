using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("NamHoc")]
    public partial class NamHoc: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNamHoc { get; set; }

        [Required]
        public int NamBatDau { get; set; }

        [Required]
        public int NamKetThuc { get; set; }

        public virtual ICollection<HocKyNamHoc> dsHocKyNamHoc { get; set; }
        public virtual ICollection<LopHoc> dsLopHoc { get; set; }
        public virtual ICollection<QuyetDinhKhenThuong> dsQDKhenThuong { get; set; }
        public virtual ICollection<QuyetDinhKyLuat> dsQDKyLuat { get; set; }
        public virtual ICollection<HocSinh> dsHocSinhVaoTruong { get; set; }

        public NamHoc()
        {
            dsHocKyNamHoc = new HashSet<HocKyNamHoc>();
            dsLopHoc = new HashSet<LopHoc>();
            dsQDKhenThuong = new HashSet<QuyetDinhKhenThuong>();
            dsQDKyLuat = new HashSet<QuyetDinhKyLuat>();
            dsHocSinhVaoTruong = new HashSet<HocSinh>();
        }
    }
}
