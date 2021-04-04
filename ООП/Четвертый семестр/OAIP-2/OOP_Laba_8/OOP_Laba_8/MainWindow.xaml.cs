using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace OOP_Laba_8 {
  enum Tables { BOOK };
  enum PrimaryColumn { BOOK_ID };

  public partial class MainWindow : Window {
    int page_size = 5;
    int page_number = 0;

    string cur_table_name;
    string cur_prymary_col_name;

    string connectionString;

    DataSet ds;
    SqlDataAdapter adapter;
    SqlCommandBuilder command_builder;
    DataGrid cur_grid;
    List<Image> images;
    byte[ ] imageData;


    public MainWindow( ) {
      InitializeComponent( );

      this.connectionString = ConfigurationManager.ConnectionStrings[ "DefaultConnection" ].ConnectionString;
    }

    private void Window_Loaded( object sender, RoutedEventArgs e ) {
      FillCurrentGrid( );
    }

    private void SaveButton_Click( object sender, RoutedEventArgs e ) {
      try {
        using ( SqlConnection connection = new SqlConnection( this.connectionString ) ) {
          connection.Open( );

          this.adapter = new SqlDataAdapter( GetSql( ), connection );
          this.command_builder = new SqlCommandBuilder( this.adapter );

          if ( this.cur_table_name == Tables.BOOK.ToString( ) ) {

            this.adapter.InsertCommand = new SqlCommand( "sp_InsertBooks ", connection ) {
              CommandType = CommandType.StoredProcedure
            };

            this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_TYPE", SqlDbType.Int, 0, "BOOK_TYPE" ) );

            this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_NAME", SqlDbType.NVarChar, 50, "BOOK_NAME" ) );

            this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_AUTHOR", SqlDbType.NVarChar, 50, "BOOK_AUTHOR" ) );

            this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_SHORT_DESC", SqlDbType.NVarChar, 255, "BOOK_SHORT_DESC" ) );

            this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_COVER", SqlDbType.Image, 100000, "BOOK_COVER" ) );

          }

          //if ( this.currentTableName == Tables.Address.ToString( ) ) {
          //  this.adapter.InsertCommand = new SqlCommand( "sp_InsertAddress", connection ) {
          //    CommandType = CommandType.StoredProcedure
          //  };
          //  this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@StudentID", SqlDbType.Int, 0, "StudentID" ) );
          //  this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@Town", SqlDbType.NVarChar, 20, "Town" ) );
          //  this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@Index", SqlDbType.Int, 0, "[Index]" ) );
          //  this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@Street", SqlDbType.NVarChar, 30, "Street" ) );
          //  this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@House", SqlDbType.Int, 0, "House" ) );
          //  this.adapter.InsertCommand.Parameters.Add( new SqlParameter( "@Flat", SqlDbType.Int, 0, "Flat" ) );
          //}

          SqlParameter parameter = adapter.InsertCommand.Parameters.Add( "@BOOK_ID", SqlDbType.Int, 0, "BOOK_ID" );
          parameter.Direction = ParameterDirection.Output;

          this.cur_grid.CanUserAddRows = false;
          this.adapter.Update( this.ds );
        }
      }
      catch ( Exception ex ) {
        MessageBox.Show( ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK );
      }
    }

    private void UpdateButton_Click( object sender, RoutedEventArgs e ) {
      FillCurrentGrid( );
      this.cur_grid.CanUserAddRows = false;
    }

    private void BackButton_Click( object sender, RoutedEventArgs e ) {
      if ( this.page_number == 0 ) {
        return;
      }

      this.cur_grid.CanUserAddRows = false;
      this.page_number--;
      GetPage( );
    }

    private void NextButton_Click( object sender, RoutedEventArgs e ) {
      if ( this.ds.Tables[ 0 ].Rows.Count < this.page_size ) {
        return;
      }

      this.cur_grid.CanUserAddRows = false;
      this.page_size++;
      GetPage( );
    }

    private void DeleteButton_Click( object sender, RoutedEventArgs e ) {
      if ( this.cur_grid.SelectedItems != null ) {
        for ( int i = this.cur_grid.SelectedItems.Count - 1; i >= 0; i-- ) {
          if ( this.cur_grid.SelectedItems[ i ] is DataRowView datarowView ) {
            DataRow dataRow = datarowView.Row;
            dataRow.Delete( );
          }
        }
      }
    }

    private void AddButton_Click( object sender, RoutedEventArgs e ) {
      while ( !( this.ds.Tables[ 0 ].Rows.Count < this.page_size ) ) {
        this.page_number++;
        GetPage( );
      }
      this.cur_grid.CanUserAddRows = true;
    }



    private void MainTab_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
      try {
        TabItem item = ( TabItem )this.mainTab.SelectedItem;
        if ( this.cur_table_name != item.Header.ToString( ) ) {
          this.cur_table_name = item.Header.ToString( );

          if ( this.cur_table_name == Tables.BOOK.ToString( ) ) {
            this.cur_grid = this.StudentGrid;
            this.cur_prymary_col_name = PrimaryColumn.BOOK_ID.ToString( );
          }
          //if ( this.cur_table_name == Tables.Address.ToString( ) ) {
          //  this.cur_grid = this.AddressGrid;
          //  this.cur_prymary_col_name = PrimaryColumn.Id.ToString( );
          //}
          this.page_number = 0;
          FillCurrentGrid( );
        }
      }
      catch ( Exception ex ) {
        MessageBox.Show( ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK );
      }
    }

    private string GetSql( ) {
      return "SELECT * FROM " + this.cur_table_name + " ORDER BY " + this.cur_prymary_col_name + " OFFSET ((" + this.page_number + ") * " + this.page_size + ") " +
          "ROWS FETCH NEXT " + this.page_size + " ROWS ONLY";
    }

    private void GetPage( ) {
      try {
        using ( SqlConnection connection = new SqlConnection( this.connectionString ) ) {
          this.adapter = new SqlDataAdapter( GetSql( ), connection );
          this.ds.Tables[ 0 ].Rows.Clear( );
          this.adapter.Fill( this.ds.Tables[ 0 ] );
        }
      }
      catch ( Exception ex ) {
        MessageBox.Show( ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK );
      }
    }

    private void FillCurrentGrid( ) {

      using ( SqlConnection connection = new SqlConnection( this.connectionString ) ) {
        connection.Open( );
        this.adapter = new SqlDataAdapter( GetSql( ), connection );

        this.ds = new DataSet( );
        this.adapter.Fill( this.ds );
        this.cur_grid.ItemsSource = this.ds.Tables[ 0 ].DefaultView;

        // транзакция
        SqlTransaction transaction = connection.BeginTransaction( );
        SqlCommand command = connection.CreateCommand( );
        command.Transaction = transaction;
        try {
          command.CommandText = "select * from BOOK";
          command.ExecuteNonQuery( );

          transaction.Commit( );

        }
        catch ( Exception ex ) {
          MessageBox.Show( ex.Message );
          transaction.Rollback( );
        }
      }
    }

    private void DataGridTemplateColumn_MouseDown( object sender, MouseButtonEventArgs e ) {
      OpenFileDialog openDlg;

      openDlg = new OpenFileDialog( );
      openDlg.AddExtension = true;
      openDlg.CheckFileExists = true;
      openDlg.CheckPathExists = true;
      openDlg.DefaultExt = "png";
      openDlg.Filter = "(*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
      openDlg.Multiselect = false;

      string FilePath;

      if ( openDlg.ShowDialog( ) == true ) {
        FilePath = openDlg.FileName;

        
        using ( System.IO.FileStream fs = new System.IO.FileStream( FilePath, FileMode.Open ) ) {
          imageData = new byte[ fs.Length ];
          fs.Read( imageData, 0, imageData.Length );
        }

      }

    }

    public object ImageSource {
      get {
        BitmapImage image = new BitmapImage( );

        try {
          OpenFileDialog openDlg;


          openDlg = new OpenFileDialog( );
          openDlg.AddExtension = true;
          openDlg.CheckFileExists = true;
          openDlg.CheckPathExists = true;
          openDlg.DefaultExt = "png";
          openDlg.Filter = "(*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
          openDlg.Multiselect = false;

          image.BeginInit( );
          image.CacheOption = BitmapCacheOption.OnLoad;
          image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
          image.UriSource = new Uri( openDlg.FileName , UriKind.Absolute );
          image.EndInit( );
        }
        catch {
          return DependencyProperty.UnsetValue;
        }

        return image;
      }
    }

  }



  public class ImageConverter : IValueConverter {
    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture ) {
      return new BitmapImage( new Uri( value.ToString( ) ) );
    }

    public object ConvertBack(
        object value, Type targetType, object parameter, CultureInfo culture ) {
      throw new NotSupportedException( );
    }
  }
}