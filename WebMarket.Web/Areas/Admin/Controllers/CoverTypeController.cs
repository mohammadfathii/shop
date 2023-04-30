using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        public ICoverTypeService _db { get; set; }
        public CoverTypeController(ICoverTypeService db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> categories = _db.GetAll();
            return View(categories);
        }

        public IActionResult Show(int Id)
        {
            CoverType CoverType = _db.GetFirstOrDefault(CoverType => CoverType.Id == Id);
            return View(CoverType);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CoverType CoverType)
        {
            // Custom Validation Error
            if (CoverType.Name == null || CoverType.Name == "")
            {
                ModelState.AddModelError("Name", "لطفا فیلد نام را پر نمایید !");
            }

            if (ModelState.IsValid) // Validation
            {
                _db.Add(CoverType);
                _db.Save(); // need to use after all changes 
                TempData["success"] = "کاور تایپ با موفقیت ساخته شد !";
                return RedirectToAction("Index");
            }
            return View(CoverType);
        }

        [HttpGet]
        public IActionResult Delete(CoverType CoverType)
        {
            if (CoverType != null)
            {
                _db.Remove(CoverType);
                _db.Save();
                TempData["success"] = "کاور تایپ با موفقیت حذف شد !";
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

            CoverType CoverType = _db.GetFirstOrDefault(CoverType => CoverType.Id == Id);
            // CoverType CoverType = _db.Categories.FirstOrDefault(cat => cat.Id == Id);
            // CoverType CoverType = _db.Categories.SingleOrDefault(cat => cat.Id == Id);

            if (CoverType == null)
            {
                return NotFound();
            }
            return View(CoverType);
        }
        [HttpPost]
        public IActionResult Update(CoverType CoverType)
        {
            if (CoverType != null)
            {
                _db.Update(CoverType);
                TempData["success"] = "کاور تایپ با موفقیت ویرایش شد !";
                _db.Save();
            }
            return RedirectToAction("Index");
        }
    }
}
