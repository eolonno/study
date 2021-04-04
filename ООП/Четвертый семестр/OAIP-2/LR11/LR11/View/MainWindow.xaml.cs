using System.Windows;
using LR11.ViewModel;

namespace LR11.View
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = new AppViewModel();
    }
  }
}
