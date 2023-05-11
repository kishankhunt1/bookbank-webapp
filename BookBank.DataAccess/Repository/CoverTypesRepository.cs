using BookBank.DataAccess.Repository.IRepository;
using BookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.DataAccess.Repository
{
    public class CoverTypesRepository : Repository<CoverType>,ICoverTypesRepository
    {
        private readonly ApplicationDbContext _db;

        

        public CoverTypesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
