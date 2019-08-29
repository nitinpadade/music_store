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
    public class StoreQry : IStoreService, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public StoreQry(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GenreList> GetGenreList()
        {
            return _dbContext.Genres.Select(n => new GenreList
                {
                    Id = n.GenreId,
                    Name = n.Name
                }).OrderByDescending(n => n.Id).ToList();
        }

        public List<AlbumList> GetAlbumList(int genreId)
        {
            if (genreId > 0)
            {
                return _dbContext.Albums.Where(n => n.GenreId == genreId).Select(n => new AlbumList
                {
                    AlbumId = n.AlbumId,
                    GenreId = n.GenreId,
                    Genre = n.Genre.Name,
                    ArtistId = n.ArtistId,
                    Artist = n.Artist.Name,
                    Title = n.Title,
                    Price = n.Price,
                    AlbumArtUrl = n.AlbumArtUrl
                }).OrderByDescending(n => n.AlbumId).ToList();
            }
            else
            {
                return _dbContext.Albums.Select(n => new AlbumList
                {
                    AlbumId = n.AlbumId,
                    GenreId = n.GenreId,
                    Genre = n.Genre.Name,
                    ArtistId = n.ArtistId,
                    Artist = n.Artist.Name,
                    Title = n.Title,
                    Price = n.Price,
                    AlbumArtUrl = n.AlbumArtUrl
                }).OrderByDescending(n => n.AlbumId).ToList();
            }
        }

        public AlbumList GetAlbum(int albumId)
        {
            return _dbContext.Albums.Where(n => n.AlbumId == albumId).Select(n => new AlbumList
            {
                AlbumId = n.AlbumId,
                GenreId = n.GenreId,
                Genre = n.Genre.Name,
                ArtistId = n.ArtistId,
                Artist = n.Artist.Name,
                Title = n.Title,
                Price = n.Price,
                AlbumArtUrl = n.AlbumArtUrl
            }).FirstOrDefault();
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
