namespace Лаба12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zakaz")]
    public partial class Zakaz
    {
        [Key]
        public int ids { get; set; }

        [StringLength(15)]
        public string namesss { get; set; }

        public double? cost { get; set; }

        [StringLength(10)]
        public string client { get; set; }

        [StringLength(150)]
        public string Photo { get; set; }
    }
}
