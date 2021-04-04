using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOP_Laba_7 {

  public class CustomCommand {

    private static RoutedUICommand pnvCommand;

    static CustomCommand( ) {
      InputGestureCollection inputs = new InputGestureCollection( );
      inputs.Add( new KeyGesture( Key.R, ModifierKeys.Alt, "Alt+R" ) );
      pnvCommand = new RoutedUICommand( "Com", "Com", typeof( CustomCommand ), inputs );
    }
    public static RoutedUICommand PnvCommand { get { return pnvCommand; } }
  }



}
