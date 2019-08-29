using App.Core.Contracts;
using App.Core.QueryModels;
using App.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Core.Command
{
    public class SubmitOrderCmd : IOrderService, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        public readonly ICartService _cartService;
        bool disposed = false;

        public SubmitOrderCmd(MusicStoreDataContext dbContext, ICartService cartService)
        {
            _dbContext = dbContext;
            _cartService = cartService;
        }

        public int Save(SubmitOrder model)
        {
            int orderId = 0;
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var order = SetOrder(model);
                    _dbContext.Orders.Add(order);
                    _cartService.ClearCart(LoginUserInfo.UserId, LoginUserInfo.CartId);
                    model.OrderId = order.OrderId;

                    _dbContext.SaveChanges();
                    tScope.Complete();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return orderId;
            }
        }        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects here.
                _dbContext.Dispose();
            }

            // Free unmanaged objects here.
            disposed = true;
        }

        public Order SetOrder(SubmitOrder model)
        {
            var total = model.CartDetails.Select(n => n.Price).Sum();
            var orderDetails = model.CartDetails.Select(n => new OrderDetail
            {
                AlbumId = n.AlbumId,
                Quantity = 1,
                UnitPrice = n.Price
            }).ToList();

            return new Order
            {
                OrderDate = System.DateTime.Now,
                Username = LoginUserInfo.Name,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                Email = model.Email,
                UserId = LoginUserInfo.UserId,
                Total = total,
                OrderDetails = orderDetails
            };
        }


    }
}
