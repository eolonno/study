namespace LR11.Model {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;
  using System.Runtime.CompilerServices;

  [Table("GROUPS")]
  public partial class Group : INotifyPropertyChanged {


    private string name;
    private string spec;
    private int course;

    public Group() {
      Students = new HashSet<Student>();
    }

    public int GroupId { get; set; }


    /// <summary>
    /// в случае ошибок   
    /// сменить название поля, либо тут, либо в студенте    
    /// </summary>
    [StringLength(100)]
    public string Name {
      get => name;
      set {
        name = value;
        OnPropertyChanged("Name");
      }
    }

    [StringLength(100)]
    public string Spec {
      get => spec;
      set {
        spec = value;
        OnPropertyChanged("Spec");
      }
    }

    public int Course {
      get => course;
      set {
        course = value;
        OnPropertyChanged("Course");
      }
    }

    public virtual ICollection<Student> Students { get; set; }



    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "") {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
  }
}
