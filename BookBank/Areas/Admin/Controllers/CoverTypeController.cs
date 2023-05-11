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
    [Authorize(Roles = SD.Role_Admin)]

    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region select all records of covertype
        public IActionResult Index()
        {
            IEnumerable<CoverType> CoverTypeobj = _unitOfWork.CoverTypes.GetAll();
            return View(CoverTypeobj);
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
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypes.Add(obj);
                _unitOfWork.save();
                TempData["success"] = "CoverType Inserted Successfully !";
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
            var FirstorDefault = _unitOfWork.CoverTypes.GetFirstOrDefault(u => u.Id == id);
            if (FirstorDefault == null)
            {
                return NotFound();
            }
            return View(FirstorDefault);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypes.Update(obj);
                _unitOfWork.save();
                TempData["success"] = "CoverType Updated Successfully !";
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
            var CoverTypeFromDb = _unitOfWork.CoverTypes.GetFirstOrDefault(u => u.Id == id);
            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverTypes.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverTypes.Remove(obj);
            _unitOfWork.save();
            TempData["success"] = "CoverType Deleted Successfully !";
            return RedirectToAction("Index");
        }
        #endregion
    }
}