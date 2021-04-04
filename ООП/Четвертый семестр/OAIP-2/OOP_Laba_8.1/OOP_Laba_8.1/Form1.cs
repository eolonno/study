using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOP_Laba_8._1 {
  public partial class Form1 : Form {

    int pageSize = 5; // размер страницы
    int pageNumber = 0; // текущая страница

    DataSet ds;
    SqlDataAdapter adapter;
    SqlCommandBuilder commandBuilder;
    string connectionString = @"data source=LAPTOP-KT-ILICH;initial catalog=OOP_LABA;integrated security=True;";
    string sql = "SELECT * FROM BOOK";

    public Form1( ) {
      InitializeComponent( );

      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dataGridView1.AllowUserToAddRows = false;

      using ( SqlConnection connection = new SqlConnection( connectionString ) ) {
        connection.Open( );
        adapter = new SqlDataAdapter( sql, connection );

        ds = new DataSet( );
        adapter.Fill( ds );
        dataGridView1.DataSource = ds.Tables[ 0 ];
        // делаем недоступным столбец id для изменения
        dataGridView1.Columns[ "BOOK_ID" ].ReadOnly = true;
      }

    }
    // кнопка добавления
    private void addButton_Click( object sender, EventArgs e ) {
      DataRow row = ds.Tables[ 0 ].NewRow( ); // добавляем новую строку в DataTable
      ds.Tables[ 0 ].Rows.Add( row );
    }
    // кнопка удаления
    private void deleteButton_Click( object sender, EventArgs e ) {
      // удаляем выделенные строки из dataGridView1
      foreach ( DataGridViewRow row in dataGridView1.SelectedRows ) {
        dataGridView1.Rows.Remove( row );
      }
    }
    // кнопка сохранения
    private void saveButton_Click( object sender, EventArgs e ) {
      using ( SqlConnection connection = new SqlConnection( connectionString ) ) {
        connection.Open( );
        adapter = new SqlDataAdapter( sql, connection );
        commandBuilder = new SqlCommandBuilder( adapter );
        adapter.InsertCommand = new SqlCommand( "sp_InsertBooks", connection );
        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
        adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_TYPE", SqlDbType.Int, 0, "BOOK_TYPE" ) );

        adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_NAME", SqlDbType.NVarChar, 50, "BOOK_NAME" ) );

        adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_AUTHOR", SqlDbType.NVarChar, 50, "BOOK_AUTHOR" ) );

        adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_SHORT_DESC", SqlDbType.NVarChar, 255, "BOOK_SHORT_DESC" ) );

        adapter.InsertCommand.Parameters.Add( new SqlParameter( "@BOOK_COVER", SqlDbType.Image, 100000, "BOOK_COVER" ) );

        SqlParameter parameter = adapter.InsertCommand.Parameters.Add( "@BOOK_ID", SqlDbType.Int, 0, "BOOK_ID" );
        parameter.Direction = ParameterDirection.Output;

        adapter.Update( ds );
      }
    }

    private void NextButton_Click( object sender, EventArgs e ) {
      if ( ds.Tables[ 0 ].Rows.Count < pageSize ) return;

      pageNumber++;
      using ( SqlConnection connection = new SqlConnection( connectionString ) ) {
        adapter = new SqlDataAdapter( GetSql( ), connection );

        ds.Tables[ 0 ].Rows.Clear( );

        adapter.Fill( ds, "BOOK" );
      }
    }

    private void PrevButton_Click( object sender, EventArgs e ) {
      if ( pageNumber == 0 ) return;
      pageNumber--;

      using ( SqlConnection connection = new SqlConnection( connectionString ) ) {
        adapter = new SqlDataAdapter( GetSql( ), connection );

        ds.Tables[ "BOOK" ].Rows.Clear( );

        adapter.Fill( ds, "BOOK" );
      }
    }

    private string GetSql( ) {
      return "SELECT * FROM BOOK ORDER BY BOOK_ID OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
          "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
    }

  }
}