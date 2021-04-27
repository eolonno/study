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

namespace ЛР__9
{
    /// <summary>
    /// Логика взаимодействия для SpoilerControl.xaml
    /// </summary>
    public partial class SpoilerControl : UserControl
    {


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty;


        public string ButtonForShow
        {
            get { return (string)GetValue(ButtonForShowProperty); }
            set { SetValue(ButtonForShowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonForShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonForShowProperty;



        public string HideButton
        {
            get { return (string)GetValue(HideButtonProperty); }
            set { SetValue(HideButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HideButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HideButtonProperty;

        static SpoilerControl()
        {
            FrameworkPropertyMetadata ShowSpoilerMetadata = new FrameworkPropertyMetadata("Show Spoiler");
            FrameworkPropertyMetadata HideSpoilerMetadata = new FrameworkPropertyMetadata("Hide Spoiler");
            FrameworkPropertyMetadata TextMetadata = new FrameworkPropertyMetadata("");
            ShowSpoilerMetadata.CoerceValueCallback = new CoerceValueCallback(SpoilerFixing);
            HideSpoilerMetadata.CoerceValueCallback = new CoerceValueCallback(SpoilerFixing);

            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SpoilerControl), new PropertyMetadata(""));
            ButtonForShowProperty = DependencyProperty.Register("ButtonForShow", typeof(string), typeof(SpoilerControl), ShowSpoilerMetadata, new ValidateValueCallback(ValidateSpoilerName));
            HideButtonProperty = DependencyProperty.Register("HideButton", typeof(string), typeof(SpoilerControl), HideSpoilerMetadata, new ValidateValueCallback(ValidateSpoilerName));

        }

        public SpoilerControl()
        {
            InitializeComponent();
        }

        private void Spoiler_Click(object sender, RoutedEventArgs e)
        {
            if(spoilerGrid.Visibility == Visibility.Visible)
            {
                contentGrid.Visibility = Visibility.Visible;
                spoilerGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                contentGrid.Visibility = Visibility.Collapsed;
                spoilerGrid.Visibility = Visibility.Visible;
            }
        }
        private static bool ValidateSpoilerName(object value)
        {
            if (value.ToString().ToLower().Contains("спойлер") || value.ToString().ToLower().Contains("spoiler"))
                return true;
            else return false;
        }
        private static object SpoilerFixing(DependencyObject d, object baseValue)
        {
            if(!ValidateSpoilerName(baseValue))
                return baseValue.ToString() + " spoiler";
            return baseValue;
        }

    }
}
