using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
using Microsoft.Win32;

namespace LR8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        int page_size = 5;
        int page_number = 0;

        string connectionString;
        SqlDataAdapter adapter;
        DataTable housesTable;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=LR8;integrated security=True;";
            housesGrid.RowEditEnding += HousesGrid_RowEditEnding;

        }

        private void HousesGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int count = 0;
            string createDBsql = "USE master;" +
            "create database LR8;";
            string createTableSql =
            "USE LR8;" +
            "create table Houses (" +
            "ID int constraint Houses_pk primary key identity(0, 1)," +
            "City nvarchar(30)," +
            "Street nvarchar(30)," +
            "House nvarchar(30)," +
            "Map nvarchar(255)" +
            ")" +
            "create table Flats (" +
            "ID int constraint Flats_pk primary key identity(0, 1)," +
            "House int constraint Flats_Houses_fk foreign key references Houses(ID) on delete cascade," +
            "FlatNum int," +
            "Meters int," +
            "Rooms int" +
            ")";

            string createProcedure = "CREATE PROCEDURE sp_InsertHouses " +
    "@City nvarchar(30), " +
    "@Street nvarchar(30), " +
    "@House nvarchar(30), " +
    "@Map nvarchar(255), " +
    "@Id int out " +
"AS " +
"INSERT INTO Houses(City, Street, House, Map) " +
"VALUES(@City, @Street, @House, @Map) " +
"SET @Id = SCOPE_IDENTITY()";

            string createProcedure2 = "CREATE PROCEDURE sp_InsertFlats " +
               "@House int, " +
                "@FlatNum int, " +
              "@Meters int, " +
        "@Rooms int, " +
       "@Id int out " +
      "AS " +
      "INSERT INTO Flats(House, FlatNum, Meters, Rooms) " +
      "VALUES(@House, @FlatNum, @Meters, @Rooms) " +
      "SET @Id = SCOPE_IDENTITY()";

            string connectionStringStart = @"Data Source=.\SQLEXPRESS;initial catalog=master;integrated security=True;";

            string sqlExpression = "select count(*) from sysdatabases where name = 'LR8'";
            using (SqlConnection connection = new SqlConnection(connectionStringStart))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    //try
                    //{
                        SqlCommand command_1 = new SqlCommand(createDBsql, connection);
                        command_1.ExecuteNonQuery();

                        SqlCommand command_2 = new SqlCommand(createTableSql, connection);
                        command_2.ExecuteNonQuery();

                        SqlCommand command_3 = new SqlCommand(createProcedure, connection);
                        command_3.ExecuteNonQuery();

                        SqlCommand command_4 = new SqlCommand(createProcedure2, connection);
                        command_4.ExecuteNonQuery();

                        count = 1;
                    //}
                    //catch (Exception exp)
                    //{
                    //    MessageBox.Show(exp.Message);
                    //}
                }
            }

            if (count == 1)
            {
                housesTable = new DataTable();
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = GetSql();
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }

                    adapter = new SqlDataAdapter(command);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    // установка команды на добавление для вызова хранимой процедуры        
                    adapter.InsertCommand = new SqlCommand("sp_InsertHouses", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30, "City"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30, "Street"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@House", SqlDbType.NVarChar, 30, "House"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@Map", SqlDbType.NVarChar, 255, "Map"));
                    SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                    parameter.Direction = ParameterDirection.Output;

                    adapter.Fill(housesTable);
                    housesGrid.ItemsSource = housesTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            while (!(housesTable.Rows.Count < page_size))
            {
                page_number++;
                GetPage();
            }
            housesGrid.CanUserAddRows = true;
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(housesTable);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
            GetPage();
            housesGrid.CanUserAddRows = false;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (housesGrid.SelectedItems != null)
            {
                for (int i = 0; i < housesGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = housesGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openDlg;

                openDlg = new OpenFileDialog();
                openDlg.AddExtension = true;
                openDlg.CheckFileExists = true;
                openDlg.CheckPathExists = true;
                openDlg.DefaultExt = "png";
                openDlg.Filter = "(*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
                openDlg.Multiselect = false;

                string FilePath;

                if (openDlg.ShowDialog() == true)
                {
                    FilePath = openDlg.FileName;
                    BitmapImage img = new BitmapImage(new Uri(FilePath, UriKind.Absolute));
                    ((DataRowView)housesGrid.SelectedItems[0]).Row["Map"] = img;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (page_number == 0)
            {
                return;
            }
            housesGrid.CanUserAddRows = false;
            page_number--;
            GetPage();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (housesTable.Rows.Count < page_size)
            {
                return;
            }
            housesGrid.CanUserAddRows = false;
            page_number++;
            GetPage();
        }

        private string GetSql()
        {
            return "SELECT * FROM Houses ORDER BY ID OFFSET ((" + page_number + ") * " + page_size + ") " +
                "ROWS FETCH NEXT " + page_size + " ROWS ONLY";
        }

        private void GetPage()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(GetSql(), connection);
                adapter = new SqlDataAdapter(command);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                housesTable.Rows.Clear();

                adapter.Fill(housesTable);
                housesGrid.ItemsSource = housesTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecondWindow window = new SecondWindow((int)((DataRowView)housesGrid.SelectedItems[0]).Row["ID"]);
            window.Show();
        }
    }
}
