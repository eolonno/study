using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Laba_11.Model;

namespace OOP_Laba_11.ViewModel {
  class MainViewModel : ViewModelBase {

    MobileContext db;


    public ObservableCollection<MobileViewModel> MobileList { get; set; }



    public MainViewModel( ) {

      db = new MobileContext( );

      //List<Phone> phones = new List<Phone>( ) {
      //  new Phone("Пттерны проетирования", "John Gossman", 3000, 10),
      //  new Phone("CLR via C#", "Джеффри Рихтер", 2000, 5),
      //  new Phone("Исскуство программирования", "Кнут", 555, 2)
      //};

      //db.Phones.AddRange( phones );
      //db.SaveChanges( );

      db.Phones.Load( );
      List<Phone> phones = new List<Phone>( );

      phones = db.Phones.ToList( );

      MobileList = new ObservableCollection<MobileViewModel>( phones.Select( b => new MobileViewModel( b ) ) );
    }



  }
}
