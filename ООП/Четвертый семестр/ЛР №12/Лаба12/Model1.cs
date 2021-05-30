namespace Лаба12
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public partial class Model1 : DbContext
    {

        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Tovar> Tovar { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
