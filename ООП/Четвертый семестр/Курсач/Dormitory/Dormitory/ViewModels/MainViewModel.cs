using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dormitory.Models;

namespace Dormitory.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TenantViewModel> TenantsList { get; set; }

        #region Конструкторы

        public MainViewModel(List<Tenant> Tenants)
        {
            TenantsList = new ObservableCollection<TenantViewModel>(Tenants.Select(b => new TenantViewModel(b)));
        }

        public MainViewModel()
        { }

        #endregion
    }
}
