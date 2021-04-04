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
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty HourProperty;
        public static readonly DependencyProperty MinProperty;
        public static readonly DependencyProperty SecProperty;

        static UserControl1()
        {
            PropertyMetadata metadata = new PropertyMetadata(59);
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            SecProperty = DependencyProperty.Register("Seconds", typeof(int), typeof(UserControl1), metadata, new ValidateValueCallback(ValidateValue));
            PropertyMetadata metadata1 = new PropertyMetadata(59);
            metadata1.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            MinProperty = DependencyProperty.Register("Minutes", typeof(int), typeof(UserControl1), metadata1, new ValidateValueCallback(ValidateValue));
            PropertyMetadata metadata2 = new PropertyMetadata(23);
            metadata2.CoerceValueCallback = new CoerceValueCallback(CorrectValue2);
            HourProperty = DependencyProperty.Register("Hours", typeof(int), typeof(UserControl1), metadata2, new ValidateValueCallback(ValidateValue2));
         }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 59)
                return 0;
            return currentValue;
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0 && currentValue < 60)
                return true;
            return false;
        }

        private static object CorrectValue2(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 23)
                return 0;
            return currentValue;
        }

        private static bool ValidateValue2(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0 && currentValue < 24)
                return true;
            return false;
        }
        
        public int Hours
        {
            get { return (int)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        public int Minutes
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public int Seconds
        {
            get { return (int)GetValue(SecProperty); }
            set { SetValue(SecProperty, value); }
        }

        private int h = 0;
        private int m = 0;
        private int s = 0;

        private void HUpBtn_Click(object sender, RoutedEventArgs e)
        {
            HMore();
        }

        private void HDownBtn_Click(object sender, RoutedEventArgs e)
        {
            HLess();
        }

        private void HMore()
        {
            h = Convert.ToInt32(Hour.Text);
            h++;
            if (h >23) h = 0;
            Hour.Text = Convert.ToString(h);
        }

        private void HLess()
        {
            h = Convert.ToInt32(Hour.Text);
            h--;
            if (h < 0) h = 0;
            Hour.Text = Convert.ToString(h);
        }

        private void MUpBtn_Click(object sender, RoutedEventArgs e)
        {
            MMore();
        }

        private void MMore()
        {
            m = Convert.ToInt32(Min.Text);
            m++;
            if (m > 59) {
                m = 0;
                HMore();
            };
            Min.Text = Convert.ToString(m);
        }

        private void MDownBtn_Click(object sender, RoutedEventArgs e)
        {
            MLess();
        }

        private void MLess()
        {
            m = Convert.ToInt32(Min.Text);
            m--;
            if (m < 0) {
                m = 59;
                HLess();
            };
            Min.Text = Convert.ToString(m);
        }

        private void SUpBtn_Click(object sender, RoutedEventArgs e)
        {
            s = Convert.ToInt32(Sec.Text);
            s++;
            if (s > 59)
            {
                s = 0;
                MMore();
            };
            Sec.Text = Convert.ToString(s);
        }

        private void SDownBtn_Click(object sender, RoutedEventArgs e)
        {
            s = Convert.ToInt32(Sec.Text);
            s--;
            if (s < 0)
            {
                s = 59;
                MLess();
            };
            Sec.Text = Convert.ToString(s);
        }
    }
}
