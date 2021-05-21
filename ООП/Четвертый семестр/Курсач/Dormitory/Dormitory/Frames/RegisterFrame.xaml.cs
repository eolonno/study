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
                    DataWorker.User = user;
                    new MainUserWindow().Show();
                    Window.GetWindow(this).Close();
                }
                catch(ValidatingException ex)
                {
                    if(ex.ValidatingErrorType == ValidatingErrorTypes.PassError)
                    {
                        PasswordPasswordBox.ToolTip = ex.Message;
                        PasswordRepeatedPasswordBox.ToolTip = ex.Message;
                        PasswordRepeatedPasswordBox.Foreground = Brushes.Red;
                        PasswordPasswordBox.Foreground = Brushes.Red;
                        RepeatedPasswordIcon.Foreground = Brushes.Red;
                        PasswordIcon.Foreground = Brushes.Red;
                    }
                    else
                    {
                        LoginTextBox.Foreground = Brushes.Red;
                        LoginTextBox.ToolTip = ex.Message;
                        LoginIcon.Foreground = Brushes.Red;
                    }
                }
            }
            else
            {
                PasswordRepeatedPasswordBox.Foreground = Brushes.Red;
                PasswordPasswordBox.Foreground = Brushes.Red;
                PasswordRepeatedPasswordBox.ToolTip = "Пароли не совпадают";
                PasswordPasswordBox.ToolTip = "Пароли не совпадают";
            }

        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (Window.GetWindow(this) as StartWindow).SwapRegOrAuth(false);
        }
    }
}
