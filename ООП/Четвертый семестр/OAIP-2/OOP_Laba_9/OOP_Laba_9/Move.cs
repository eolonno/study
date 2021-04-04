namespace OOP_Laba_9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Move
    {
        [Key]
        public int Move_ID { get; set; }

        public int Game_ID { get; set; }

        public int Player_ID { get; set; }

        public int? Ply { get; set; }

        [Required]
        [StringLength(60)]
        public string FEN { get; set; }

        [StringLength(10)]
        public string MoveNext { get; set; }
    }
}
