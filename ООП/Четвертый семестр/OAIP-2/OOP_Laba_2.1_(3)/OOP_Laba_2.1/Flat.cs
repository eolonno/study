using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace OOP_Laba_2._1 {
    
  [Serializable]
  public class Option{
    public bool option_1;
    public bool option_2;
    public bool option_3;
    public bool option_4;
    public bool option_5;
    public bool option_6;

    public Option( ) { }

    public Option( bool opt_1, bool opt_2, bool opt_3, bool opt_4, bool opt_5) {
      option_1 = opt_1;
      option_2 = opt_2;
      option_3 = opt_3;
      option_4 = opt_4;
      option_5 = opt_5;
    }

    public override string ToString() {
      return ( option_1 ? "Кухня" : "" ) +
             ( option_2 ? "Ванна" : "" ) +
             ( option_3 ? "Туалет" : "" ) +
             ( option_4 ? "Подвал" : "" ) +
             ( option_5 ? "Балкон" : "" );
    }

    public void OptionValueDisplay( out decimal opt_1, out decimal opt_2,
                                    out decimal opt_3, out decimal opt_4,
                                    out decimal opt_5 ) {
      if ( option_1 ) {
        opt_1 = 789.45m;
      }
      else {
        opt_1 = 0;
      }

      if (option_2) {
        opt_2 = 456.23m;
      }
      else {
        opt_2 = 0;
      }

      if (option_3) {
        opt_3 = 689.45m;
      }
      else {
        opt_3 = 0;
      }

      if (option_4) {
        opt_4 = 2564.24m;
      }
      else {
        opt_4 = 0;
      }

      if (option_5) {
        opt_5 = 455.45m;
      }
      else {
        opt_5 = 0;
      }

    }
  }

  [Serializable]
  public enum MatType{
    Mat_1 = 5000,
    Mat_2 = 6000,
    Mat_3 = 7000,
    Mat_4 = 4000,
    Mat_5 = 8000,
    Mat_6 = 10000
  }

  [Serializable]
  public enum WinSide {
    Side_1 = 10000,
    Side_2 = 20000
  }

  [Serializable]
  public class Address {
    public string addr_country;
    public string addr_city;
    public string addr_region;
    public string addr_street;
    public string addr_house;
    public int addr_value;

    public Address() { }

    public Address(string str_1, string str_2, string str_3,
                    string str_4, string str_5, int value) {
      addr_country = str_1;
      addr_city = str_2;
      addr_region = str_3;
      addr_street = str_4;
      addr_house = str_5;
      addr_value = value;
    }

    public override string ToString() {
      return addr_country + " " +
             addr_city + " " +
             addr_region + " " +
             addr_street + " " +
             addr_house;
    }
  }

  [Serializable]
  public class Room {
    public string room_name;
    public int room_metr;
    public int window_count;
    public WinSide window_side;

    public Room() { }

    public Room(string name, int metr, int count, WinSide side) {
      room_name = name;
      room_metr = metr;
      window_count = count;
      window_side = side;
    }
  }

  [Serializable]
  public class Flat {

    public string flat_name;

    public int metr;
    public int count;
    public string year;
    public int year_value;


    public Option option;
    public MatType mat_type;
    public Address addr;
    public List<Room> Rooms;

    public decimal summ;
    public Flat( ) { }

    public Flat( string name, int metr, int count, string year, int year_value, Option option, MatType mat, Address addr, IEnumerable<Room> rooms ) {
      flat_name = name;
      this.metr = metr;
      this.count = count;
      this.year = year;
      this.option = option;
      this.mat_type = mat;
      this.addr = addr;
      this.year_value = year_value;
      Rooms = new List<Room>( rooms );
    }

    public string GetAddrRegion( ) {
      return addr.addr_region;
    }

    public string GetAddrCity( ) {
      return addr.addr_city;
    }

    public decimal GetSumm() {
      option.OptionValueDisplay( out decimal opt_1,
                                 out decimal opt_2,
                                 out decimal opt_3,
                                 out decimal opt_4,
                                 out decimal opt_5 );

      decimal summ_room = 0;

      foreach ( Room room_item in Rooms ) {
        summ_room += room_item.room_metr * 450 + room_item.window_count * 758 * ( room_item.window_side == WinSide.Side_1 ? 10000 : 20000 );
      }

      summ = metr * 457 + year_value + opt_1 + opt_2 + opt_3 + opt_4 +
        opt_5 + ( mat_type == MatType.Mat_1 ? 10000 : 0 ) + ( mat_type == MatType.Mat_2 ? 20000 : 0 ) +
               ( mat_type == MatType.Mat_3 ? 30000 : 0 ) + ( mat_type == MatType.Mat_4 ? 40000 : 0 ) +
               ( mat_type == MatType.Mat_5 ? 50000 : 0 ) + ( mat_type == MatType.Mat_6 ? 60000 : 0 ) +
               summ_room + addr.addr_value;

      return summ;
    }

    public TreeNode TakeItemTree( ) {
      TreeNode flat_node = new TreeNode( flat_name );
      flat_node.Nodes.Add( "Метраж квартиры: " + metr );
      flat_node.Nodes.Add( "Количество комнат: " + count );
      flat_node.Nodes.Add( "Год постройки: " + year );
      flat_node.Nodes.Add( "Опции: " + option );
      flat_node.Nodes.Add( "Вид материала: " + ( mat_type == MatType.Mat_1 ? "Материал 1" : 
                                                 mat_type == MatType.Mat_2 ? "Материал 2" :
                                                 mat_type == MatType.Mat_3 ? "Материал 3" :
                                                 mat_type == MatType.Mat_4 ? "Материал 4" :
                                                 mat_type == MatType.Mat_5 ? "Материал 5" :
                                                 mat_type == MatType.Mat_6 ? "Материал 6" : "" ) );

      TreeNode flat_addr = new TreeNode( "Адрес" );
      flat_addr.Nodes.Add( addr.ToString() );
      flat_node.Nodes.Add( flat_addr );

      TreeNode flat_room = new TreeNode( "Комнаты" );
      foreach ( Room room_item in Rooms ) {
        TreeNode room = new TreeNode( room_item.room_name );
        room.Nodes.Add( "Метраж комнаты: " + room_item.room_metr );
        room.Nodes.Add( "Количество окон: " + room_item.window_count );
        room.Nodes.Add( "Сторона окон: " + ( room_item.window_side == WinSide.Side_1 ? "Юг" : "Юго-Запад" ) );
        flat_room.Nodes.Add( room );
      }
      flat_node.Nodes.Add( flat_room );

      flat_node.Nodes.Add( "Итоговая сумма: " + summ );
      
      return flat_node;
    }
  } 
}