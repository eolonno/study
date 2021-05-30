using System;
using System.Collections.Generic;
using System.Data.Entity;
using Лаба12;

namespace AutoCodeSecond
{
    class UserContext : DbContext
    {
        public UserContext() : base("Model1")
        { }
        public DbSet<Tovar> tovars { get; set; }
        public DbSet<Zakaz> zakazs { get; set; }
    }
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}