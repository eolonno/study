using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.DB
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string FIO { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
