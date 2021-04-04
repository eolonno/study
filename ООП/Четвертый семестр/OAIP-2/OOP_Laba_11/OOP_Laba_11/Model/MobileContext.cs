using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OOP_Laba_11.Model {
  public class MobileContext : DbContext {
    public MobileContext( ) : base( "DefaultConnection" ) {

    }
    public DbSet<Phone> Phones { get; set; }
  }
}
