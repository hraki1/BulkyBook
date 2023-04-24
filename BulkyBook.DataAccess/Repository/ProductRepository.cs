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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            //we have just do that to embeded them if we use _db in main project
            //_db.products.Include(u => u.Category).Include(u => u.CoverType);
        }
        public void Update(Product product)
        {
           var objFromDb = _db.products.FirstOrDefault(u=>u.Id== product.Id);
            if (objFromDb != null)
            {
                objFromDb.Title= product.Title;
                objFromDb.Description= product.Description;
                objFromDb.Price= product.Price;
                objFromDb.Price50= product.Price50;
                objFromDb.ListPrice= product.ListPrice;
                objFromDb.Price100= product.Price100;
                objFromDb.ISBN= product.ISBN;
                objFromDb.Author= product.Author;
                objFromDb.CategoryId= product.CategoryId;
                objFromDb.CoverTypeId= product.CoverTypeId;
                if (product.ImageUrl !=null)
                {
                objFromDb.ImageUrl= product.ImageUrl;
                }      
            }
        }
    }
}

