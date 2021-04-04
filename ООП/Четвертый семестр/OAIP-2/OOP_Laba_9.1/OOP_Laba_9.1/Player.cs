namespace OOP_Laba_9._1 {
  using System;
  using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Player : INotifyPropertyChanged {

    private int _ID;

    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage" , "CA2214:DoNotCallOverridableMethodsInConstructors" )]
    public Player( ) {
      Moves = new HashSet<Move>( );
      Sides = new HashSet<Side>( );
    }

    [Key]
    public int Player_ID {
      get { return _ID; }
      set {
        _ID = value;
        OnPropertyChanged( "Player_ID" );
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged( string propertyName ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if ( handler != null ) handler( this , new PropertyChangedEventArgs( propertyName ) );
    }



    [Required]
    [StringLength( 15 )]
    public string Name { get; set; }

    [StringLength( 15 )]
    public string Password { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage" , "CA2227:CollectionPropertiesShouldBeReadOnly" )]
    public virtual ICollection<Move> Moves { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage" , "CA2227:CollectionPropertiesShouldBeReadOnly" )]
    public virtual ICollection<Side> Sides { get; set; }
  }
}
