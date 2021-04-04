using Lab_9.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_9
{
    class MainWindowModel
    {
        public static async Task GetObjectsAsync()
        {
            using (var connect = new MyDbConnect())
            {
                await connect.Students.ForEachAsync(p =>
                {
                    MessageBox.Show(p.FIO);
                });
            }
        }

        public static ObservableCollection<SubjectStudent> Subscription(int IdSubject, int IdStudent)
        {
            List<SubjectStudent> SS = new List<SubjectStudent>();
            using (var connect = new MyDbConnect())
            {
                Subject subject = connect.Subjects.FirstOrDefault(x => x.IdSubject == IdSubject);
                Student student = connect.Students.FirstOrDefault(x => x.IdStudent == IdStudent);
                subject.Students.Add(student);
                connect.SaveChanges();
                foreach(Subject subj in connect.Subjects.ToList())
                {
                    foreach(Student stud in subj.Students.ToList())
                    {
                        SubjectStudent ss = new SubjectStudent();
                        ss.IdSubject = subj.IdSubject;
                        ss.IdStudent = stud.IdStudent;
                        SS.Add(ss);
                    }
                }
            }
            return new ObservableCollection<SubjectStudent>(SS);
        }

        public static ObservableCollection<SubjectStudent> Unsubscription(int IdSubject, int IdStudent)
        {
            List<SubjectStudent> SS = new List<SubjectStudent>();
            using (var connect = new MyDbConnect())
            {
                Subject subject = connect.Subjects.FirstOrDefault(x => x.IdSubject == IdSubject);
                Student student = connect.Students.FirstOrDefault(x => x.IdStudent == IdStudent);
                subject.Students.Remove(student);
                connect.SaveChanges();
                foreach (Subject subj in connect.Subjects.ToList())
                {
                    foreach (Student stud in subj.Students.ToList())
                    {
                        SubjectStudent ss = new SubjectStudent();
                        ss.IdSubject = subj.IdSubject;
                        ss.IdStudent = stud.IdStudent;
                        SS.Add(ss);
                    }
                }
            }
            return new ObservableCollection<SubjectStudent>(SS);
        }

        public static ObservableCollection<Subject> Transaction()
        {
            using (var connect = new MyDbConnect())
            {
                using (var transaction = connect.Database.BeginTransaction())
                {
                    try
                    {
                        connect.Database.ExecuteSqlCommand(@"UPDATE Subjects SET Hourse = Hourse + 1 WHERE Hourse = 36");
                        connect.Subjects.Add(new Subject { Name = "JS", FIOl = "Мельников Парамон Филиппович", Hourse=26});
                        connect.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
                return new ObservableCollection<Subject>(connect.Subjects.ToList());
            }
        }

        public static ObservableCollection<Subject> Searh(string Name, int Hourse)
        {
            using (var connect = new MyDbConnect())
            {
                var subject = connect.Subjects.Where(x => x.Name == Name & x.Hourse == Hourse);

                return new ObservableCollection<Subject>(subject);
            }
        }

        public static ObservableCollection<Subject> Sort(string Column)
        {
            using (var connect = new MyDbConnect())
            {
                var subject = connect.Database.SqlQuery<Subject>($"SELECT * FROM Subjects ORDER BY {Column}");

                return new ObservableCollection<Subject>(subject);
            }
        }

        public static ObservableCollection<Subject> Editing(string Old, string New)
        {
            using (var connect = new MyDbConnect())
            {
                connect.Database.ExecuteSqlCommand($"UPDATE Subjects SET FIOl = '{New}' WHERE FIOl = '{Old}'");
                connect.SaveChanges();

                return new ObservableCollection<Subject>(connect.Subjects.ToList());
            }
        }

        public static ObservableCollection<Subject> DropSubject(int Id)
        {
            using (var connect = new MyDbConnect())
            {
                connect.Subjects.Remove(connect.Subjects.First(x => x.IdSubject == Id));
                connect.SaveChanges();

                return new ObservableCollection<Subject>(connect.Subjects.ToList());
            }
        }

        public static ObservableCollection<Student> DropStudent(int Id)
        {
            using (var connect = new MyDbConnect())
            {
                connect.Students.Remove(connect.Students.First(x => x.IdStudent == Id));
                connect.SaveChanges();

                return new ObservableCollection<Student>(connect.Students.ToList());
            }
        }

        public static ObservableCollection<Subject> AddSubject(string name, string fio, int hourse)
        {
            using (var connect = new MyDbConnect())
            {
                Subject subject = new Subject()
                {
                    Name = name,
                    FIOl = fio,
                    Hourse = hourse
                };
                connect.Subjects.Add(subject);
                connect.SaveChanges();

                return new ObservableCollection<Subject>(connect.Subjects.ToList());
            }
        }

        public static ObservableCollection<Student> AddStudent(string fio)
        {
            using (var connect = new MyDbConnect())
            {
                Student student = new Student()
                {
                    FIO = fio
                };
                connect.Students.Add(student);
                connect.SaveChanges();

                return new ObservableCollection<Student>(connect.Students.ToList());
            }
        }

         public static ObservableCollection<Student> LoadStudent()
        {
            using (var connect = new MyDbConnect())
            {
                return new ObservableCollection<Student>(connect.Students.ToList());
            }
        }

        public static ObservableCollection<Subject> LoadSubject()
        {
            using (var connect = new MyDbConnect())
            {
                return new ObservableCollection<Subject>(connect.Subjects.ToList());
            }

        }

        public static ObservableCollection<SubjectStudent> LoadSS()
        {
            List<SubjectStudent> SS = new List<SubjectStudent>();
            using (var connect = new MyDbConnect())
            {
                foreach (Subject subj in connect.Subjects.ToList())
                {
                    foreach (Student stud in subj.Students.ToList())
                    {
                        SubjectStudent ss = new SubjectStudent();
                        ss.IdSubject = subj.IdSubject;
                        ss.IdStudent = stud.IdStudent;
                        SS.Add(ss);
                    }
                }
            }
            return new ObservableCollection<SubjectStudent>(SS);
        }
    }
}
