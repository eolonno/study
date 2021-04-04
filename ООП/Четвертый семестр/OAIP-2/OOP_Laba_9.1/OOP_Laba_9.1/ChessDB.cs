namespace OOP_Laba_9._1 {
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class ChessDB : DbContext {
    public ChessDB( )
        : base( "name=ChessDB" ) {
    }

    public virtual DbSet<Game> Games { get; set; }
    public virtual DbSet<Move> Moves { get; set; }
    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Side> Sides { get; set; }

    protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
      modelBuilder.Entity<Game>( )
          .Property( e => e.Game_Status )
          .IsFixedLength( )
          .IsUnicode( false );

      modelBuilder.Entity<Game>( )
          .HasMany( e => e.Moves )
          .WithRequired( e => e.Game )
          .WillCascadeOnDelete( false );

      modelBuilder.Entity<Game>( )
          .HasMany( e => e.Sides )
          .WithRequired( e => e.Game )
          .WillCascadeOnDelete( false );

      modelBuilder.Entity<Move>( )
          .Property( e => e.MoveNext )
          .IsUnicode( false );

      modelBuilder.Entity<Player>( )
          .Property( e => e.Password )
          .IsUnicode( false );

      modelBuilder.Entity<Player>( )
          .HasMany( e => e.Moves )
          .WithRequired( e => e.Player )
          .WillCascadeOnDelete( false );

      modelBuilder.Entity<Player>( )
          .HasMany( e => e.Sides )
          .WithRequired( e => e.Player )
          .WillCascadeOnDelete( false );

      modelBuilder.Entity<Side>( )
          .Property( e => e.Color )
          .IsUnicode( false );

      modelBuilder.Entity<Side>( )
          .Property( e => e.PointS )
          .HasPrecision( 2 , 1 );
    }
  }
}
