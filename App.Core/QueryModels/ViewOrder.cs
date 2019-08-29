using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.QueryModels
{
    public class ViewOrder
    {
        public DetailsOrder Order { get; set; }

        public List<DetailsOrderItems> OrderItems { get; set; }
    }
}
