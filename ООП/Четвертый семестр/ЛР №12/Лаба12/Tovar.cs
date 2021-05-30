namespace Лаба12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tovar")]
    public partial class Tovar
    {
        [Key]
        [StringLength(15)]
        public string names { get; set; }

        [StringLength(15)]
        public string typess { get; set; }

        public double? cost { get; set; }

        [StringLength(25)]
        public string info { get; set; }
    }
}
