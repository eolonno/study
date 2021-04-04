namespace OOP_Laba_9._1 {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Game : INotifyPropertyChanged {

    private int _IdRow;

    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage" , "CA2214:DoNotCallOverridableMethodsInConstructors" )]
    public Game( ) {
      Moves = new HashSet<Move>( );
      Sides = new HashSet<Side>( );
    }

    [Key]
    public int Game_ID {
      get { return _IdRow; }
      set {
        _IdRow = value;
        OnPropertyChanged( "Game_ID" );
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged( string propertyName ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if ( handler != null ) handler( this , new PropertyChangedEventArgs( propertyName ) );
    }





    [Required]
    [StringLength( 60 )]
    public string FEN { get; set; }

    [Required]
    [StringLength( 4 )]
    public string Game_Status { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage" , "CA2227:CollectionPropertiesShouldBeReadOnly" )]
    public virtual ICollection<Move> Moves { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage" , "CA2227:CollectionPropertiesShouldBeReadOnly" )]
    public virtual ICollection<Side> Sides { get; set; }




  }
}
