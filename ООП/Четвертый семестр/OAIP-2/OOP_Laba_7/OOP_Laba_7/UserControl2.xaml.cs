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

namespace OOP_Laba_7
{
    /// <summary>
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void display_cls(object sender, RoutedEventArgs e)
        {
            display.Clear();
        }

        private void btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            display.Text = display.Text + "sender: " + sender.ToString() + "\n";
            display.Text = display.Text + "source: " + e.Source.ToString() + "\n\n";
        }


    }
}
