namespace OOP_Laba_9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        [Key]
        public int Game_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string FEN { get; set; }

        [Required]
        [StringLength(4)]
        public string Game_Status { get; set; }
    }
}
