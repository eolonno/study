using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OOP_Laba_11.Commands;
using OOP_Laba_11.Model;
using System.Data.Entity;

namespace OOP_Laba_11.ViewModel {
  class MobileViewModel : ViewModelBase {

    public Phone Phone;
    MobileContext db;


    public MobileViewModel( ) {
      db = new MobileContext( );
    }

    public MobileViewModel( Phone phone ) {
      this.Phone = phone;

    }

    public string Title {
      get { return Phone.Title; }
      set {
        Phone.Title = value;
        OnPropertyChanged( "Title" );
      }
    }

    public string Company {
      get { return Phone.Company; }
      set {
        Phone.Company = value;
        OnPropertyChanged( "Company" );
      }
    }

    public int Price {
      get { return Phone.Price; }
      set {
        Phone.Price = value;
        OnPropertyChanged( "Price" );
      }
    }

    public int Count {
      get { return Phone.Count; }
      set {
        Phone.Count = value;
        OnPropertyChanged( "Count" );
      }
    }

    #region Commands

    #region Забрать

    private DelegateCommand getItemCommand;

    public ICommand GetItemCommand {
      get {
        if ( getItemCommand == null ) {
          getItemCommand = new DelegateCommand( GetItem );
        }
        return getItemCommand;
      }
    }

    private void GetItem( ) {
      Count++;
    }

    #endregion

    #region Выдать

    private DelegateCommand giveItemCommand;

    public ICommand GiveItemCommand {
      get {
        if ( giveItemCommand == null ) {
          giveItemCommand = new DelegateCommand( GiveItem , CanGiveItem );
        }
        return giveItemCommand;
      }
    }

    private void GiveItem( ) {
      Count--;
    }

    private bool CanGiveItem( ) {
      return Count > 0;
    }

    #endregion

    #endregion


  }
}
