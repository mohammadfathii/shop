using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Models
{
    [Table("Covers")]
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        public string Name { get; set; }
    }
}

