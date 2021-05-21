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
        private bool isSorted { get; set; }

        public TenantsDataGridFrame()
        {
            InitializeComponent();
            TenantsList = DataWorker.GetAllTenants();
            TenantsDataGrid.ItemsSource = TenantsList;
            isSorted = false;

            TenantsDataGrid.SelectedCellsChanged += TenantsDataGrid_SelectedCellsChanged;
            TenantsDataGrid.AddingNewItem += TenantsDataGrid_AddingNewItem; 
        }

        #region Изменение списка жильцов

        private void TenantsDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            //DataWorker.CreateTenantByInstance(e.NewItem as Tenant);
            DataWorker.RefreshAllTenants(TenantsList, isSorted);
        }

        private void TenantsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataWorker.RefreshAllTenants(TenantsList, isSorted);
        }

        #endregion

        private void SearchMethod(object sender, TextChangedEventArgs e)
        {
            string str = (sender as TextBox).Text;
            if (String.IsNullOrEmpty(str) || str == "")
            {
                TenantsList = DataWorker.GetAllTenants();
                TenantsDataGrid.Columns[7].Visibility = Visibility.Visible;
                isSorted = false;
                RefreshDataGird();
            }
            else
            {
                TenantsList = DataWorker.SearchTenantsByString(str);
                TenantsDataGrid.Columns[7].Visibility = Visibility.Hidden;
                isSorted = true;
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
