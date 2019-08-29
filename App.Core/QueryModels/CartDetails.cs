using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.QueryModels
{
    public class CartDetails
    {
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int AlbumId { get; set; }

        public string Album { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
