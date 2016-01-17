using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SMS.CORE.Data
{
    [Table("ThamSo")]
    public class ThamSo: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TenThamSo { get; set; }

        public string GiaTri { get; set; }
    }
}
