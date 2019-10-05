namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Car")]
    public partial class Car
    {
        public int ID { get; set; }

        public int? AgencyId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? ProvinceId { get; set; }

        public DateTime? PickUp { get; set; }

        public DateTime? DropOff { get; set; }

        [StringLength(250)]
        public string Brand { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(500)]
        [AllowHtml]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? IncludedVAT { get; set; }

        public decimal? PriceSale { get; set; }

        public decimal? PriceTotal { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string Rate { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public long? CategoryID { get; set; }

        public DateTime? TopHot { get; set; }

        public int? CountReview { get; set; }
    }
}
