using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LR11.Commands;
using LR11.Model;
using LR11.View;

namespace LR11.ViewModel
{
  class AppViewModel : INotifyPropertyChanged
  {

    Model.AppContext db;
    RelayCommand addGroupCommand;
    RelayCommand editGroupCommand;
    RelayCommand deleteGroupCommand;
    IEnumerable<Group> groups;
    Group selectedGroup;

    RelayCommand addStudCommand;
    RelayCommand editStudCommand;
    RelayCommand deleteStudCommand;
    IEnumerable<Student> students;
    Student selectedStudent;

    RelayCommand searchStudentByName;
    RelayCommand searchStudentByGroup;

    GroupWindow groupWindow;
    StudentWindow studWindow;



    public Group SelectedGroup
    {
      get => selectedGroup;
      set
      {
        selectedGroup = value;
        OnPropertyChanged("SelectedGroup");
        int curGroupId = selectedGroup.GroupId;
        Students = db.Students.Local.Where((s) => s.GroupId == curGroupId).ToList();
      }
    }

    public Student SelectedStudent
    {
      get => selectedStudent;
      set
      {
        selectedStudent = value;
        OnPropertyChanged("SelectedStudent");
      }
    }

    public IEnumerable<Group> Groups
    {
      get => groups;
      set
      {
        groups = value;
        OnPropertyChanged("Groups");
      }
    }

    public IEnumerable<Student> Students
    {
      get => students;
      set
      {
        students = value;
        OnPropertyChanged("Students");
      }
    }

    public AppViewModel()
    {
      db = new Model.AppContext();
      db.Groups.Load();
      db.Students.Load();

      Groups = db.Groups.Local.ToBindingList();
    }

   
    public RelayCommand AddGroupCommand
    {
      get
      {
        return addGroupCommand ??
          (addGroupCommand = new RelayCommand((o) => 
          {
            groupWindow = new GroupWindow(new Group());
            if (groupWindow.ShowDialog() == true)
            {
              Group group = groupWindow.Group;
              db.Groups.Add(group);
              db.SaveChanges();
            }
          }));
      }
    }

   
    public RelayCommand EditGroupCommand
    {
      get
      {
        return editGroupCommand ??
          (editGroupCommand = new RelayCommand((selectedItem) => 
          {
            if (selectedItem == null) return;
            
            Group group = selectedItem as Group;

            Group ng = new Group() {
              GroupId = group.GroupId,
              Name = group.Name,
              Spec = group.Spec,
              Course = group.Course
            };

            groupWindow = new GroupWindow(ng);

            if (groupWindow.ShowDialog() == true)
            {
              
              group = db.Groups.Find(groupWindow.Group.GroupId);
              if (group != null)
              {
                group.Name = groupWindow.Group.Name;
                group.Spec = groupWindow.Group.Spec;
                group.Course = groupWindow.Group.Course;
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
              }
            }
          }));
      }
    }

    
    public RelayCommand DeleteGroupCommand
    {
      get
      {
        return deleteGroupCommand ??
          (deleteGroupCommand = new RelayCommand((selectedItem) => 
          {
            if (selectedItem == null) return;
            
            Group group = selectedItem as Group;
            db.Groups.Remove(group);
            db.SaveChanges();
          }));
      }
    }


   
    public RelayCommand AddStudCommand
    {
      get
      {
        return addStudCommand ??
          (addStudCommand = new RelayCommand((o) => 
          {
            studWindow = new StudentWindow(new Student { GroupId = SelectedGroup.GroupId });
            if (studWindow.ShowDialog() == true)
            {
              Student stud = studWindow.Student;
              db.Students.Add(stud);
              db.SaveChanges();
              int curGroupId = selectedGroup.GroupId;
              Students = db.Students.Local.Where((s) => s.GroupId == curGroupId).ToList();
            }
          }));
      }
    }

    
    public RelayCommand EditStudCommand
    {
      get
      {
        return editStudCommand ??
          (editStudCommand = new RelayCommand((selectedItem) => 
          {
            if (selectedItem == null) return;
            
            Student student = selectedItem as Student;

            Student ns = new Student()
            {
              StudentId = student.StudentId,
              Name = student.Name,
              Note = student.Note,
              GroupId = student.GroupId
            };

            studWindow = new StudentWindow(ns);

            if (studWindow.ShowDialog() == true)
            {
              
              student = db.Students.Find(studWindow.Student.StudentId);
              if (student != null)
              {
                student.Name = studWindow.Student.Name;
                student.Note = studWindow.Student.Note;
                student.GroupId = studWindow.Student.GroupId;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
              }
            }
          }));
      }
    }

   
    public RelayCommand DeleteStudCommand
    {
      get
      {
        return deleteStudCommand ??
          (deleteStudCommand = new RelayCommand((selectedItem) => 
          {
            if (selectedItem == null) return;
           
            Student stud = selectedItem as Student;
            db.Students.Remove(stud);
            db.SaveChanges();
            int curGroupId = selectedGroup.GroupId;
            Students = db.Students.Local.Where((s) => s.GroupId == curGroupId).ToList();
          }));
      }
    }

    public RelayCommand SearchStudentByName
    {
      get
      {
        return searchStudentByName ??
          (searchStudentByName = new RelayCommand((SearchStudentName) => 
          {
            if (SearchStudentName == null) return;
          
            try
            {
              string stdName = SearchStudentName as string;

              if (stdName.Length > 0)
              {
                var stud = db.Students.Local.FirstOrDefault((s) => s.Name.Contains(stdName));
                if (stud != null)
                {
                  SelectedGroup = Groups.First((g) => g.GroupId == stud.GroupId);
                  SelectedStudent = stud;
                } else
                {
                  MessageBox.Show("Not found");
                }
              }
            } catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }));
      }
    }

    public RelayCommand SearchStudentByGroup
    {
      get
      {
        return searchStudentByGroup ??
          (searchStudentByGroup = new RelayCommand((SearchStudentGroup) => 
          {
            if (SearchStudentGroup == null) return;

            try
            {
                                 
              string groupName = SearchStudentGroup as string;

              if (groupName.Length > 0)
              {
                var group = Groups.FirstOrDefault((g) => g.Name.Contains(groupName));

                if (group != null)
                {
                  SelectedGroup = group;
                } else
                {
                  MessageBox.Show("Not found");
                }
              }
            } catch (Exception exp)
            {
              MessageBox.Show(exp.Message);
            }
          }));
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
