using System;
using System.Collections;
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
using System.Data.Entity;

namespace OOP_Laba_9._1 {
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    ChessDB db;


    public MainWindow( ) {
      InitializeComponent( );

      SelectGameStatus.ItemsSource = new ArrayList( ) { "wait" , "play" , "done" };

      db = new ChessDB( );

      db.Games.Load( );
      GameDataGrid.ItemsSource = db.Games.Local.ToBindingList( );

      db.Players.Load( );
      PlayersDataGrid.ItemsSource = db.Players.Local.ToBindingList( );

      db.Moves.Load( );
      MoveDataGrid.ItemsSource = db.Moves.Local.ToBindingList( );

      this.Closing += MainWindow_Closing;

      DelRowDB.Click += DEL_Game;
      SortDB.Click += Sort_Game;
    }

    private void MainWindow_Closing( object sender , System.ComponentModel.CancelEventArgs e ) {
      db.Dispose( );
    }

    private void DEL_Game( object sender , RoutedEventArgs e ) {
      if ( GameDataGrid.SelectedItems.Count > 0 ) {
        for ( int i = 0; i < GameDataGrid.SelectedItems.Count; i++ ) {
          Game game = GameDataGrid.SelectedItems[ i ] as Game;

          if ( game != null )
            db.Games.Remove( game );
        }
      }
      db.SaveChanges( );
    }

    private void DEL_Players( object sender , RoutedEventArgs e ) {
      if ( PlayersDataGrid.SelectedItems.Count > 0 ) {
        for ( int i = 0; i < PlayersDataGrid.SelectedItems.Count; i++ ) {
          Player player = PlayersDataGrid.SelectedItems[ i ] as Player;

          if ( player != null )
            db.Players.Remove( player );
        }
      }
      db.SaveChanges( );
    }

    private void DEL_Move( object sender , RoutedEventArgs e ) {
      if ( MoveDataGrid.SelectedItems.Count > 0 ) {
        for ( int i = 0; i < MoveDataGrid.SelectedItems.Count; i++ ) {
          Move move = MoveDataGrid.SelectedItems[ i ] as Move;

          if ( move != null )
            db.Moves.Remove( move );
        }
      }
      db.SaveChanges( );
    }

    private void UpdateDB_Click( object sender , RoutedEventArgs e ) {
      GameDataGrid.ItemsSource = db.Games.Local.ToBindingList( );
      PlayersDataGrid.ItemsSource = db.Players.Local.ToBindingList( );
      MoveDataGrid.ItemsSource = db.Moves.Local.ToBindingList( );

      db.SaveChanges( );
    }

    private void TabControl_SelectionChanged( object sender , SelectionChangedEventArgs e ) {
      if ( tabs.SelectedIndex == 0 ) {
        DelRowDB.Click -= DEL_Players;
        DelRowDB.Click -= DEL_Move;

        DelRowDB.Click += DEL_Game;

        SortDB.Click -= Sort_Move;
        SortDB.Click -= Sort_Player;

        SortDB.Click += Sort_Game;
      }
      else if ( tabs.SelectedIndex == 1 ) {
        DelRowDB.Click -= DEL_Game;
        DelRowDB.Click -= DEL_Move;

        DelRowDB.Click += DEL_Players;

        SortDB.Click -= Sort_Move;
        SortDB.Click -= Sort_Game;

        SortDB.Click += Sort_Player;
      }
      else if ( tabs.SelectedIndex == 2 ) {
        DelRowDB.Click -= DEL_Players;
        DelRowDB.Click -= DEL_Game;

        DelRowDB.Click += DEL_Move;

        SortDB.Click -= Sort_Player;
        SortDB.Click -= Sort_Game;

        SortDB.Click += Sort_Move;
      }
    }


    private void Sort_Game( object sender , RoutedEventArgs e ) {
      var Sort_G = db.Games.Where( p => p.Game_Status == "wait" ).OrderBy( p => p.Game_ID ).ToList( );
      GameDataGrid.ItemsSource = Sort_G;
    }

    private void Sort_Player( object sender , RoutedEventArgs e ) {
      var Sort_P = db.Players.Where( p => p.Name.StartsWith( "p" ) ).OrderBy( p => p.Player_ID ).ToList( );
      PlayersDataGrid.ItemsSource = Sort_P;
    }

    private void Sort_Move( object sender , RoutedEventArgs e ) {
      var Sort_M = db.Moves.Where( p => p.Game_ID == 2 ).OrderBy( p => p.Move_ID ).ToList( );
      MoveDataGrid.ItemsSource = Sort_M;
    }

    private void Trans_Click( object sender , RoutedEventArgs e ) {
      using ( ChessDB db = new ChessDB( ) ) {

        using ( var transaction = db.Database.BeginTransaction( ) ) {
          try {
            db.Database.ExecuteSqlCommand( @"UPDATE Games SET Game_Status = 'play' WHERE Game_ID = 3" );
            db.Games.Add( new Game { Game_ID = 15 , FEN = "gsjdlgjds" , Game_Status = "done" } );
            db.SaveChanges( );
            transaction.Commit( );
            //SaveObjectsAsync( new Game { Game_ID = 222 , FEN = "async" , Game_Status = "done" } ).Wait( );
            db.Games.Load( );
            GameDataGrid.ItemsSource = db.Games.Local.ToBindingList( );
            MessageBox.Show( "Succes/n" );
          }
          catch ( Exception ex ) {
            transaction.Rollback( );
            MessageBox.Show( "Fail" );
          }
        }
      }
    }

    private static async Task SaveObjectsAsync( Game game ) {
      using ( ChessDB db = new ChessDB( ) ) {
        db.Games.Add( game );
        await db.SaveChangesAsync( );
      }
    }

  }
}
