using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitory.Models
{
    internal class Tenant
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public int Room { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        
    }
}
