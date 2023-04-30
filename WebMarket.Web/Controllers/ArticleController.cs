using Microsoft.AspNetCore.Mvc;

namespace WebMarket.Web.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name","Test Custom Error");
            }

            return View();
        }
    }
}
