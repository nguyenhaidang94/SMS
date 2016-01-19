using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.CORE.Data
{
    [Table("GiaoVienMonHoc")]
    public class GiaoVienMonHoc: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MaGiaoVien { get; set; }

        [Required]
        public int MaMonHoc { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
