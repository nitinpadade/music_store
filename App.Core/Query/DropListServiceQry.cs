using App.Core.CommandModels;
using App.Core.Contracts;
using App.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Query
{
    public class DropListServiceQry : IDropListService
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public DropListServiceQry(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DropComandList> Genres()
        {
            return _dbContext.Genres.Select(n => new DropComandList { Id = n.GenreId, Name = n.Name }).ToList();
        }

        public List<DropComandList> Artists()
        {
            return _dbContext.Artists.Select(n => new DropComandList { Id = n.ArtistId, Name = n.Name }).ToList();
        }
    }
}
