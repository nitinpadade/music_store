using App.Core.Contracts;
using App.Core.QueryModels;
using App.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Query
{
    public class OrdersQry : IOrdersQuery, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public OrdersQry(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderList> GetOrders(int userId)
        {
            return _dbContext.Orders.Where(n => n.UserId == userId).Select(n => new OrderList
            {
                OrderId = n.OrderId,
                OrderDate = n.OrderDate,
                Total = n.OrderDetails.Count(),
                Price = n.Total
            }).ToList();
        }

        public ViewOrder OrderView(int orderId)
        {

            var order = _dbContext.Orders.Where(n => n.OrderId == orderId).Select(n => new DetailsOrder
            {
                Name = n.FirstName + " " + n.LastName,
                Address = n.Address,
                City = n.City,
                Country = n.Country,
                Email = n.Email,
                OrderId = n.OrderId,
                Phone = n.Phone,
                PostalCode = n.PostalCode,
                State = n.State,
                OrderDate = n.OrderDate
            }).FirstOrDefault();

            var orderItems = _dbContext.OrderDetails.Where(n => n.OrderId == orderId).Select(n => new DetailsOrderItems
            {
                Album = n.Album.Title,
                AlbumId = n.AlbumId,
                OrderId = n.OrderId,
                Price = n.UnitPrice,
                Quantity = n.Quantity
            }).ToList();


            return new ViewOrder
            {
                Order = order,
                OrderItems = orderItems
            };
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



    }
}
