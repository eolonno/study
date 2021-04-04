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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Globalization;

namespace LR8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder command_builder;
        List<Image> images;
        byte[] imageData;

        int page_size = 5;
        int page_number = 0;

        string cur_primary_col_name = "Houses.ID";

        public MainWindow()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCurrentGrid();
        }

        private void FillCurrentGrid()
        {

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                this.adapter = new SqlDataAdapter(GetSql(), connection);

                this.ds = new DataSet();
                this.adapter.Fill(this.ds);
                this.cur_grid.ItemsSource = this.ds.Tables[0].DefaultView;

                // транзакция
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "SELECT * FROM Houses JOIN Flats ON Houses.Id = Flats.HouseID";
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        private string GetSql()
        {
            return "SELECT * FROM Houses JOIN Flats ON Houses.Id = Flats.HouseID ORDER BY " + this.cur_primary_col_name ;
        }



        public class ImageConverter : IValueConverter
        {
            public object Convert(
                object value, Type targetType, object parameter, CultureInfo culture)
            {
                return new BitmapImage(new Uri(value.ToString()));
            }

            public object ConvertBack(
                object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }

    }
}

