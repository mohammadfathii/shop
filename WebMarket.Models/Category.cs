using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace WebMarket.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        /* Validation In Model */
        [NotNull, Required(ErrorMessage = "عنوان دسته اجباری است")]
        [DisplayName("نام دسته بندی")]
        public string Name { get; set; }

        /* Validation In Model */
        [DisplayName("ترتیب نمایش دسته بندی")]
        [Required(ErrorMessage = "ترتیب نمایش اجباری است")]
        [Range(1, 1000, ErrorMessage = "لطفا عدد وارد شده را بین 1 تا 1000 بزارید")]
        public int DisplayOrder { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
