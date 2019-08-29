using App.Core.CommandModels;
using App.Core.Contracts;
using App.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Core.Command
{
    public class AddToCartCmd : ICrudService<AddToCart>, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public AddToCartCmd(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(AddToCart model)
        {
            var cartCount = _dbContext.Carts.Where(n => n.UserId == model.UserId && n.CartId == model.CartId).Count() + 1;

            var cartModel = new Cart
            {
                CartId = model.CartId,
                AlbumId = model.AlbumId,
                Count = cartCount,
                DateCreated = System.DateTime.Now,
                UserId = model.UserId
            };

            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _dbContext.Carts.Add(cartModel);
                   
                    var updateCart = _dbContext.Carts.Where(n => n.UserId == model.UserId && n.CartId == model.CartId);
                    foreach (var items in updateCart)
                    {
                        items.Count = cartCount;
                    }
                    
                    _dbContext.SaveChanges();
                    tScope.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(AddToCart model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
