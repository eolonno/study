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

namespace L3.Условная_энтропия
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "";

            for (double p = 0.1; p < 0.9; p += 0.1)
            {
                double q = 1 - p;
                double entrUsl = -1 * (p * Math.Log(p, 2) + q * Math.Log(q, 2));

                str += "p = " + p + "; Условная энтропия = " + (Math.Round(entrUsl, 2)).ToString() + "\n";
            }

            MessageBox.Show(str);
        }
    }
}
