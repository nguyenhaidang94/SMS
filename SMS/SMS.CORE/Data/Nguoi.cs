using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("Nguoi")]
    public partial class Nguoi: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        public int PersonTypeId { get; set; }

        [Required, StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        public bool GioiTinh { get; set; }

        [Required, Column(TypeName="date")]
        public DateTime NgaySinh { get; set; }

        [Required, StringLength(200)]
        public string NoiSinh { get; set; }

        [Required, StringLength(200)]
        public string DiaChi { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar")]
        public string SDT { get; set; }

        public string TonGiao { get; set; }

        public string DanToc { get; set; }

        public virtual PersonType PersonType { get; set; }
    }
}
