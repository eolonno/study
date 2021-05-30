using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Лаба12
{
    class viewmodel : INotifyPropertyChanged
    {
        Model1 db = new Model1();
        private ObservableCollection<Zakaz> zak { get; set; }
        private ObservableCollection<Tovar> tov { get; set; }
        public ObservableCollection<Zakaz> allzakaz { get { return zak; } set { zak = value; OnPropertyChanged("allzakaz"); } }
        public ObservableCollection<Tovar> alltovar { get { return tov; } set { tov = value; OnPropertyChanged("alltovar"); } }
        string Photos;
        public ICommand addzakaz
        { get; set; }
        public ICommand Addphot
        {
            get;set;
        }
        public ICommand Addtov
        {
            get; set;
        }
        public ICommand Obnov
        {
            get;set;
        }
        public ICommand Sort1
        {
            get;set;
        }
        public ICommand Sort2
        {
            get;set;
        }
        public ICommand Del
        { get; set; }
        public ICommand Edit
        { get; set; }
        public ICommand Sort3
        { get; set; }
        viewmodel()
        {
            Sort3 = new DelegateCommand(transaction);
            Sort2 = new DelegateCommand(sort2);
            Sort1 = new DelegateCommand(sort1);
            Edit = new DelegateCommand(edit);
            Del = new DelegateCommand(delete);
            addzakaz = new DelegateCommand(Addzakaz);
            Addphot = new DelegateCommand(LoadImage);
            Obnov = new DelegateCommand(obnovit);
            Addtov = new DelegateCommand(Addtovar);
            vivodZakaz();
            vivodTovar();
        }
        public void edit(object obj)
        {
            
            var customer = db.Tovar
       // Загрузить покупателя с фамилией "Иванов"
       .Where(c => c.names == Curtools1.names)
       .FirstOrDefault();

            // Внести изменения
            
            customer.info = Info;
            customer.cost =  Convert.ToDouble(Add_Cost);
            // Сохранить изменения
            db.SaveChanges();
        }
        public void sort1(object obj)
        {
            alltovar.Clear();
            var phones = from p in db.Tovar
                         orderby p.names
                         select p;
            foreach (Tovar p in phones)
            {

                alltovar.Add(new Tovar { names = p.names, cost = Convert.ToDouble(p.cost), info = p.info });
            }
        }
        public void sort2(object obj)
        {
            allzakaz.Clear();
            var phones = from p in db.Zakaz
                         orderby p.client
                         select p;
            foreach (Zakaz p in phones)
            {

                allzakaz.Add(new Zakaz { client = p.client, cost = p.cost, namesss = p.namesss, Photo = p.Photo });
            }
        }
        public   void  transaction (object obj)
        {
            db.Database.Log = Console.Write;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand(@"UPDATE Tovar SET cost = cost + 1 WHERE names = '111'");
                    db.Tovar.Add(new Tovar { names = "124214", cost = 11 , info = "fgdfg"});
                    db.Tovar.CountAsync();
                    db.SaveChanges();
                    transaction.Commit();
                 
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void obnovit(object obj)
        {
            
            vivodTovar();
            vivodZakaz();
        }
        public void Addtovar(object obj)
        {
            alltovar.Add(new Tovar { names = Nick, cost = Convert.ToDouble(Add_Cost),  info = Info });
            db.Tovar.Add(new Tovar { names = Nick, cost = Convert.ToDouble(Add_Cost), info = Info });
            db.SaveChanges();
        }
        void LoadImage(object obj)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {

                Photos = openFileDialog.FileName;
            }
        }
        public void Addzakaz(object obj)
        {
            allzakaz.Add(new Zakaz { client = User, cost= Curtools1.cost, namesss = Curtools1.names, Photo = Photos });
            db.Zakaz.Add(new Zakaz {  client = User, cost = Curtools1.cost, namesss = Curtools1.names, Photo = Photos });
            db.SaveChanges();
        }
        public void vivodZakaz()
        {
            allzakaz = null;
                allzakaz = new ObservableCollection<Zakaz>(db.Zakaz.ToList());
         
        }
        public void delete(object obj)
        {
            IQueryable<Tovar> ods = from o in db.Tovar
                                    where o.names == Curtools1.names
                                           select o;
            foreach (Tovar od in ods)
            {

                // Удалить детали первого заказа
                db.Tovar.Remove(od);
            }
            // Сохранить изменения
            db.SaveChanges();
        }
        public void vivodTovar()
        {
            alltovar = null;
                alltovar = new ObservableCollection<Tovar>(db.Tovar.ToList());
            
        }
        public static viewmodel instance = null;
        public static viewmodel getInstance()
        {
            if (instance == null)
                instance = new viewmodel();
            return instance;
        }

        private string nick;
        public string Nick
        {
            get { return nick; }
            set
            {
                nick = value;
            }
        }
        private string curtools;
        public string Curtools
        {
            get { return curtools; }
            set
            {
                curtools = value;

            }
        }
        private string search;
        public string SEarch
        {
            get { return search; }
            set
            {
                search = value;

            }
        }
        private Zakaz curzakaz;
        public Zakaz Curzakaz
        {
            get { return curzakaz; }
            set
            {
                curzakaz = value;

            }
        }
        private string user;
        public string User
        {
            get { return user; }
            set
            {
                user = value;

            }
        }
        private Tovar curtools1;
        public Tovar Curtools1
        {
            get { return curtools1; }
            set
            {
                curtools1 = value;

            }
        }
        private string add_Cost;
        public string Add_Cost
        {
            get { return add_Cost; }
            set
            {
                add_Cost = value;

            }
        }
        private string info;
        public string Info
        {
            get { return info; }
            set
            {
                info = value;

            }
        }
        private string types;

  

        public string Types
        {
            get { return types; }
            set
            {
                types = value;

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
