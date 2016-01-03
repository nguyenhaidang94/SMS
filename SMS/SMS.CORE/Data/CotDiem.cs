using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("CotDiem")]
    public partial class CotDiem: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCotDiem { get; set; }

        [Required]
        public int MaBangDiem { get; set; }

        [Required]
        public int MaLoaiDiem { get; set; }

        [Required]
        [StringLength(50), Column(TypeName="nvarchar")]
        public string TenCotDiem { get; set; }

        [Required]
        public float GiaTri { get; set; }

        public virtual BangDiemHKMH BangDiemHKMH { get; set; }
        public virtual LoaiDiem LoaiDiem { get; set; }

        public CotDiem()
        { }
    }
}
