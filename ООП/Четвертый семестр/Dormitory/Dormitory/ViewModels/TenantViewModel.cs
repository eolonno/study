using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dormitory.Models;
using Dormitory.Commands;
using System.Windows.Input;

namespace Dormitory.ViewModels
{
    class TenantViewModel : ViewModelBase
    {
        public Tenant Tenant;
        public TenantViewModel(Tenant tenant)
        {
            Tenant = tenant;
        }

        #region Свойства

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

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
        }

        #endregion
    }
}
