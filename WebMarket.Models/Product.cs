using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا عنوان را وارد نمایید !")]
        [DisplayName("عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "لطفا توضیحات را وارد نمایید !")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [Required(ErrorMessage = "لطفا شماره کتاب استاندارد بین المللی را وارد نمایید !")]
        [DisplayName("شماره کتاب استاندارد بین المللی")]

        public string ISBN { get; set; }
        [Required(ErrorMessage = "نویسنده اجباریست!")]
        [DisplayName("نویسنده")]

        public string Author { get; set; }
        [Required(ErrorMessage = "لطفا لیست قیمت را وارد نمایید !")]
        [DisplayName("لیست قیمت")]

        public double ListPrice { get; set; }
        [Required(ErrorMessage = "لطفا قیمت اصلی را وارد نمایید !")]
        [DisplayName("قیمت اصلی")]

        public double Price { get; set; }
        [Required(ErrorMessage = "لطفا قیمت بالای 50 سفارش را وارد نمایید !")]
        [DisplayName("قیمت بالای 50 سفارش")]

        public double Price50 { get; set; }
        [Required(ErrorMessage = "لطفا قیمت بالای 100 سفارش را وارد نمایید !")]
        [DisplayName("قیمت بالای 100 سفارش")]

        public double Price100 { get; set; }
        [Required(ErrorMessage = "لطفا عکس را وارد نمایید !")]
        [DisplayName("عکس")]

        public string ImageURL { get; set; }

        // How to use Foreign Key 1 to Many ( There is 3 1 b 1 , 1 b many , many b many )
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }
    }
}
