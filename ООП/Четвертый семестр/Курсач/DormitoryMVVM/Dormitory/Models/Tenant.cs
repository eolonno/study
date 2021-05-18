using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitory.ViewModels;

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

        public static implicit operator TenantViewModel(Tenant tenant)
        {
            TenantViewModel tenantView = new TenantViewModel()
            {
                Name = tenant.Name,
                LastName = tenant.LastName,
                Patronymic = tenant.Patronymic,
                Sex = tenant.Sex,
                Room = tenant.Room,
                Course = tenant.Course,
                Group = tenant.Group
            };
            return tenantView;
        }


    }
}
