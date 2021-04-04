using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LR11.Model;

namespace LR11.View
{
  public partial class StudentWindow : Window
  {
    public Student Student { get; private set; }

    public StudentWindow(Student st)
    {
      InitializeComponent();
      Student = st;
      this.DataContext = Student;
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }
  }
}
