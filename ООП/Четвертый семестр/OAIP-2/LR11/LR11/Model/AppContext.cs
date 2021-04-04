namespace LR11.Model {
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class AppContext : DbContext {
    public AppContext()
        : base("name=AppContext") {
    }

    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    }
  }
}
