using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Repository.IRepository;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    public class CategoryController : Controller
    {   
        private IUnitOfWork _db { get; set; }
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Category.GetAll();
            return View(categories);
        }

        public IActionResult Show(int Id)
        {
            Category category = _db.Category.GetFirstOrDefault(category => category.Id == Id);
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
                ModelState.AddModelError("Name","لطفا فیلد نام را پر نمایید !");
            }
            if (category.DisplayOrder == 0)
            {
                ModelState.AddModelError("DisplayOrder","لطفا فیلد ترتیب نمایش را پر کنید !");
            }

            if (ModelState.IsValid) // Validation
            {
                _db.Category.Add(category);
                _db.SaveChanges(); // need to use after all changes 
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
                _db.Category.Remove(category);
                _db.SaveChanges();
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

            Category category = _db.Category.GetFirstOrDefault(Category => Category.Id == Id);
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
                _db.Category.Update(category);
                TempData["success"] = "دسته بندی با موفقیت ویرایش شد !";
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

