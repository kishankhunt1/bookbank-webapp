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

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        #region show all products
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region add or edit products
        // GET
        public IActionResult Upsert(int? id)
        {
            ProductVm productvm = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value=i.Id.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverTypes.GetAll().Select(i => new SelectListItem { 
                    Text = i.name,
                    Value = i.Id.ToString()
                }),
            };

            if(id == null || id == 0)
            {
                return View(productvm);
            }
            else
            {
                productvm.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Product_id == id); 
                return View(productvm);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVm obj,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // photo image
                string wwwrootpath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename=Guid.NewGuid().ToString();
                    var uploads=Path.Combine(wwwrootpath,@"images\products");
                    var extension=Path.GetExtension(file.FileName);
                    if (obj.Product.Product_ImageUrl != null)
                    {
                        var oldImagePath=Path.Combine(wwwrootpath,obj.Product.Product_ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using(var fileStreams=new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.Product_ImageUrl = @"\images\products\" + filename + extension;
                }
                
                if(obj.Product.Product_id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                    TempData["success"] = "Product Created Successfully !";
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                    TempData["success"] = "Product Edited Successfully !";
                }
                _unitOfWork.save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #endregion

        #region Fetch Data By API End Point
        [HttpGet]
        public IActionResult GetAll()
        {
            //list of category and covertype
            var productList=_unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");
            return Json(new { data = productList });

        }
        #endregion

        #region delete product
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Product_id == id);

            if (obj == null)
            {
                return Json(new { success=false,message="Error while Deleting" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.Product_ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.save();
            return Json(new {success=true, message="Deleted Successfully" });
        }
        #endregion
    }
}