using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("LoaiDiem")]
    public partial class LoaiDiem: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiDiem { get; set; }

        [Required, StringLength(100)]
        public string TenLoaiDiem { get; set; }

        [Required]
        public float HeSo { get; set; }

        public virtual ICollection<CotDiem> dsCotDiem { get; set; }

        public LoaiDiem()
        {
            dsCotDiem = new HashSet<CotDiem>();
        }
    }
}
