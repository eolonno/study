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
using System.Data;
using System.IO;
using System.Collections;

namespace Lab_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;

        int flag;
        string sql = "SELECT * FROM Type";
        string sql1 = "SELECT * FROM Flight";
        string sql2 = "SELECT * FROM airbus";
        public MainWindow()
        {
            InitializeComponent();
            
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds,"type");
                DataGrid1.ItemsSource = ds.Tables["type"].DefaultView;
            }
        }

       
        


        private void butt_check(object sender, RoutedEventArgs e)
        {
            
            string sql = "SELECT * FROM Type";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds.Tables.Clear();
                adapter.Fill(ds,"type");
                
                DataGrid1.ItemsSource = ds.Tables["type"].DefaultView;
                DataGrid1.Columns[0].IsReadOnly = true;
            }
            flag = 0;
        }

        private void flightButton_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Flight";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds.Tables.Clear();
                adapter.Fill(ds,"Flight");

                DataGrid1.ItemsSource = ds.Tables["Flight"].DefaultView;
                DataGrid1.Columns[0].IsReadOnly = true;
            }
            flag = 1;
            
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                DataRow row = ds.Tables["type"].NewRow();
                ds.Tables["type"].Rows.Add(row);
            }
            if (flag == 1)
            {
                DataRow row = ds.Tables["Flight"].NewRow();
                ds.Tables["Flight"].Rows.Add(row);
            }
            if (flag == 2)
            {
                DataRow row = ds.Tables["Airbus"].NewRow();
                ds.Tables["Airbus"].Rows.Add(row);
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sql, connection);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = new SqlCommand("CreateType", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@nameType", SqlDbType.NVarChar, -1, "Название_типа"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@countSeats", SqlDbType.Int, 0, "ЧислоСидений"));



                    SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@id_type", SqlDbType.Int, 0, "id_type");
                    parameter.Direction = ParameterDirection.Output;

                    adapter.Update(ds.Tables["type"]);
                }
            }
            if (flag == 1)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sql1, connection);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = new SqlCommand("CreateFlight", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@travelTime", SqlDbType.NVarChar, -1, "TravelTime"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@id_airbus", SqlDbType.Int, 0, "id_airbus"));



                    SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@idFlight", SqlDbType.Int, 0, "idFlight");
                    parameter.Direction = ParameterDirection.Output;

                    adapter.Update(ds.Tables["Flight"]);
                }
            }
            if (flag == 2)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sql2, connection);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = new SqlCommand("CreateAirbus", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, -1, "Название"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@id_type", SqlDbType.Int, 0, "id_type"));



                    SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@idairbus", SqlDbType.Int, 0, "idairbus");
                    parameter.Direction = ParameterDirection.Output;

                    adapter.Update(ds.Tables["airbus"]);
                }
            }
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            flag = 3;
            string sql = "SELECT * FROM Type where ЧислоСидений= (select max(ЧислоСидений) from Type)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds.Tables.Clear();
                adapter.Fill(ds,"Max");

                DataGrid1.ItemsSource = ds.Tables["Max"].DefaultView;
                DataGrid1.Columns[0].IsReadOnly = true;
            }
        }

        private void AirbusButton_Click(object sender, RoutedEventArgs e)
        {
            
            string sql = "SELECT * FROM airbus";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds.Tables.Clear();
                adapter.Fill(ds, "airbus");

                DataGrid1.ItemsSource = ds.Tables["airbus"].DefaultView;
                DataGrid1.Columns[0].IsReadOnly = true;
            }
            flag = 2;
        }

       
        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            if(deleteWindow.ShowDialog() == true)
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = $"delete from airbus where Название=@AirName";
                    SqlCommand cmd = new SqlCommand(cmdText, sqlConnection);
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@AirName", deleteWindow.NameAirbus);
                    cmd.ExecuteNonQuery();

                }
                
            }
        }

        private void DeleteTypeButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            if(deleteWindow.ShowDialog() == true)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;
                    try
                    {
                        command.CommandText = "Delete from flight where id_airbus=(select id_airbus from airbus where id_type=(select id_type from type where Название_типа=@TypeName1))";
                        command.Parameters.AddWithValue("@TypeName1", deleteWindow.NameAirbus);
                        command.ExecuteNonQuery();
                        command.CommandText = "Delete from airbus where id_type=(select id_type from type where Название_типа=@TypeName)";
                        command.Parameters.AddWithValue("@TypeName", deleteWindow.NameAirbus);
                        command.ExecuteNonQuery();
                        command.CommandText = "Delete from type where Название_типа=@TypeName2";
                        command.Parameters.AddWithValue("@TypeName2", deleteWindow.NameAirbus);
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Данные удалены");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
            }
            }
           
        }
    }
}
