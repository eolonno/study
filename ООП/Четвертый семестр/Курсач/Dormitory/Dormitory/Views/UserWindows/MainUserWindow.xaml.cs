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
using System.Windows.Shapes;
using Dormitory.Models;
using Dormitory.Frames.UserFrames;
using Dormitory.Data;

namespace Dormitory.Views.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        public MainUserWindow()
        {
            InitializeComponent();
            NicknameField.Text = DataWorker.User.Nickname;
        }

        private void OpenSignUpForDuty(object sender, MouseButtonEventArgs e)
        {
            TenantsDataGrid.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            RegOnDuty.Visibility = Visibility.Visible;
            AccountEdit.Visibility = Visibility.Collapsed;
        }

        private void OpenTenantsList(object sender, MouseButtonEventArgs e)
        {
            RegOnDuty.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            TenantsDataGrid.Visibility = Visibility.Visible;
            AccountEdit.Visibility = Visibility.Collapsed;
        }
        private void OpenDormitoryInfo(object sender, MouseButtonEventArgs e)
        {
            TenantsDataGrid.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Visible;
            RegOnDuty.Visibility = Visibility.Collapsed;
            AccountEdit.Visibility = Visibility.Collapsed;
        }
        private void OpenAccountEditing(object sender, MouseButtonEventArgs e)
        {
            TenantsDataGrid.Visibility = Visibility.Collapsed;
            RegOnDuty.Visibility = Visibility.Collapsed;
            DormitoryInfo.Visibility = Visibility.Collapsed;
            AccountEdit.Visibility = Visibility.Visible;
        }
        private void SignOut(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Close();
        }
    }
}
