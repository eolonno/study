namespace LR9
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<Flats> Flats { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Houses>()
                .HasMany(e => e.Flats)
                .WithOptional(e => e.Houses)
                .HasForeignKey(e => e.House);
        }
    }
}
