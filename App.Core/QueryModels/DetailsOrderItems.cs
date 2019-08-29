using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.QueryModels
{
    public class DetailsOrderItems
    {
        public int OrderId { get; set; }

        public string Album { get; set; }

        public int AlbumId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
