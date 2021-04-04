using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OOP_Laba_11.Model;
using OOP_Laba_11.View;
using OOP_Laba_11.ViewModel;

namespace OOP_Laba_11 {
  /// <summary>
  /// Логика взаимодействия для App.xaml
  /// </summary>
  public partial class App : Application {
   
    private void OnStartup( object sender , StartupEventArgs e ) {


      MainView view = new MainView( ); // создали View
      MainViewModel viewModel = new ViewModel.MainViewModel ( ); // Создали ViewModel
      view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
      view.Show( );
    }


  }
}
