namespace LR9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flats
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? House { get; set; }

        public int Rooms { get; set; }

        public int Meters { get; set; }

        public virtual Houses Houses { get; set; }
    }
}
