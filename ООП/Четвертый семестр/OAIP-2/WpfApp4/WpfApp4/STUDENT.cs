namespace WpfApp4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        [Key]
        [Column("Номер зачетки")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_зачетки { get; set; }

        [Required]
        [StringLength(50)]
        public string ФИО { get; set; }

        [Column("Дата рождения", TypeName = "date")]
        public DateTime Дата_рождения { get; set; }

        [Column("Пол (м/ж)")]
        [Required]
        [StringLength(1)]
        public string Пол__м_ж_ { get; set; }

        [Column("Дата поступления", TypeName = "date")]
        public DateTime Дата_поступления { get; set; }
    }
}
