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
using Dormitory.Data;
using Dormitory.Models;

namespace Dormitory.Frames.UserFrames
{
    /// <summary>
    /// Логика взаимодействия для UserTenantsDataGridFrame.xaml
    /// </summary>
    public partial class UserTenantsDataGridFrame : UserControl
    {
        public List<Tenant> TenantsList { get; set; }
        public string SearchTextBoxText { get; set; }
        public UserTenantsDataGridFrame()
        {
            InitializeComponent();
            TenantsDataGrid.ItemsSource = TenantsList;
            TenantsList = DataWorker.GetAllTenants();
            RefreshDataGird();
        }
        private void RefreshDataGird()
        {
            TenantsDataGrid.ItemsSource = null;
            TenantsDataGrid.ItemsSource = TenantsList;
        }

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
                TenantsList = DataWorker.SearchTenantsByString(str);
                RefreshDataGird();
            }
        }
    }
}
