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
using LR11.ViewModel;

namespace LR11.View
{
  public partial class GroupWindow : Window
  {

    public Group Group { get; private set; }

    public GroupWindow(Group gr)
    {
      InitializeComponent();
      Group = gr;
      this.DataContext = Group;
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }
  }
}
