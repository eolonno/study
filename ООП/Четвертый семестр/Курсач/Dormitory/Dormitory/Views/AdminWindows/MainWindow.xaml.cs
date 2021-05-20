using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Dormitory.Views.AdminWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NicknameField.Text = DataWorker.User.Nickname;
        }
        private void OpenUsersList(object sender, MouseButtonEventArgs e)
        {
            UsersDataGrid.Visibility = Visibility.Visible;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            EditAccount.Visibility = Visibility.Collapsed;
            TenantsDataGrid.Visibility = Visibility.Visible;
            DutiesList.Visibility = Visibility.Collapsed;
        }

        private void OpenTenantsList(object sender, MouseButtonEventArgs e)
        {
            UsersDataGrid.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            EditAccount.Visibility = Visibility.Collapsed;
            TenantsDataGrid.Visibility = Visibility.Visible;
            DutiesList.Visibility = Visibility.Collapsed;
        }
        private void OpenDormitoryInfo(object sender, MouseButtonEventArgs e)
        {
            TenantsDataGrid.Visibility = Visibility.Collapsed;
            EditAccount.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Visible;
            UsersDataGrid.Visibility = Visibility.Collapsed;
            DutiesList.Visibility = Visibility.Collapsed;
        }
        private void OpenAccountEditing(object sender, MouseButtonEventArgs e)
        {
            TenantsDataGrid.Visibility = Visibility.Collapsed;
            EditAccount.Visibility = Visibility.Visible;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            UsersDataGrid.Visibility = Visibility.Collapsed;
            DutiesList.Visibility = Visibility.Collapsed;
        }
        private void OpenDutiesList(object sender, MouseButtonEventArgs e)
        {
            TenantsDataGrid.Visibility = Visibility.Collapsed;
            EditAccount.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            UsersDataGrid.Visibility = Visibility.Collapsed;
            DutiesList.Visibility = Visibility.Visible;
        }
        private void SignOut(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Close();
        }
    }
}
