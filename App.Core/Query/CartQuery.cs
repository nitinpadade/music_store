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
    public class CartQuery : ICartService, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public CartQuery(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CartCount(int userId, string cartId)
        {
            return _dbContext.Carts.Where(n => n.UserId == userId && n.CartId == cartId).Count();
        }

        public void ClearCart(int userId, string cartId)
        {
            var cart = _dbContext.Carts.Where(n => n.CartId == cartId && n.UserId == userId);

            foreach (var items in cart)
            {
                _dbContext.Carts.Remove(items);
            }
            _dbContext.SaveChanges();
        }

        public List<CartDetails> ViewCart(int userId, string cartId)
        {
            return _dbContext.Carts.Where(n => n.CartId == cartId && n.UserId == userId).Select(n => new CartDetails
            {
                AlbumId = n.AlbumId,
                Album = n.Album.Title,
                CartId = n.CartId,
                RecordId = n.RecordId,
                Genre = n.Album.Genre.Name,
                Price = n.Album.Price
            }).ToList();
        }

        public void RemoveFromCart(int recordId)
        {
            var cart = _dbContext.Carts.Where(n => n.RecordId == recordId).FirstOrDefault();
            _dbContext.Carts.Remove(cart);
            _dbContext.SaveChanges();
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
