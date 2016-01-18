using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SMS.CORE.Data
{
    [Table("MonHocKhoi")]
    public partial class MonHocKhoi: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MaKhoi { get; set; }

        [Required]
        public int MaMonHoc { get; set; }

        public virtual KhoiLop KhoiLop { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
