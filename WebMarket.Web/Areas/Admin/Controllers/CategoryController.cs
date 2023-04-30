using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _db { get; set; }
        public CategoryController(ICategoryService db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.GetAll();
            return View(categories);
        }

        public IActionResult Show(int Id)
        {
            Category category = _db.GetFirstOrDefault(category => category.Id == Id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            // Custom Validation Error
            if (category.Name == null || category.Name == "")
            {
                ModelState.AddModelError("Name", "لطفا فیلد نام را پر نمایید !");
            }
            if (category.DisplayOrder == 0)
            {
                ModelState.AddModelError("DisplayOrder", "لطفا فیلد ترتیب نمایش را پر کنید !");
            }

            if (ModelState.IsValid) // Validation
            {
                _db.Add(category);
                _db.Save(); // need to use after all changes 
                TempData["success"] = "دسته بندی با موفقیت ساخته شد !";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(Category category)
        {
            if (category != null)
            {
                _db.Remove(category);
                _db.Save();
                TempData["success"] = "دسته بندی با موفقیت حذف شد !";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }

            Category category = _db.GetFirstOrDefault(Category => Category.Id == Id);
            // Category category = _db.Categories.FirstOrDefault(cat => cat.Id == Id);
            // Category category = _db.Categories.SingleOrDefault(cat => cat.Id == Id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (category != null)
            {
                _db.Update(category);
                TempData["success"] = "دسته بندی با موفقیت ویرایش شد !";
                _db.Save();
            }
            return RedirectToAction("Index");
        }

    }
}

