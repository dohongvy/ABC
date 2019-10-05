using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    class CarViewModel
    {
        public int ID { set; get; }
        public string Images { set; get; }
        public string Name { set; get; }
        public decimal? Price { get; set; }

        public decimal? PriceSale { get; set; }

        public decimal? PriceTotal { get; set; }
        public decimal? IncludedVAT { get; set; }
        public string Address { get; set; }
        public int? Rate { get; set; }

    }
}
