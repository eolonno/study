using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace LR8 {
  /// <summary>
  /// Логика взаимодействия для SecondWindow.xaml
  /// </summary>
  public partial class SecondWindow : Window {

    int page_size = 5;
    int page_number = 0;

    string connectionString;
    SqlDataAdapter adapter;
    DataTable flatsTable;

    public int houseID { get; set; }

    public SecondWindow(int houseID) {
      InitializeComponent();

      this.houseID = houseID;
      connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=LR8;integrated security=True;";
      flatsGrid.RowEditEnding += FlatsGrid_RowEditEnding;
    }

    private void FlatsGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
      UpdateDB();
    }

    private void Window_Loaded1(object sender, RoutedEventArgs e) {
      flatsTable = new DataTable();
      SqlConnection connection = null;
      try {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand command = connection.CreateCommand();
        command.Transaction = transaction;

        try {
          command.CommandText = GetSql(houseID);
          command.ExecuteNonQuery();
          transaction.Commit();
        } catch (Exception ex) {
          MessageBox.Show(ex.Message);
          transaction.Rollback();
        }

        adapter = new SqlDataAdapter(command);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

        // установка команды на добавление для вызова хранимой процедуры        
        adapter.InsertCommand = new SqlCommand("sp_InsertFlats", connection);
        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
        adapter.InsertCommand.Parameters.Add(new SqlParameter("@House", houseID));
        adapter.InsertCommand.Parameters.Add(new SqlParameter("@FlatNum", SqlDbType.Int, 0, "FlatNum"));
        adapter.InsertCommand.Parameters.Add(new SqlParameter("@Meters", SqlDbType.Int, 0, "Meters"));
        adapter.InsertCommand.Parameters.Add(new SqlParameter("@Rooms", SqlDbType.Int, 0, "Rooms"));
        SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
        parameter.Direction = ParameterDirection.Output;

        adapter.Fill(flatsTable);
        flatsGrid.ItemsSource = flatsTable.DefaultView;
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      } finally {
        if (connection != null)
          connection.Close();
      }
    }

    private void AddButton_Click1(object sender, RoutedEventArgs e) {
      while (!(flatsTable.Rows.Count < page_size)) {
        page_number++;
        GetPage();
      }
      flatsGrid.CanUserAddRows = true;
    }

    private void UpdateDB() {
      SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
      adapter.Update(flatsTable);
    }

    private void updateButton_Click1(object sender, RoutedEventArgs e) {
      UpdateDB();
      GetPage();
      flatsGrid.CanUserAddRows = false;
    }

    private void deleteButton_Click1(object sender, RoutedEventArgs e) {
      if (flatsGrid.SelectedItems != null) {
        for (int i = 0; i < flatsGrid.SelectedItems.Count; i++) {
          DataRowView datarowView = flatsGrid.SelectedItems[i] as DataRowView;
          if (datarowView != null) {
            DataRow dataRow = (DataRow)datarowView.Row;
            dataRow.Delete();
          }
        }
      }
      UpdateDB();
    }

    private void BackButton_Click1(object sender, RoutedEventArgs e) {
      if (page_number == 0) {
        return;
      }
      flatsGrid.CanUserAddRows = false;
      page_number--;
      GetPage();
    }

    private void NextButton_Click1(object sender, RoutedEventArgs e) {
      if (flatsTable.Rows.Count < page_size) {
        return;
      }
      flatsGrid.CanUserAddRows = false;
      page_number++;
      GetPage();
    }

    private string GetSql(int id) {
      return "SELECT * FROM Flats where House = " + id + " ORDER BY ID OFFSET ((" + page_number + ") * " + page_size + ") " +
          "ROWS FETCH NEXT " + page_size + " ROWS ONLY";
    }

    private void GetPage() {
      try {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand(GetSql(houseID), connection);
        adapter = new SqlDataAdapter(command);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

        flatsTable.Rows.Clear();

        adapter.Fill(flatsTable);
        flatsGrid.ItemsSource = flatsTable.DefaultView;
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
      }
    }

  }
}
