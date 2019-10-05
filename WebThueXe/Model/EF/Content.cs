namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Content")]
    public partial class Content
    {
        public int ID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public bool Status { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        [StringLength(500)]
        [AllowHtml]
        public string Description { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }
    }
}
