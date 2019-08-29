using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.QueryModels
{
    public class OrderList
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int Total { get; set; }

        public decimal Price { get; set; }
    }
}
