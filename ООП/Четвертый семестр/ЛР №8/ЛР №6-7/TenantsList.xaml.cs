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
    /// Логика взаимодействия для TenantsList.xaml
    /// </summary>
    public partial class TenantsList : Page
    {

        static List<Tenant> TenantsGlobal = new List<Tenant>();
        public TenantsList()
        {
            InitializeComponent();


            //for (int i = 0; i < 15; i++)
            //    TenantsGlobal.Add(new Tenant("201", "Лохов Лох Лохович", 2, 1));
            //List<Tenant> Tenants = new List<Tenant>(TenantsGlobal);
            //ListOfTenants.ItemsSource = Tenants;

            ListOfTenants.ItemsSource = Saver.ReadList();
        }
        /// <summary>
        /// Добавляет плейсхолдер поисковой строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
                SearchTextBox.Text = (string)Resources["Search"];
        }
        /// <summary>
        /// Удаляет плейсхолдер поисковой строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchRemovePlaceHolder(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Поиск..." || SearchTextBox.Text == "Search")
            {
                SearchTextBox.Text = "";
            }
        }
        /// <summary>
        /// Поиск при изменении строки поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Надо пофиксить этот костыль
            // В идеале нужно скрывать строки, которые не подходят
            // Через сеттеры и триггеры вроде делается, надо будет потом вернутсья
            if (TenantsGlobal.Count <= ((List<Tenant>)ListOfTenants.ItemsSource).Count)
                TenantsGlobal = (List<Tenant>)(ListOfTenants.ItemsSource);

            //foreach(var tenant in ListOfTenants.ItemsSource)
            //{
            //    if (!Tenant.Search(TenantsGlobal, ((TextBox)sender).Text).Contains(tenant))
            //        ListOfTenants.Items[ListOfTenants.Items.IndexOf(tenant)]
            //}

            if (string.IsNullOrEmpty(((TextBox)sender).Text))
                ListOfTenants.ItemsSource = TenantsGlobal;
            ListOfTenants.ItemsSource = Tenant.Search(TenantsGlobal, ((TextBox)sender).Text);
        }
        public void SaveList()
        {
            Saver.SaveList(ListOfTenants.ItemsSource as List<Tenant>);
        }
    }
}
