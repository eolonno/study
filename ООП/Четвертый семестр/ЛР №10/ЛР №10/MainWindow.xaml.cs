using System;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Windows;

namespace ЛР__10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Tables { Student, Address };
        enum PrimaryColumn { ID, Id };

        int pageSize = 5;
        int pageNumber = 0;

        string currentTableName;
        string currentPrimaryColumnName;
        string connectionString;


        DataSet ds;                     ///предст.полный набор д-х, включая таблицы и связи между ними
        SqlDataAdapter adapter;         ///чтобы заполнить DataSet
        SqlCommandBuilder commandBuilder;
        DataGrid currentGrid;           ///ЭУ, позв. отобр и ред д-е из различ.источников(БД SQL)
        List<Image> images;

        public DataGrid accountsGrid { get; private set; }

        string createTables()
        {
            return "use University; " +
                "create table Student( " +
                    "ID int primary key identity(100, 1), " +
                    "NAME nvarchar(100) not null, " +
                    "SPECIALITY nvarchar(200) not null, " +
                    "AGE int check(AGE between 17 and 40) not null, " +
                    "BIRTHDAY date not null, " +
                    "COURSE int check(COURSE between 1 and 5) not null, " +
                    "SEX nchar(1) check(SEX in ('м', 'ж')) not null, " +
                    "AVGSCORE float check(AVGSCORE between 4 and 10) not null, " +
                    "FOTO varbinary(max) default null" +
                ") " +
                "create table[Address]( " +
                    "ID int primary key identity(1,1), " +
                    "StudentID int foreign key references[Student](ID), " +
                    "Town nvarchar(20) not null, " +
                    "[Index] int check([Index] between 100000 and 999999) not null, " +
                    "Street nvarchar(30) not null, " +
                    "House int check(House between 1 and 1000) not null, " +
                    "Flat int check(Flat between 1 and 2000) null" +
                ")";
        }
        string createDB()
        {
            return "use master create database University";
        }
        string Insert()
        {
            return
                "use University; " +
                "insert into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE, FOTO) values " +
                    "('Амбразевич Владимир Сергеевич', 'Программное обеспечение информационных технологий', 23, '04-06-2000', 2, 'м', 8.0, null), " +
                    "('Чистякова Юлия Алекандровна', 'Программное обеспечение информационных технологий', 20, '10-07-1998', 2, 'ж', 8.0, null), " +
                    "('Докурно Вадим Сергеевич', 'Информационные системы и технологии', 19, '12-07-1997', 3, 'м', 7.0, null), " +
                    "('Каспер Наталья Викторовна', 'Дизайн электронных и веб-изданий', 18, '12-02-2000', 2, 'ж', 7.5, null) " +

                "insert into[Address](StudentID, Town, [Index], Street, House, Flat) values" +
                    "(100, 'Минск', 220006, 'Бобруйская', 21, 404)," +
                    "(101, 'Минск', 220006, 'Белорусская', 21, 404)," +
                    "(102, 'Минск', 220052, 'Гурского', 21, 312)," +
                    "(103, 'Минск', 220006, 'Белорусская', 21, 710)";

        }
        string Procedure1()
        {
            return
                "CREATE PROCEDURE [dbo].[sp_InsertStudent] " +
                    "@NAME nvarchar(100), " +
                    "@SPECIALITY nvarchar(200), " +
                    "@AGE int, " +
                    "@BIRTHDAY date, " +
                    "@COURSE int, " +
                    "@SEX nchar(1), " +
                    "@AVGSCORE float " +
                "AS insert " +
                "into Student(NAME, SPECIALITY, AGE, BIRTHDAY, COURSE, SEX, AVGSCORE) " +
                "VALUES(@NAME, @SPECIALITY, @AGE, @BIRTHDAY, @COURSE, @SEX, @AVGSCORE) " +
                "SELECT SCOPE_IDENTITY() " +
                "GO ";

        }
        string Procedure2()
        {
            return
                "CREATE PROCEDURE[dbo].[sp_InsertAddress] " +
                    "@StudentID int, " +
                    "@Town nvarchar(20), " +
                    "@Index int, " +
                    "@Street nvarchar(30), " +
                    "@House int, " +
                    "@Flat int " +
                "AS insert " +
                "into Address(StudentID, Town, [Index], Street, House, Flat) " +
                "VALUES(@StudentID, @Town, @Index, @Street, @House, @Flat) " +
                "SELECT SCOPE_IDENTITY() " +
                "GO";
        }

        public MainWindow()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string connectionString0 = @"Data Source=HOME-PC; Integrated Security=True";
            SqlConnection sqlConnection0 = new SqlConnection(connectionString0);
            SqlCommand myCommand1 = new SqlCommand(createDB(), sqlConnection0);
            SqlCommand myCommand2 = new SqlCommand(createTables(), sqlConnection0);
            SqlCommand myCommand3 = new SqlCommand(Insert(), sqlConnection0);
            SqlCommand myCommand4 = new SqlCommand(Procedure1(), sqlConnection0);
            SqlCommand myCommand5 = new SqlCommand(Procedure2(), sqlConnection0);
            sqlConnection0.Open();
            myCommand1.ExecuteNonQuery();
            myCommand2.ExecuteNonQuery();
            myCommand3.ExecuteNonQuery();
            myCommand4.ExecuteNonQuery();
            myCommand5.ExecuteNonQuery();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCurrentGrid();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    ///заполн.DataSet (ядро автономн.доступа к данным)
                    this.adapter = new SqlDataAdapter(GetSql(), connection);
                    this.commandBuilder = new SqlCommandBuilder(this.adapter);

                    if (this.currentTableName == Tables.Student.ToString())
                    {
                        ///упр источником д-х с пом SQL
                        this.adapter.InsertCommand = new SqlCommand("sp_InsertStudent", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@NAME", SqlDbType.NVarChar, 100, "NAME"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@SPECIALITY", SqlDbType.NVarChar, 200, "SPECIALITY"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@AGE", SqlDbType.Int, 0, "AGE"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@BIRTHDAY", SqlDbType.Date, 0, "BIRTHDAY"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@COURSE", SqlDbType.Int, 0, "COURSE"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@SEX", SqlDbType.Char, 1, "SEX"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@AVGSCORE", SqlDbType.Float, 0, "AVGSCORE"));
                    }

                    if (this.currentTableName == Tables.Address.ToString())
                    {
                        this.adapter.InsertCommand = new SqlCommand("sp_InsertAddress", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int, 0, "StudentID"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Town", SqlDbType.NVarChar, 20, "Town"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Index", SqlDbType.BigInt, 0, "Index"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30, "Street"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@House", SqlDbType.Int, 0, "House"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Flat", SqlDbType.Int, 0, "Flat"));
                    }

                    //this.currentGrid.CanUserAddRows = false;
                    this.adapter.Update(this.ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }


        //ОБНОВЛЕНИЕ ЗАПИСЕЙ
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FillCurrentGrid();
            this.currentGrid.CanUserAddRows = false;
        }


        //КНОПКА НАЗАД
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.pageNumber == 0)
                return;
            this.currentGrid.CanUserAddRows = false;
            this.pageNumber--;
            GetPage();
        }
        //КНОПКА ВПЕРЕД
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ds.Tables[0].Rows.Count < this.pageSize)
                return;
            this.currentGrid.CanUserAddRows = false;
            this.pageNumber++;
            GetPage();
        }


        //УДАЛЕНИЕ ЗАПИСЕЙ
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentGrid.SelectedItems != null)
            {
                for (int i = this.currentGrid.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (this.currentGrid.SelectedItems[i] is DataRowView datarowView)
                    {
                        DataRow dataRow = datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }

        //ДОБАВЛЕНИЕ ЗАПИСЕЙ
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            while (!(this.ds.Tables[0].Rows.Count < this.pageSize))
            {
                this.pageNumber++;
                GetPage();
            }
            currentGrid.CanUserAddRows = true;
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            PhotoViewer photoViewer = new PhotoViewer(image.Source)
            {
                Owner = this
            };
            photoViewer.Show();
        }

        //ИЗМЕНЕНИЕ ПОЛЕЙ
        private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TabItem item = (TabItem)this.mainTab.SelectedItem;
                if (this.currentTableName != item.Header.ToString())
                {
                    this.currentTableName = item.Header.ToString();

                    if (this.currentTableName == Tables.Student.ToString())
                    {
                        currentGrid = this.StudentGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.ID.ToString();
                    }
                    if (this.currentTableName == Tables.Address.ToString())
                    {
                        currentGrid = this.AddressGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.Id.ToString();
                    }
                    this.pageNumber = 0;
                    FillCurrentGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private string GetSql()
        {
            return "SELECT * FROM " + this.currentTableName
                + " ORDER BY " + this.currentPrimaryColumnName
                    + " OFFSET ((" + this.pageNumber + ") * " + this.pageSize + ") "
                    + "ROWS FETCH NEXT " + this.pageSize + " ROWS ONLY";
        }

        private void GetPage()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    this.adapter = new SqlDataAdapter(GetSql(), connection);
                    this.ds.Tables[0].Rows.Clear();
                    this.adapter.Fill(this.ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        //ЗАПОЛНЕНИЕ ТЕКУЩЕГО GRID
        private void FillCurrentGrid()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                this.adapter = new SqlDataAdapter(GetSql(), connection);                //GET SQL_

                this.ds = new DataSet();    ///предст.полн.набор д-х
                this.adapter.Fill(this.ds);
                currentGrid.ItemsSource = this.ds.Tables[0].DefaultView;

                /// транзакция - набор операций, либо все вып./нет  -> д-е всегда в коррект сост.
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "select * from Student";
                    command.ExecuteNonQuery();///для оп-ров sql без рез (update, insert)
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        //ЗАГРУЗКА ДАННЫХ ИЗ БД
        private void ReadFileFromDatabase()
        {
            images = new List<Image>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Surname, Photo FROM Address";      ///запрос для команды
                SqlCommand command = new SqlCommand(sql, connection);       ///вып команду
                SqlDataReader reader = command.ExecuteReader();             ///получ.д-е

                while (reader.Read())   ///пока есть строки для чтения
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    byte[] data = (byte[])reader.GetValue(2);

                    Image im = new Image();
                    images.Add(im);
                }
            }
        }



        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem item = (TabItem)sender;
            currentTableName = item.Header.ToString();

            if (currentTableName == Tables.Student.ToString())
            {
                currentGrid = accountsGrid;
                currentPrimaryColumnName = PrimaryColumn.Id.ToString();
            }
            if (currentTableName == Tables.Address.ToString())
            {
                currentGrid = AddressGrid;
                currentPrimaryColumnName = PrimaryColumn.Id.ToString();
            }
            FillCurrentGrid();
        }

        private void StudentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}