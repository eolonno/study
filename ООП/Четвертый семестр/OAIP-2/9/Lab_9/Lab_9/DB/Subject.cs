using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.DB
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string FIOl { get; set; }
        public int Hours { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
