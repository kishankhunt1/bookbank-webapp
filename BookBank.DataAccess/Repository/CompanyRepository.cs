using BookBank.DataAccess.Repository.IRepository;
using BookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.DataAccess.Repository
{
    public class CompanyRepository : Repository<Companies>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Companies obj)
        {
            _db.Companys.Update(obj);
        }
    }
}
