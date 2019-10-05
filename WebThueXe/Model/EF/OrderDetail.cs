namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int ID { get; set; }

        public int? CarId { get; set; }

        public DateTime PickUp { get; set; }

        public DateTime DropOff { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceSale { get; set; }

        public decimal? PriceTotal { get; set; }

        public decimal? IncludedVAT { get; set; }

        [StringLength(250)]
        public string OrderNote { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string PaymentMethod { get; set; }

        public bool? Status { get; set; }
    }
}
