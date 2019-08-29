using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CommandModels
{
    public class AddToCart
    {
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int AlbumId { get; set; }

        public int Count { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserId { get; set; }
    }
}
