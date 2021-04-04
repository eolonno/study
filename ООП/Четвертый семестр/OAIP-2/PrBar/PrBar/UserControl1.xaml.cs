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

namespace PrBar
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double),
                    typeof(UserControl1), new FrameworkPropertyMetadata(OnValueChanged));
        protected static DependencyProperty AuxiliaryPointProperty = DependencyProperty.Register("AuxiliaryPoint",
                    typeof(Point), typeof(UserControl1));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        protected Point AuxiliaryPoint
        {
            get => (Point)GetValue(AuxiliaryPointProperty);
            set => SetValue(AuxiliaryPointProperty, value);
        }

        static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myProgress = (UserControl1)d;
            var value = (double)e.NewValue;
            var angle = Math.PI * value / 100;
            var x = 100 - 100 * Math.Cos(angle);
            var y = 100 - 100 * Math.Sin(angle);
            myProgress.AuxiliaryPoint = new Point(x, y);
        }



    }
}
