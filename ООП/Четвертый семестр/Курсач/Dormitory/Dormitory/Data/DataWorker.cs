using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dormitory.Models;
using System.Security.Cryptography;
using System.Reflection;

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
        public static List<Tenant> SearchTenantsByString(string str)
        {
            List<Tenant> SearchedTenants = new List<Tenant>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var tenant in db.Tenants)
                {
                    //Лучше переписать с рефлексией
                    if (tenant.Name.ToLower().Contains(str) ||
                           tenant.LastName.ToLower().Contains(str) ||
                           tenant.Patronymic.ToLower().Contains(str) ||
                           tenant.Room.ToString().Contains(str) ||
                           tenant.Group.ToString().Contains(str) ||
                           tenant.Sex.ToLower().Contains(str) ||
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

        public static User User { get; set; }
        public static User RegisterUser(string login, string password, string nickname)
        {
            try
            {
                Validator.ValidateLogin(login);
                Validator.ValidatePassword(password);
            }
            catch(ValidatingException ex)
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
                    throw new Exception("Неверно введен логин или пароль");
                else
                    return user.First();
            }
        }
        public static List<User> GetAllUsers()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Users.ToList();
            }
        }
        public static List<User> SearchUsersByString(string str)
        {
            List<User> Users = new List<User>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Login.ToLower().Contains(str) ||
                      user.Nickname.ToLower().Contains(str))
                        Users.Add(user);
                }
            }
            return Users;
        }
        public static void ChangePassword(string oldPass, string newPass)
        {
            try
            {
                Validator.ValidatePassword(newPass);
            }
            catch(ValidatingException ex)
            { throw ex; }

            string HashedPassword = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(newPass)));
            using(ApplicationContext db = new ApplicationContext())
            {
                if (User.Password != oldPass)
                    throw new Exception("Пароль введен неверно");
                User.Password = newPass;
                db.SaveChanges();
            }
        }
        public static void ChangeLogin(string oldLogin, string newLogin)
        {
            try
            {
                Validator.ValidateLogin(newLogin);
            }
            catch (ValidatingException ex)
            { throw ex; }

            using (ApplicationContext db = new ApplicationContext())
            {
                if (User.Login != oldLogin)
                    throw new Exception("Логин введен неверно");
                User.Login = newLogin;
                db.SaveChanges();
            }
        }

        #endregion

        #region Работа с дежурствами

        public static List<Duty> GetAllDuties()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Duties.ToList();
            }
        }
        public static void AddDuty(DateTime dateTime, string orderly)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Duties.Add(new Duty(dateTime, orderly));
                db.SaveChanges();
            }
        }
        public static void RemoveDuty(DateTime dateTime)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var duty = db.Duties.Where(x => x.TimeOfDuty == dateTime) as Duty;
                duty.Orderly = null;
                db.SaveChanges();
            }
        }
        public static void RefreshDutues(List<Duty> duties)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                foreach (var duty in db.Duties)
                    db.Duties.Remove(duty);
                foreach (var duty in duties)
                    db.Duties.Add(new Duty(duty.TimeOfDuty, duty.Orderly));
                db.SaveChanges();
            }
        }
        public static void AddDutyTime(DateTime dateTime)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Duties.Add(new Duty(dateTime, null));
                db.SaveChanges();
            }
        }
        public static void SignUpToDuty(Duty duty)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                foreach(var dutyinner in db.Duties)
                {
                    if (duty.TimeOfDuty == dutyinner.TimeOfDuty)
                        dutyinner.Orderly = User.Nickname;
                }
                db.SaveChanges();
            }
        }
        public static void SignUpToDutyForAdmin(Duty duty)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var dutyinner in db.Duties)
                {
                    if (duty.TimeOfDuty == dutyinner.TimeOfDuty)
                        dutyinner.Orderly = duty.Orderly;
                }
                db.SaveChanges();
            }
        }
        public static void RemoveDuty(Duty duty)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var dutyinner in db.Duties)
                {
                    if (duty.TimeOfDuty == dutyinner.TimeOfDuty)
                        dutyinner.Orderly = null;
                }
                db.SaveChanges();
            }
        }

        #endregion
    }
}
