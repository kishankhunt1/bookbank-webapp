﻿using BookBank.DataAccess.Repository.IRepository;
using BookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverTypes = new CoverTypesRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart=new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderHeader=new OrderHeaderRepository(_db);
            OrderDetail=new OrderDetailRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypesRepository CoverTypes { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company{get; private set;}
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get;private set; }


        public void save()
        {
            _db.SaveChanges();
        }
    }
}