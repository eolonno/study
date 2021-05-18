using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dormitory.Models;
using System.Security.Cryptography;

namespace Dormitory.Data
{
    public static class DataWorker
    {
        #region Работа с жильцами

        public static List<Tenant> GetAllTenants()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var AllTenants = db.Tenants.ToList();

                return AllTenants;
            }
        }
        public static bool CreateTenant(string Name, string LastName, string Patronymic, string Sex, int Room, int Course, int Group)
        {
            bool result = false;

            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIfExist = db.Tenants.Any(e => e.Name == Name && e.LastName == LastName && e.Patronymic == Patronymic);
                if (!checkIfExist)
                {
                    Tenant tenant = new Tenant()
                    {
                        Name = Name,
                        LastName = LastName,
                        Patronymic = Patronymic,
                        Sex = Sex,
                        Room = Room,
                        Course = Course,
                        Group = Group
                    };
                    db.Tenants.Add(tenant);
                    db.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        public static bool CreateTenantByInstance(Tenant tenant)
        {
            bool result = false;

            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIfExist = db.Tenants.Any(e => e.Name == tenant.Name && e.LastName == tenant.LastName && e.Patronymic == tenant.Patronymic);
                if (!checkIfExist)
                {
                    db.Tenants.Add(tenant);
                    db.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        public static bool DeleteTenant(Tenant tenant)
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Tenants.Remove(tenant);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
        public static bool EditTenant(Tenant oldTenant, string Name, string LastName, string Patronymic, string Sex, int Room, int Course, int Group)
        {
            bool result = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                Tenant tenant = db.Tenants.FirstOrDefault(t => ((Tenant)t).Id == oldTenant.Id);
                if (tenant != null)
                {
                    tenant.Name = Name;
                    tenant.LastName = LastName;
                    tenant.Patronymic = Patronymic;
                    tenant.Room = Room;
                    tenant.Sex = Sex;
                    tenant.Group = Group;
                    tenant.Course = Course;
                    result = true;
                }
            }
            return result;
        }
        public static List<Tenant> SearchByString(string str)
        {
            List<Tenant> SearchedTenants = new List<Tenant>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var tenant in db.Tenants)
                {
                    //Лучше переписать с рефлексией
                    if (tenant.Name.Contains(str) ||
                           tenant.LastName.Contains(str) ||
                           tenant.Patronymic.Contains(str) ||
                           tenant.Room.ToString().Contains(str) ||
                           tenant.Group.ToString().Contains(str) ||
                           tenant.Sex.Contains(str) ||
                           tenant.Course.ToString().Contains(str))
                        SearchedTenants.Add(tenant);
                }
            }
            return SearchedTenants;

        }
        public static void RefreshAllTenants(List<Tenant> tenants)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var tenant in db.Tenants)
                    db.Tenants.Remove(tenant);
                foreach (var tenant in tenants)
                    CreateTenant(tenant.Name, tenant.LastName, tenant.Patronymic, tenant.Sex, tenant.Room, tenant.Course, tenant.Group);
                db.SaveChanges();
            }
        }
        #endregion

        #region Работа с пользователями
        public static User RegisterUser(string login, string password, string nickname)
        {
            try
            {
                Validator.ValidateString(login);
                Validator.ValidateString(nickname);
                Validator.ValidatePassword(password);
            }
            catch(Exception ex)
            { throw ex; }
            
            string HashedPassword = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
            User user = new User(login, HashedPassword, nickname);
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return user;
        }
        public static User AuthUser(string login, string password)
        {
            string HashedPassword = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.Where(u => u.Password == HashedPassword && u.Login == login);
                if (user.Count() == 0)
                    return null;
                else
                    return user.First();
            }
        }

        #endregion
    }
}
