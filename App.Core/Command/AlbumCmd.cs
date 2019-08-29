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
    public class AlbumCmd : ICrudService<AlbumCrud>, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public AlbumCmd(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(AlbumCrud model)
        {
            var albumEntity = new Album
            {
                ArtistId = model.ArtistId,
                GenreId = model.GenreId,
                Title = model.Title,
                Price = model.Price,
                AlbumArtUrl = model.AlbumArtUrl
            };

            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _dbContext.Albums.Add(albumEntity);
                    _dbContext.SaveChanges();

                    tScope.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(AlbumCrud model)
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
