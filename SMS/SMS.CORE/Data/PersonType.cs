using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("PersonType")]
    public partial class PersonType: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonTypeId { get; set; }

        [Required, StringLength(100)]
        public string PersonTypeName { get; set; }

        [StringLength(50), Column(TypeName="varchar")]
        public string Prefix { get; set; }

        public virtual ICollection<Nguoi> dsNguoi { get; set; }

        public PersonType()
        {
            dsNguoi = new HashSet<Nguoi>();
        }
    }
}
