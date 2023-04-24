using BulkyBook.DataAccess.Repository.IRepository;
using BullyBook_ECS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.shoppingCarts.AsNoTracking()
            //_db.shoppingCarts.AsNoTracking().FirstOrDefault
            //_db.shoppingCarts.AsNoTracking().Where
            //_db.products.Include("CoverType");
            dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> Query = dbSet;
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProp);
                }
            }
            return Query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<T> Query;
            if (tracked)
            {
                Query = dbSet;
            }
            else
            {
                Query = dbSet.AsNoTracking();
            }
            Query = Query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProp);
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return Query.FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.

        }

        public void Remove(T entity)
        {

            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
