namespace OOP_Laba_9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Side
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Side_ID { get; set; }

        public int Game_ID { get; set; }

        public int Player_ID { get; set; }

        [StringLength(5)]
        public string Color { get; set; }

        public decimal? PointS { get; set; }

        public int? Draw { get; set; }

        public int? Resing { get; set; }
    }
}
