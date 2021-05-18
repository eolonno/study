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
using System.Linq;
using Dormitory.Data;
using Dormitory.Models;
using Dormitory.Views.UserWindows;
using Dormitory.Views;

namespace Dormitory.Frames
{
    /// <summary>
    /// Логика взаимодействия для RegisterFrame.xaml
    /// </summary>
    public partial class RegisterFrame : UserControl
    {
        public List<string> NicknameList { get; set; }
        public RegisterFrame()
        {
            InitializeComponent();
            NicknameList = new List<string>(DataWorker.GetAllTenants().Select(x => x.LastName + " " + x.Name + " " + x.Patronymic));
            NicknameComboBox.ItemsSource = NicknameList;
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            if (PasswordPasswordBox.Password == PasswordRepeatedPasswordBox.Password)
            {
                try
                {
                    User user = DataWorker.RegisterUser(LoginTextBox.Text, PasswordPasswordBox.Password, NicknameComboBox.Text);
                    new MainUserWindow(user).Show();
                    Window.GetWindow(this).Close();
                }
                catch(Exception ex)
                {
                    //Разобраться как вызвать ошибку в Material Design
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Passwords do not compare error
                MessageBox.Show("Пароли не совпадают");
            }

        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (Window.GetWindow(this) as StartWindow).SwapRegOrAuth(false);
        }
    }
}
