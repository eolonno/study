using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Dormitory.Models;
using System.Linq;
using Dormitory.ViewModels;
using System.Collections.Specialized;


namespace Dormitory.Models.Data
{
    public static class DataWorker
    {
        #region Получить всех жильцов

        public static List<TenantViewModel> GetAllTenants()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var AllTenants = db.Tenants.ToList();

                return AllTenants;
            }
        }

        #endregion

        #region Создать жильца

        public static string CreateTenant(string Name, string LastName, string Patronymic, string Sex, int Room, int Course, int Group)
        {
            string result = "Уже существует";

            using(ApplicationContext db = new ApplicationContext())
            {
                bool checkIfExist = db.Tenants.Any(e => e.Name == Name && e.LastName == LastName && e.Patronymic == Patronymic);
                if(!checkIfExist)
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
                    result = "Сделано!";
                }
            }

            return result;
        }

        #endregion

        #region Удалить жильца

        public static string DeleteTenant(Tenant tenant)
        {
            string result = "Такого жильца не существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Tenants.Remove(tenant);
                db.SaveChanges();
                result = "Жилец выселен";
            }
            return result;
        }

        #endregion

        #region Редактировать жильца

        public static string EditTenant(Tenant oldTenant, string Name, string LastName, string Patronymic, string Sex, int Room, int Course, int Group)
        {
            string result = "Такого жильца не существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                Tenant tenant = db.Tenants.FirstOrDefault(t => ((Tenant)t).Id == oldTenant.Id);
                if(tenant != null)
                {
                    tenant.Name = Name;
                    tenant.LastName = LastName;
                    tenant.Patronymic = Patronymic;
                    tenant.Room = Room;
                    tenant.Sex = Sex;
                    tenant.Group = Group;
                    tenant.Course = Course;
                    result = "Сотрудник" + LastName + " " + Name + " " + Patronymic + " изменен";
                }
            }
            return result;
        }

        #endregion

        #region Поиск по строке

        public static List<Tenant> SearchByString(string str)
        {
            List<Tenant> SearchedTenants = new List<Tenant>();
            using(ApplicationContext db = new ApplicationContext())
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

        #endregion

        #region Обновить всех жильцов

        public static void RefreshAllTenants(ObservableCollection<Tenant> tenants)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(var tenant in db.Tenants)
                    db.Tenants.Remove(tenant);
                foreach (var tenant in tenants)
                    CreateTenant(tenant.Name, tenant.LastName, tenant.Patronymic, tenant.Sex, tenant.Room, tenant.Course, tenant.Group);
                db.SaveChanges();
            }
        }



        #endregion
    }
}
