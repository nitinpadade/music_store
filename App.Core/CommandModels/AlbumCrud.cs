using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CommandModels
{
    public class AlbumCrud
    {
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Please Select Genre")]
        [DisplayName("Genre:")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Please Select Artist")]
        [DisplayName("Artist:")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Please Provide Title")]
        [DisplayName("Title:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Provide Price")]
        [DisplayName("Price:")]
        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }

        public List<DropComandList> Genres { get; set; }

        public List<DropComandList> Artists { get; set; }
    }
}
