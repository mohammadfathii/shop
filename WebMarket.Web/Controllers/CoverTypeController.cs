using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Repository.IRepository;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    public class CoverTypeController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public CoverTypeController(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> categories = UnitOfWork.CoverType.GetAll();
            return View(categories);
        }

        public IActionResult Show(int Id)
        {
            CoverType CoverType = UnitOfWork.CoverType.GetFirstOrDefault(CoverType => CoverType.Id == Id);
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
                UnitOfWork.CoverType.Add(CoverType);
                UnitOfWork.SaveChanges(); // need to use after all changes 
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
                UnitOfWork.CoverType.Remove(CoverType);
                UnitOfWork.SaveChanges();
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

            CoverType CoverType = UnitOfWork.CoverType.GetFirstOrDefault(CoverType => CoverType.Id == Id);
            // CoverType CoverType = UnitOfWork.Categories.FirstOrDefault(cat => cat.Id == Id);
            // CoverType CoverType = UnitOfWork.Categories.SingleOrDefault(cat => cat.Id == Id);

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
                UnitOfWork.CoverType.Update(CoverType);
                TempData["success"] = "کاور تایپ با موفقیت ویرایش شد !";
                UnitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
