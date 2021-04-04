using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace WpfApp1 {
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {    

    int page_size = 5;
    int page_number = 0;

    string connectionString;
    SqlDataAdapter adapter;
    DataTable housesTable;    

    public MainWindow() {
      InitializeComponent();
      connectionString = @"Server=localhost;Integrated security=SSPI;database=LR8";
      phonesGrid.RowEditEnding += PhonesGrid_RowEditEnding;

    }

    private void PhonesGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {      
      UpdateDB();      
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      string sql = "SELECT * FROM Houses";
      housesTable = new DataTable();
      SqlConnection connection = null;
      try {
        connection = new SqlConnection(connectionString);
        connection.Open();        

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand command = connection.CreateCommand();
        command.Transaction = transaction;

        try {
          command.CommandText = GetSql();
          command.ExecuteNonQuery();
          transaction.Commit();
        } catch (Exception ex) {
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
        phonesGrid.ItemsSource = housesTable.DefaultView;
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      } finally {
        if (connection != null)
          connection.Close();
      }
    }

    private void AddButton_Click(object sender, RoutedEventArgs e) {
      while (!(housesTable.Rows.Count < page_size)) {
        page_number++;
        GetPage();
      }
      phonesGrid.CanUserAddRows = true;
    }

    private void UpdateDB() {
      SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
      adapter.Update(housesTable);      
    }

    private void updateButton_Click(object sender, RoutedEventArgs e) {
      UpdateDB();
      GetPage();
      phonesGrid.CanUserAddRows = false;
    }

    private void deleteButton_Click(object sender, RoutedEventArgs e) {
      if (phonesGrid.SelectedItems != null) {
        for (int i = 0; i < phonesGrid.SelectedItems.Count; i++) {
          DataRowView datarowView = phonesGrid.SelectedItems[i] as DataRowView;
          if (datarowView != null) {
            DataRow dataRow = (DataRow)datarowView.Row;
            dataRow.Delete();
          }
        }
      }
      UpdateDB();
    }



    private void Button_Click(object sender, RoutedEventArgs e) {
      try {
        OpenFileDialog openDlg;

        openDlg = new OpenFileDialog();
        openDlg.AddExtension = true;
        openDlg.CheckFileExists = true;
        openDlg.CheckPathExists = true;
        openDlg.DefaultExt = "png";
        openDlg.Filter = "(*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
        openDlg.Multiselect = false;

        string FilePath;

        if (openDlg.ShowDialog() == true) {
          FilePath = openDlg.FileName;
          BitmapImage img = new BitmapImage(new Uri(FilePath, UriKind.Absolute));
          ((DataRowView)phonesGrid.SelectedItems[0]).Row["Map"] = img;
        }
      } catch (Exception exp) {
        MessageBox.Show(exp.Message);
      }
    }


    private void BackButton_Click(object sender, RoutedEventArgs e) {
      if (page_number == 0) {
        return;
      }
      phonesGrid.CanUserAddRows = false;
      page_number--;
      GetPage();
    }

    private void NextButton_Click(object sender, RoutedEventArgs e) {
      if (housesTable.Rows.Count < page_size) {
        return;
      }
      phonesGrid.CanUserAddRows = false;
      page_number++;
      GetPage();
    }

    private string GetSql() {
      return "SELECT * FROM Houses ORDER BY ID OFFSET ((" + page_number + ") * " + page_size + ") " +
          "ROWS FETCH NEXT " + page_size + " ROWS ONLY";
    }

    private void GetPage() {
      try {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand(GetSql(), connection);
        adapter = new SqlDataAdapter(command);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

        housesTable.Rows.Clear();        

        adapter.Fill(housesTable);
        phonesGrid.ItemsSource = housesTable.DefaultView;
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
      }
    }

  }
}





//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using Microsoft.Win32;

//namespace WpfApp1 {
//  /// <summary>
//  /// Логика взаимодействия для MainWindow.xaml
//  /// </summary>
//  public partial class MainWindow : Window {
//    //static string connectionString = @"Server=localhost;Integrated security=SSPI;database=Test228";

//    //public MainWindow() {
//    //  InitializeComponent();

//    //  string sql = "SELECT * FROM ttable";
//    //  using (SqlConnection connection = new SqlConnection(connectionString)) {
//    //    connection.Open();
//    //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
//    //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

//    //    // устанавливаем команду на вставку
//    //    adapter.InsertCommand = new SqlCommand("sp_InsertTest", connection);
//    //    // это будет зранимая процедура
//    //    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
//    //    // добавляем параметр для name
//    //    adapter.InsertCommand.Parameters.Add(new SqlParameter("@Map", SqlDbType.NVarChar, 255, "Map"));
//    //    // добавляем параметр для age
//    //    adapter.InsertCommand.Parameters.Add(new SqlParameter("@MapData", SqlDbType.VarBinary, 0, "MapData"));
//    //    // добавляем выходной параметр для id
//    //    SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "id");
//    //    parameter.Direction = ParameterDirection.Output;

//    //    DataSet ds = new DataSet();
//    //    adapter.Fill(ds);

//    //    DataTable dt = housesTable;

//    //    byte[] imageData;
//    //    using (FileStream fs = new FileStream(@"D:\gg\LR8\LR8\LR8\Images\GrodnoDzerzhinskogo15.png", FileMode.Open)) {
//    //      imageData = new byte[fs.Length];
//    //      fs.Read(imageData, 0, imageData.Length);
//    //    }

//    //    // добавим новую строку
//    //    DataRow newRow = dt.NewRow();
//    //    newRow["Map"] = @"D:\gg\LR8\LR8\LR8\Images\GrodnoDzerzhinskogo15.png";
//    //    newRow["MapData"] = imageData;
//    //    dt.Rows.Add(newRow);

//    //    adapter.Update(ds);
//    //    ds.AcceptChanges();

//    //  }

//    //}

//    string connectionString;
//    SqlDataAdapter adapter;
//    DataTable housesTable;
//    DataSet ds;
//    int curIndex = -1;
//    bool isEdit = false;

//    public MainWindow() {
//      InitializeComponent();
//      connectionString = @"Server=localhost;Integrated security=SSPI;database=LR8";
//      phonesGrid.RowEditEnding += PhonesGrid_RowEditEnding;

//    }

//    private void PhonesGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
//      isEdit = true;
//      UpdateDB();
//      isEdit = false;
//    }

//    private void Window_Loaded(object sender, RoutedEventArgs e) {
//      string sql = "SELECT * FROM Houses";
//      housesTable = new DataTable();
//      SqlConnection connection = null;
//      try {
//        connection = new SqlConnection(connectionString);
//        connection.Open();
//        SqlCommand command = new SqlCommand(sql, connection);
//        adapter = new SqlDataAdapter(command);
//        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);



//        // установка команды на добавление для вызова хранимой процедуры        
//        adapter.InsertCommand = new SqlCommand("sp_InsertHouses", connection);
//        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
//        adapter.InsertCommand.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30, "City"));
//        adapter.InsertCommand.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30, "Street"));
//        adapter.InsertCommand.Parameters.Add(new SqlParameter("@House", SqlDbType.NVarChar, 30, "House"));
//        adapter.InsertCommand.Parameters.Add(new SqlParameter("@Map", SqlDbType.NVarChar, 255, "Map"));
//        SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
//        parameter.Direction = ParameterDirection.Output;

//        ds = new DataSet();
//        adapter.Fill(ds);

//        phonesGrid.ItemsSource = housesTable.DefaultView;
//      } catch (Exception ex) {
//        MessageBox.Show(ex.Message);
//      } finally {
//        if (connection != null)
//          connection.Close();
//      }
//    }

//    private void AddButton_Click(object sender, RoutedEventArgs e) {
//      phonesGrid.CanUserAddRows = true;
//    }

//    private void UpdateDB() {
//      SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
//      adapter.Update(ds);
//      ds.AcceptChanges();
//    }

//    private void updateButton_Click(object sender, RoutedEventArgs e) {
//      UpdateDB();
//    }

//    private void deleteButton_Click(object sender, RoutedEventArgs e) {
//      if (phonesGrid.SelectedItems != null) {
//        for (int i = 0; i < phonesGrid.SelectedItems.Count; i++) {
//          DataRowView datarowView = phonesGrid.SelectedItems[i] as DataRowView;
//          if (datarowView != null) {
//            DataRow dataRow = (DataRow)datarowView.Row;
//            dataRow.Delete();
//          }
//        }
//      }
//      UpdateDB();
//    }

//    private void phonesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
//      curIndex = ((DataGrid)sender).SelectedIndex;
//    }


//    private void Button_Click(object sender, RoutedEventArgs e) {
//      try {
//        OpenFileDialog openDlg;

//        openDlg = new OpenFileDialog();
//        openDlg.AddExtension = true;
//        openDlg.CheckFileExists = true;
//        openDlg.CheckPathExists = true;
//        openDlg.DefaultExt = "png";
//        openDlg.Filter = "(*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
//        openDlg.Multiselect = false;

//        string FilePath;

//        if (openDlg.ShowDialog() == true) {
//          FilePath = openDlg.FileName;
//          BitmapImage img = new BitmapImage(new Uri(FilePath, UriKind.Absolute));
//          ((DataRowView)phonesGrid.SelectedItems[0]).Row["Map"] = img;
//        }
//      } catch (Exception exp) {
//        MessageBox.Show(exp.Message);
//      }
//    }

//  }


//}
