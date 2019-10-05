using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThueXe.Models
{
    [Serializable]
    public class OrderDetail
    {
        public Car Car { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public decimal Price { set; get; }
        public decimal PriceSale { set; get; }
        public decimal PriceTotal { set; get; }
        public decimal IncludedVAT { set; get; }
        public DateTime PickUp { set; get; }
        public DateTime DropOff { set; get; }

    }
}