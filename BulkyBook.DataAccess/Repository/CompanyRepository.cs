using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BullyBook_ECS.Data;
using BullyBook_ECS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            //we have just do that to embeded them if we use _db in main project
            //_db.products.Include(u => u.Category).Include(u => u.CoverType);
        }
        public void Update(Company company)
        {
           var objFromDb = _db.companys.FirstOrDefault(u=>u.Id== company.Id);
            if (objFromDb != null)
            {
                objFromDb.Name= company.Name;
                objFromDb.StreetAddress= company.StreetAddress;
                objFromDb.City= company.City;
                objFromDb.State= company.State;
                objFromDb.PostalCode= company.PostalCode;
                objFromDb.PhoneNumber= company.PhoneNumber;
            }
        }
    }
}

