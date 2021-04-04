namespace OOP_Laba_9._1 {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Move : INotifyPropertyChanged {

    private int _ID;

    [Key]
    public int Move_ID {
      get { return _ID; }
      set {
        _ID = value;
        OnPropertyChanged( "Move_ID" );
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged( string propertyName ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if ( handler != null ) handler( this , new PropertyChangedEventArgs( propertyName ) );
    }

    public int Game_ID { get; set; }

    public int Player_ID { get; set; }

    public int? Ply { get; set; }

    [Required]
    [StringLength( 60 )]
    public string FEN { get; set; }

    [StringLength( 10 )]
    public string MoveNext { get; set; }

    public virtual Game Game { get; set; }

    public virtual Player Player { get; set; }
  }
}
