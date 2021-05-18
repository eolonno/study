using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dormitory.Models;
using Dormitory.Data;
using System.Linq;

namespace Dormitory.Frames.AdminFrames
{
    /// <summary>
    /// Логика взаимодействия для TenantsDataGridFrame.xaml
    /// </summary>
    public partial class TenantsDataGridFrame : UserControl
    {
        public List<Tenant> TenantsList { get; set; }

        public TenantsDataGridFrame()
        {
            InitializeComponent();
            TenantsList = DataWorker.GetAllTenants();
            TenantsDataGrid.ItemsSource = TenantsList;

            TenantsDataGrid.SelectedCellsChanged += TenantsDataGrid_SelectedCellsChanged;
            TenantsDataGrid.AddingNewItem += TenantsDataGrid_AddingNewItem; 
        }

        #region Изменение списка жильцов

        private void TenantsDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            //DataWorker.CreateTenantByInstance(e.NewItem as Tenant);
            DataWorker.RefreshAllTenants(TenantsList);
        }

        private void TenantsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataWorker.RefreshAllTenants(TenantsList);
        }

        #endregion

        private void SearchMethod(object sender, TextChangedEventArgs e)
        {
            string str = (sender as TextBox).Text;
            if (String.IsNullOrEmpty(str))
            {
                TenantsList = DataWorker.GetAllTenants();
                RefreshDataGird();
            }
            else
            {
                TenantsList = DataWorker.SearchByString(str);
                RefreshDataGird();
            }
        }
        private void RefreshDataGird()
        {
            TenantsDataGrid.ItemsSource = null;
            TenantsDataGrid.ItemsSource = TenantsList;
        }
    }
}
