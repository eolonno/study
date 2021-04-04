using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_11.Model {
  public class Phone {

    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    public string Company { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }



    //public event PropertyChangedEventHandler PropertyChanged;

    //protected void OnPropertyChanged( string propertyName ) {
    //  PropertyChangedEventHandler handler = PropertyChanged;

    //  if ( handler != null ) {
    //    handler( this , new PropertyChangedEventArgs( propertyName ) );
    //  }
    //}

    //public Phone( string title , string company , int price , int count ) {
    //  this.Title = title;
    //  this.Company = company;
    //  this.Price = price;
    //  this.Count = count;
    //}
  }
}
