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

namespace OOP_Laba_7 {
  /// <summary>
  /// Логика взаимодействия для Cntrol_User_1.xaml
  /// </summary>
  public partial class Cntrol_User_1 : UserControl {
    public Cntrol_User_1( ) {
      InitializeComponent( );
    }

    public static readonly RoutedEvent ClickEvent;

    public event RoutedEventHandler Click {
      add { AddHandler( ClickEvent, value ); }
      remove { RemoveHandler( ClickEvent, value ); }
    }
    public static readonly DependencyProperty TitleProperty;
    public static readonly DependencyProperty PriceProperty;


    static Cntrol_User_1( ) {

      ClickEvent = EventManager.RegisterRoutedEvent( "Click", RoutingStrategy.Bubble, typeof( RoutedEventHandler ), typeof( Cntrol_User_1 ) );
      TitleProperty = DependencyProperty.Register( "Title", typeof( string ), typeof( Cntrol_User_1 ), new PropertyMetadata( "Something" ) );
      PropertyMetadata metadata = new PropertyMetadata( 100 );
      metadata.CoerceValueCallback = new CoerceValueCallback( CorrectValue );
      PriceProperty = DependencyProperty.Register( "Price", typeof( int ), typeof( Cntrol_User_1 ), metadata, new ValidateValueCallback( ValidateValue ) );


    }
    private static object CorrectValue( DependencyObject d, object baseValue ) {
      int currentValue = ( int )baseValue;
      if ( currentValue > 1000 )
        return 1000;
      return currentValue;
    }

    private static bool ValidateValue( object value ) {
      int currentValue = ( int )value;
      if ( currentValue >= 0 )
        return true;
      return false;
    }

    public string Title {
      get { return ( string )GetValue( TitleProperty ); }
      set { SetValue( TitleProperty, value ); }
    }
    public int Price {
      get { return ( int )GetValue( PriceProperty ); }
      set { SetValue( PriceProperty, value ); }
    }
    private void Button_Click( object sender, RoutedEventArgs e ) {
      if ( MyButton.Visibility == Visibility.Visible ) {
        MyContent.Visibility = Visibility.Visible;
        MyButton.Visibility = Visibility.Collapsed;
      }
      else {
        MyContent.Visibility = Visibility.Collapsed;
        MyButton.Visibility = Visibility.Visible;
      }

    }

    private void CommandBinding_Executed( object sender, ExecutedRoutedEventArgs e ) {
      MessageBox.Show( "Done" );
    }


  }


}
