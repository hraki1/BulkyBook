using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BullyBook_ECS.Data;
using BullyBook_ECS.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderDetail oderDetail)
        {
            _db.orderDetail.Update(oderDetail);
        }
    }
}

