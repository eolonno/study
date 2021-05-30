using AutoCodeSecond;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба12
{
    public class StudentRepository : IRepository<Tovar>
    {
        private Model1 db;
        public StudentRepository(Model1 context)
        { this.db = context; }
        public IEnumerable<Tovar> GetAll()
        { return db.Tovar; }
        public Tovar Get(int id)
        { return db.Tovar.Find(id); }
        public void Create(Tovar student)
        { db.Tovar.Add(student); }
        public void Update(Tovar student)
        { db.Entry(student).State = EntityState.Modified; }
        public void Delete(int id)
        {
            Tovar    student = db.Tovar.Find(id);
            if (student != null)
                db.Tovar.Remove(student);
        }

    }
    public class Zalazrep : IRepository<Zakaz>
    {
        private Model1 db;
        public Zalazrep(Model1 context)
        { this.db = context; }
        public IEnumerable<Zakaz> GetAll()
        { return db.Zakaz; }
        public Zakaz Get(int id)
        { return db.Zakaz.Find(id); }
        public void Create(Zakaz student)
        { db.Zakaz.Add(student); }
        public void Update(Zakaz student)
        { db.Entry(student).State = EntityState.Modified; }
        public void Delete(int id)
        {
            Zakaz student = db.Zakaz.Find(id);
            if (student != null)
                db.Zakaz.Remove(student);
        }

    }
}
