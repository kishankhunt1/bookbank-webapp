using BookBank.DataAccess;
using BookBank.DataAccess.Repository;
using BookBank.DataAccess.Repository.IRepository;
using BookBank.Models;
using BookBank.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BookBank.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Show all category
        public IActionResult Index()
        {
            IEnumerable<Category> Categoryobj = _unitOfWork.Category.GetAll();
            return View(Categoryobj);
        }
        #endregion

        #region Create record
        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("errormsg", "name and displayorder may be same which is not possible...");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.save();
                TempData["success"] = "Category Inserted Successfully !";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #endregion

        #region Edit record
        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var FirstorDefault = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (FirstorDefault == null)
            {
                return NotFound();
            }
            return View(FirstorDefault);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("errormsg", "name and displayorder may be same which is not possible...");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.save();
                TempData["success"] = "Category Updated Successfully !";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #endregion

        #region Delete record
        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.save();
            TempData["success"] = "Category Deleted Successfully !";
            return RedirectToAction("Index");
        }
        #endregion
    }
}