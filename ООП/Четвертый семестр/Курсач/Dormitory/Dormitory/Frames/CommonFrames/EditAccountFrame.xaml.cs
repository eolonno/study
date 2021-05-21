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

namespace Dormitory.Frames.CommonFrames
{
    /// <summary>
    /// Логика взаимодействия для EditAccount.xaml
    /// </summary>
    public partial class EditAccountFrame : UserControl
    {
        private User user { get; set; }
        public EditAccountFrame()
        {
            InitializeComponent();
            user = DataWorker.User;
            AccountName.Text = user.Nickname + "#" + user.Id;
        }
        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            if(PasswordPasswordBox.Password == NewPasswordPasswordBox.Password)
            {
                PasswordPasswordBox.Foreground = Brushes.Red;
                NewPasswordPasswordBox.Foreground = Brushes.Red;
                RepeatedPasswordIcon.Foreground = Brushes.Red;
                PasswordIcon.Foreground = Brushes.Red;
                PasswordPasswordBox.ToolTip = "Пароли совпадают";
                NewPasswordPasswordBox.ToolTip = "Пароли совпадают";
            }
            else
            {
                try
                {
                    DataWorker.ChangePassword(PasswordPasswordBox.Password, NewPasswordPasswordBox.Password);
                    MessageBox.Show("Пароль успешно изменен");
                    PasswordPasswordBox.Foreground = Brushes.Black;
                    NewPasswordPasswordBox.Foreground = Brushes.Black;
                    RepeatedPasswordIcon.Foreground = Brushes.Black;
                    PasswordIcon.Foreground = Brushes.Black;
                    PasswordPasswordBox.Password = "";
                    NewPasswordPasswordBox.Password = "";
                    PasswordPasswordBox.ToolTip = "";
                    NewPasswordPasswordBox.ToolTip = "";
                }
                catch(ValidatingException ex)
                {
                    PasswordPasswordBox.Foreground = Brushes.Red;
                    NewPasswordPasswordBox.Foreground = Brushes.Red;
                    RepeatedPasswordIcon.Foreground = Brushes.Red;
                    PasswordIcon.Foreground = Brushes.Red;
                    PasswordPasswordBox.ToolTip = ex.Message;
                    NewPasswordPasswordBox.ToolTip = ex.Message;
                }
                catch(Exception ex)
                {
                    PasswordPasswordBox.Foreground = Brushes.Red;
                    PasswordIcon.Foreground = Brushes.Red;
                    PasswordPasswordBox.ToolTip = ex.Message;
                }
            }
        }
        private void ChangeLogin(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == NewLoginTextBox.Text)
            {
                LoginTextBox.Foreground = Brushes.Red;
                NewLoginTextBox.Foreground = Brushes.Red;
                NewLoginIcon.Foreground = Brushes.Red;
                LoginIcon.Foreground = Brushes.Red;
                LoginTextBox.ToolTip = "Логины совпадают";
                NewLoginTextBox.ToolTip = "Логины совпадают";
            }
            else
            {
                try
                {
                    DataWorker.ChangeLogin(LoginTextBox.Text, NewLoginTextBox.Text);
                    MessageBox.Show("Логин успешно изменен");
                    LoginTextBox.Foreground = Brushes.Black;
                    NewLoginTextBox.Foreground = Brushes.Black;
                    NewLoginIcon.Foreground = Brushes.Black;
                    LoginIcon.Foreground = Brushes.Black;
                    LoginTextBox.ToolTip = "";
                    NewLoginTextBox.ToolTip = "";
                    LoginTextBox.Text = "";
                    NewLoginTextBox.Text = "";
                }
                catch (ValidatingException ex)
                {
                    LoginTextBox.Foreground = Brushes.Red;
                    NewLoginTextBox.Foreground = Brushes.Red;
                    NewLoginIcon.Foreground = Brushes.Red;
                    LoginIcon.Foreground = Brushes.Red;
                    LoginTextBox.ToolTip = ex.Message;
                    NewLoginTextBox.ToolTip = ex.Message;
                }
                catch (Exception ex)
                {
                    LoginTextBox.Foreground = Brushes.Red;
                    LoginIcon.Foreground = Brushes.Red;
                    LoginTextBox.ToolTip = ex.Message;
                }
            }
        }
    }
}
