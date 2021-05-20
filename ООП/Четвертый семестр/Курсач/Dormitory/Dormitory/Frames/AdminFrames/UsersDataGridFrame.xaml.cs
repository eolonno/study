using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Dormitory.Data;
using Dormitory.Models;

namespace Dormitory.Frames.AdminFrames
{
    /// <summary>
    /// Логика взаимодействия для UsersDataGrid.xaml
    /// </summary>
    public partial class UsersDataGridFrame : UserControl
    {
        public List<User> UsersList {get; set;}
        public UsersDataGridFrame()
        {
            InitializeComponent();
            UsersList = DataWorker.GetAllUsers();
            UsersDataGrid.ItemsSource = UsersList;
        }
        private void SearchMethod(object sender, TextChangedEventArgs e)
        {
            string str = (sender as TextBox).Text;
            if (String.IsNullOrEmpty(str))
            {
                UsersList = DataWorker.GetAllUsers();
                RefreshDataGird();
            }
            else
            {
                UsersList = DataWorker.SearchUsersByString(str);
                RefreshDataGird();
            }
        }
        private void RefreshDataGird()
        {
            UsersDataGrid.ItemsSource = null;
            UsersDataGrid.ItemsSource = UsersList;
        }
    }
}
