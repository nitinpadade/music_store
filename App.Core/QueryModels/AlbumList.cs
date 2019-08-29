using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.QueryModels
{
    public class AlbumList
    {
        public int AlbumId { get; set; }

        public int GenreId { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public string Artist { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }
    }
}
