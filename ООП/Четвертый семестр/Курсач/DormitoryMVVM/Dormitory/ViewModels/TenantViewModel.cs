using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dormitory.Models;
using Dormitory.Commands;
using System.Windows.Input;
using Dormitory.Models.Data;

namespace Dormitory.ViewModels
{
    public class TenantViewModel : ViewModelBase
    {
        public Tenant Tenant;
        public TenantViewModel(Tenant tenant)
        {
            Tenant = tenant;
        }
        public TenantViewModel() { }

        #region Свойства
        public int Id { get; set; }

        public string Name
        {
            get { return Tenant.Name; }
            set
            {
                Tenant.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string LastName 
        {
            get { return Tenant.LastName; }
            set
            {
                Tenant.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Patronymic
        {
            get { return Tenant.Patronymic; }
            set
            {
                Tenant.Patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        public string Sex
        {
            get { return Tenant.Sex; }
            set
            {
                Tenant.Sex = value;
                OnPropertyChanged("Sex");
            }
        }
        public int Room
        {
            get { return Tenant.Room; }
            set
            {
                Tenant.Room = value;
                OnPropertyChanged("Room");
            }
        }
        public int Course
        {
            get { return Tenant.Course; }
            set
            {
                Tenant.Course = value;
                OnPropertyChanged("Course");
            }
        }
        public int Group
        {
            get { return Tenant.Group; }
            set
            {
                Tenant.Group = value;
                OnPropertyChanged("Group");
            }
        }

        #endregion

        #region Поиск



        #endregion

        public static implicit operator Tenant(TenantViewModel tenant)
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
