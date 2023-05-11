using BookBank.DataAccess;
using BookBank.DataAccess.Repository;
using BookBank.DataAccess.Repository.IRepository;
using BookBank.Models;
using BookBank.Models.View_Model;
using BookBank.Utilities;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookBank.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region select all records
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region add or edit records
        // GET
        public IActionResult Upsert(int? id)
        {
            Companies company = new();
            if(id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company= _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id); 
                return View(company);
            }

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Companies obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company Created Successfully !";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company Edited Successfully !";
                }
                _unitOfWork.save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #endregion

        #region Fetch Data By API End Point

        //fetch list of the company
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList=_unitOfWork.Company.GetAll();
            return Json(new { data = companyList });

        }

        //delete record by api
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success=false,message="Error while Deleting" });
            }
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.save();
            return Json(new {success=true, message="Deleted Successfully" });
        }
        #endregion
    }
}