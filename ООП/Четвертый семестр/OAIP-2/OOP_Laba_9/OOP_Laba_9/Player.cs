namespace OOP_Laba_9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Player
    {
        [Key]
        public int Player_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Password { get; set; }
    }
}
