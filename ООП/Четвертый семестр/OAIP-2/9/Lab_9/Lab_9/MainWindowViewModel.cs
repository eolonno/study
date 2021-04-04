using Lab_9.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string nameSubj;
        public string NameSubj
        {
            get { return nameSubj; }
            set
            {
                nameSubj = value;
                OnPropertyChanged("NameSubj");
            }
        }
        private string fiol;
        public string Fiol
        {
            get { return fiol; }
            set
            {
                fiol = value;
                OnPropertyChanged("Fiol");
            }
        }

        private string hours;
        public string Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged("Hours");
            }
        }

        private string fios;
        public string Fios
        {
            get { return fios; }
            set
            {
                fios = value;
                OnPropertyChanged("Fios");
            }
        }

        private string subjDr;
        public string SubjDr
        {
            get { return subjDr; }
            set
            {
                subjDr = value;
                OnPropertyChanged("SubjDr");
            }
        }
        private string studDr;
        public string StudDr
        {
            get { return studDr; }
            set
            {
                studDr = value;
                OnPropertyChanged("StudDr");
            }
        }


        private string oldL;
        public string OldL
        {
            get { return oldL; }
            set
            {
                oldL = value;
                OnPropertyChanged("OldL");
            }
        }
        private string newL;
        public string NewL
        {
            get { return newL; }
            set
            {
                newL = value;
                OnPropertyChanged("NewL");
            }
        }

        private string searhN;
        public string SearhN
        {
            get { return searhN; }
            set
            {
                searhN = value;
                OnPropertyChanged("SearhN");
            }
        }
        private string searhH;
        public string SearhH
        {
            get { return searhH; }
            set
            {
                searhH = value;
                OnPropertyChanged("SearhH");
            }
        }

        private string column;
        public string Column
        {
            get { return column; }
            set
            {
                column = value;
                OnPropertyChanged("Column");
            }
        }

        private string subSubject;
        public string SubSubject
        {
            get { return subSubject; }
            set
            {
                subSubject = value;
                OnPropertyChanged("SubSubject");
            }
        }
        private string subStudent;
        public string SubStudent
        {
            get { return subStudent; }
            set
            {
                subStudent = value;
                OnPropertyChanged("SubStudent");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set
            {
                subjects = value;
                OnPropertyChanged("Subjects");
            }
        }
        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged("Students");
            }
        }

        private ObservableCollection<Subject> searhL;
        public ObservableCollection<Subject> SearhL
        {
            get { return searhL; }
            set
            {
                searhL = value;
                OnPropertyChanged("SearhL");
            }
        }

        private ObservableCollection<SubjectStudent> subjectStudent;
        public ObservableCollection<SubjectStudent> SubjectStudent
        {
            get { return subjectStudent; }
            set
            {
                subjectStudent = value;
                OnPropertyChanged("SubjectStudent");
            }
        }

        private RelayCommand addSubject;
        public RelayCommand AddSubject
        {
            get
            {
                return addSubject ??
                    (addSubject = new RelayCommand(obj =>
                    {
                        Subjects = MainWindowModel.AddSubject(NameSubj, Fiol, Convert.ToInt32(Hours));
                    }));
            }
        }

        private RelayCommand addStudent;
        public RelayCommand AddStudent
        {
            get
            {
                return addStudent ??
                    (addStudent = new RelayCommand(obj =>
                    {
                            Students = MainWindowModel.AddStudent(Fios);
                    }));
            }
        }

        private RelayCommand load;
        public RelayCommand Load
        {
            get
            {
                return load ??
                    (load = new RelayCommand(obj =>
                    {
                        Subjects = MainWindowModel.LoadSubject();
                        Students = MainWindowModel.LoadStudent();
                        SubjectStudent = MainWindowModel.LoadSS();
                    }));
            }
        }

        private RelayCommand dropSubject;
        public RelayCommand DropSubject
        {
            get
            {
                return dropSubject ??
                    (dropSubject = new RelayCommand(obj =>
                    {
                        Subjects = MainWindowModel.DropSubject(Convert.ToInt32(SubjDr));
                    }));
            }
        }

        private RelayCommand dropStudent;
        public RelayCommand DropStudent
        {
            get
            {
                return dropStudent ??
                    (dropStudent = new RelayCommand(obj =>
                    {
                        Students = MainWindowModel.DropStudent(Convert.ToInt32(StudDr));
                    }));
            }
        }

        private RelayCommand editing;
        public RelayCommand Editing
        {
            get
            {
                return editing ??
                    (editing = new RelayCommand(obj =>
                    {
                        Subjects = MainWindowModel.Editing(OldL, NewL);
                    }));
            }
        }

        private RelayCommand sort;
        public RelayCommand Sort
        {
            get
            {
                return sort ??
                    (sort = new RelayCommand(obj =>
                    {
                        SearhL = MainWindowModel.Sort(Column);
                    }));
            }
        }

        private RelayCommand searh;
        public RelayCommand Searh
        {
            get
            {
                return searh ??
                    (searh = new RelayCommand(obj =>
                    {
                        SearhL = MainWindowModel.Searh(SearhN, Convert.ToInt32(SearhH));
                    }));
            }
        }

        private RelayCommand transaction;
        public RelayCommand Transaction
        {
            get
            {
                return transaction ??
                    (transaction = new RelayCommand(obj =>
                    {
                        Subjects = MainWindowModel.Transaction();
                    }));
            }
        }

        private RelayCommand subscription;
        public RelayCommand Subscription
        {
            get
            {
                return subscription ??
                    (subscription = new RelayCommand(obj =>
                    {
                        SubjectStudent=MainWindowModel.Subscription(Convert.ToInt32(SubSubject), Convert.ToInt32(SubStudent));
                    }));
            }
        }

        private RelayCommand unsubscribing;
        public RelayCommand Unsubscribing
        {
            get
            {
                return unsubscribing ??
                    (unsubscribing = new RelayCommand(obj =>
                    {
                        SubjectStudent=MainWindowModel.Unsubscription(Convert.ToInt32(SubSubject), Convert.ToInt32(SubStudent));
                    }));
            }
        }

        private RelayCommand asyns;
        public RelayCommand Asyns
        {
            get
            {
                return asyns ??
                    (asyns = new RelayCommand(obj =>
                    {
                        Task t = MainWindowModel.GetObjectsAsync();
                    }));
            }
        }
    }
}
