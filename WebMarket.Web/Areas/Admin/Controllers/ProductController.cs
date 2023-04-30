using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Data;
using WebMarket.Models;

namespace WebMarket.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public WebMarket_DB WebMarket_DB { get; set; }
        public ProductController(WebMarket_DB webMarket_DB) {
            WebMarket_DB = webMarket_DB;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = WebMarket_DB.Products;
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
