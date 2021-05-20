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
using Dormitory.Data;
using Dormitory.Models;
using Dormitory.Frames;

namespace Dormitory.Views
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }
        public void SwapRegOrAuth(bool isAuth)
        {
            MainGrid.Children.Clear();
            if (isAuth == true)
                MainGrid.Children.Add(new RegisterFrame());
            else
                MainGrid.Children.Add(new AuthFrame());
        }
    }
}
