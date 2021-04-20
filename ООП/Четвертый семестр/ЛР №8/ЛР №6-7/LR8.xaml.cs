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

namespace ЛР__6_7
{
    /// <summary>
    /// Логика взаимодействия для LR8.xaml
    /// </summary>
    public partial class LR8 : Page
    {
        bool Theme = false;
        public LR8()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Theme == false)
            {
                Theme = true;
                SolidColorBrush BgColor = (SolidColorBrush)TryFindResource("BackgroundColor");
                BgColor.Color = Colors.LightPink;
            }
            else
            {
                Theme = false;
                SolidColorBrush BgColor = (SolidColorBrush)TryFindResource("BackgroundColor");
                BgColor.Color = Colors.White;
            }
        }
    }
}
