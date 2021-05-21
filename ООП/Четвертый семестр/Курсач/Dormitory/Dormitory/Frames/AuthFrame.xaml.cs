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
using Dormitory.Views.AdminWindows;
using Dormitory.Views.UserWindows;
using Dormitory.Views;

namespace Dormitory.Frames
{
    /// <summary>
    /// Логика взаимодействия для AuthFrame.xaml
    /// </summary>
    public partial class AuthFrame
    {
        public AuthFrame()
        {
            InitializeComponent();
        }
        private void Auth(object sender, RoutedEventArgs e)
        {
            //    User user = DataWorker.AuthUser("user", "123");
            //    DataWorker.User = user;
            //    MainUserWindow mainUserWindow = new MainUserWindow();
            //    mainUserWindow.Show();
            try
            {
                User user = DataWorker.AuthUser(LoginTextBox.Text, PasswordPasswordBox.Password);
                DataWorker.User = user;
                if (user.Status == Status.Admin)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    MainUserWindow mainUserWindow = new MainUserWindow();
                    mainUserWindow.Show();
                    Window.GetWindow(this).Close();
                }
            }
            catch (ValidatingException ex)
            {
                PasswordPasswordBox.ToolTip = ex.Message;
                LoginTextBox.ToolTip = ex.Message;
                PasswordIcon.Foreground = Brushes.Red;
                AccountIcon.Foreground = Brushes.Red;
                PasswordPasswordBox.Foreground = Brushes.Red;
                LoginTextBox.Foreground = Brushes.Red;
                return;
            }
            catch (Exception ex)
            {
                PasswordPasswordBox.ToolTip = ex.Message;
                LoginTextBox.ToolTip = ex.Message;
                PasswordIcon.Foreground = Brushes.Red;
                AccountIcon.Foreground = Brushes.Red;
                PasswordPasswordBox.Foreground = Brushes.Red;
                LoginTextBox.Foreground = Brushes.Red;
            }
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (Window.GetWindow(this) as StartWindow).SwapRegOrAuth(true);
        }
    }
}
