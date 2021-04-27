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
using System.Threading;
using System.IO;
using System.ComponentModel;

namespace ЛР__6_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Cursor CursorArrow = new Cursor(Application.GetResourceStream(new Uri("pack://application:,,,/01_normal_select.cur")).Stream);
        TenantsList TenantsList = new TenantsList();
        LR8 LR8 = new LR8();
        public MainWindow()
        {
            InitializeComponent();

            Cursor = CursorArrow;

            //MainFrame.Content = TenantsList;
            MainFrame.Content = LR8;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            TenantsList.SaveList();
        }
        /// <summary>
        /// Переключение языка на русский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Russian(object sender, MouseButtonEventArgs e)
        {
            Resources.Clear();


            Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/ru-RU.xaml") });
        }
        /// <summary>
        /// Переключение языка на английский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void English(object sender, MouseButtonEventArgs e)
        {
            Resources.Clear();
            Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/en-US.xaml") });
        }


        ///// <summary>
        ///// Переключение языка на русский
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Russian(object sender, MouseButtonEventArgs e)
        //{
        //    Resources.Clear();

        //    if (SearchTextBox.Text == (string)Resources["Search"])
        //        SearchTextBox.Text = "";

        //    Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/ru-RU.xaml") });

        //    if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
        //        SearchTextBox.Text = (string)Resources["Search"];
        //}
        ///// <summary>
        ///// Переключение языка на английский
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void English(object sender, MouseButtonEventArgs e)
        //{
        //    Resources.Clear();

        //    if (SearchTextBox.Text == (string)Resources["Search"])
        //        SearchTextBox.Text = "";

        //    Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/en-US.xaml") });

        //    if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
        //        SearchTextBox.Text = (string)Resources["Search"];
        //}
    }
}
