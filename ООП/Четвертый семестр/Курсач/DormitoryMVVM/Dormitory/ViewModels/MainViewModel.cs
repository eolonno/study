using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Dormitory.Models;
using Dormitory.Models.Data;

namespace Dormitory.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TenantViewModel> TenantsList { get; set; }

        #region Конструкторы

        public MainViewModel()
        {
            TenantsList = new ObservableCollection<TenantViewModel>(DataWorker.GetAllTenants().Select(b => new TenantViewModel(b)));
            TenantsList.Add(new TenantViewModel(new Tenant(){ Name = "1", LastName = "2", Course = 2, Group = 2, Room = 202, Sex = "m", Patronymic = "3"}));
            TenantsList.Add(new TenantViewModel(new Tenant(){ Name = "1", LastName = "2", Course = 2, Group = 2, Room = 202, Sex = "m", Patronymic = "3"}));
        }

        #endregion

        #region Свойства

        #endregion
    }
}
