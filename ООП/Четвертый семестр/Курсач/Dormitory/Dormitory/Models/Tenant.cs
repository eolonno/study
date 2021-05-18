using System;
using System.Collections.Generic;
using System.Text;

namespace Dormitory.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public int Room { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
    }
}
