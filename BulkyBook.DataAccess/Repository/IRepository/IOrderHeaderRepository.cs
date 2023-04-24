using BulkyBook.Models;
using BullyBook_ECS.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
		

	
        void UpdateStatus(int Id, string sessionId, string? PaymentItentId=null);
		void UpdateStripePaymentID(int Id,string orderStatus,string? paymentStatus=null);
    }
}
