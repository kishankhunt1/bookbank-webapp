using BookBank.DataAccess.Repository.IRepository;
using BookBank.Models;
using BookBank.Models.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;

        

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Product obj)
        {
            var objfromdb = _db.Products.FirstOrDefault(u => u.Product_id==obj.Product_id);
            if (objfromdb!=null)
            {
                objfromdb.Product_Title           =   obj.Product_Title;
                objfromdb.Product_Description     =   obj.Product_Description;
                objfromdb.Product_ISBN            =   obj.Product_ISBN;
                objfromdb.Product_Author          =   obj.Product_Author;
                objfromdb.Product_ListPrice       =   obj.Product_ListPrice;
                objfromdb.Product_Price           =   obj.Product_Price;
                objfromdb.Product_Price50         =   obj.Product_Price50;
                objfromdb.Product_Price100        =   obj.Product_Price100;
                objfromdb.CategoryId              =   obj.CategoryId;
                objfromdb.CoverTypeId             =   obj.CoverTypeId;

                if (obj.Product_ImageUrl != null)
                {
                  objfromdb.Product_ImageUrl= obj.Product_ImageUrl;
                }

            }
        }
    }
}
