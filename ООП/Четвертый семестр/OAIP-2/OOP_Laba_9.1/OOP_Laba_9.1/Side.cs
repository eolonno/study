namespace OOP_Laba_9._1 {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Side : INotifyPropertyChanged {
    private int _ID;


    [Key]
    [DatabaseGenerated( DatabaseGeneratedOption.None )]
    public int Side_ID {
      get { return _ID; }
      set {
        _ID = value;
        OnPropertyChanged( "Side_ID" );
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged( string propertyName ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if ( handler != null ) handler( this , new PropertyChangedEventArgs( propertyName ) );
    }


    public int Game_ID { get; set; }

    public int Player_ID { get; set; }

    [StringLength( 5 )]
    public string Color { get; set; }

    public decimal? PointS { get; set; }

    public int? Draw { get; set; }

    public int? Resing { get; set; }

    public virtual Game Game { get; set; }

    public virtual Player Player { get; set; }
  }
}
