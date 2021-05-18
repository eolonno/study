using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dormitory.Models;
using Dormitory.ViewModels;

namespace Dormitory.Models.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<TenantViewModel> Tenants { get; set; }
        
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dormitory;Trusted_Connection=True;");
        }
    }
}
