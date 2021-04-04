namespace LR11.Model {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;
  using System.Runtime.CompilerServices;

  [Table("STUDENT")]
  public partial class Student : INotifyPropertyChanged {
    private int group;
    private string name;
    private double note;

    public int StudentId { get; set; }

    public int GroupId {
      get => group;
      set {
        group = value;
        OnPropertyChanged("GroupId");
      }
    }

    [StringLength(100)]
    public string Name {
      get => name;
      set {
        name = value;
        OnPropertyChanged("Name");
      }
    }

    public double Note {
      get => note;
      set {
        note = value;
        OnPropertyChanged("Note");
      }
    }

    public virtual Group GROUP { get; set; }



    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "") {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
  }
}
