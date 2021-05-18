using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ЛР__6_7
{
    [Serializable]
    public class Tenant
    {
        public Tenant(string room, string fullName, int course, int group)
        {
            Room = room ?? throw new ArgumentNullException(nameof(room));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Course = course;
            Group = group;
        }
        public Tenant()
        {

        }
        public string Room { get; set; }
        public string FullName { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }

        /// <summary>
        /// Поиск жильцов по некой информации, поиск осуществляется по всем полям
        /// </summary>
        /// <param name="Tenants">Список жильцов</param>
        /// <param name="Info">Некая строка для поиска по ней</param>
        /// <returns>Список совпадающих жильцов</returns>
        public static List<Tenant> Search(List<Tenant> Tenants, string Info)
        {
            List<Tenant> SearchedTenants = new List<Tenant>();
            foreach(var tenant in Tenants)
            {
                if (tenant.Consists(Info))
                    SearchedTenants.Add(tenant);
            }
            return SearchedTenants;
        }
        /// <summary>
        /// Сравнение всех полей экземпляра класса со строкой
        /// </summary>
        /// <param name="str">Строка для сравнения</param>
        /// <returns>Если хоть в одном поле содержится строка, то будет возвращено true</returns>
        private bool Consists(string str)
        {
            Type TenantType = typeof(Tenant);
            foreach(var info in TenantType.GetProperties())
                if (Regex.IsMatch(info.GetValue(this).ToString(), $@"^{str}\w*", RegexOptions.IgnoreCase))
                    return true;
            return false;
        }
    }
}
