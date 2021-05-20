using System;
using System.Collections.Generic;
using System.Text;

namespace Dormitory.Models
{
    public class Duty
    {
        public Duty(DateTime timeOfDuty, string orderly)
        {
            TimeOfDuty = timeOfDuty;
            Orderly = orderly;
        }

        public int Id { get; set; }
        public DateTime TimeOfDuty { get; set; }
        public string? Orderly { get; set; }
    }
}
