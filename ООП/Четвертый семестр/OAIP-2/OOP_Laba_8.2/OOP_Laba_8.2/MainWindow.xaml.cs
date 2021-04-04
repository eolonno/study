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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OOP_Laba_8._2 {
  public partial class MainWindow : Window {

    public string filename;
    List<Image> list;



    private void Image_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {

      using ( var dialog = new Windows.Forms  FolderBrowserDialog( ) ) {
        System.Windows.Forms.DialogResult result = dialog.ShowDialog( );
      }


      using ( OpenFileDialog ofd = new OpenFileDialog( ) { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false } ) {
        if(ofd.ShowDialog() == DialogResult.Value ){
          filename = ofd.FileName;
        }
      }
    }
  }
}
