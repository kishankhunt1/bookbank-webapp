using BookBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.DataAccess.Repository.IRepository
{
    public interface ICoverTypesRepository:IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}
