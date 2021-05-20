using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dormitory.Models;
using Dormitory.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dormitory.Frames.AdminFrames
{
    /// <summary>
    /// Логика взаимодействия для DutiesListFrame.xaml
    /// </summary>
    public partial class DutiesListFrame : UserControl
    {
        private List<Duty> _duties { get; set; }
        public List<Duty> duties { 
            get { return _duties; }
            set
            {
                var OrderedList = value.OrderBy(x => x.TimeOfDuty).Select(x => x);
                if(_duties != null)
                    _duties.Clear();
                foreach (var v in OrderedList)
                    _duties.Add(v as Duty);
            }
        }
        public DutiesListFrame()
        {
            InitializeComponent();
            _duties = new List<Duty>();
            duties = DataWorker.GetAllDuties();
            DutiesDataGrid.ItemsSource = duties;
            DutiesDataGrid.SelectedCellsChanged += DutiesDataGrid_SelectedCellsChanged;
        }

        private void DutiesDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataWorker.RefreshDutues(duties);
            //Duty SelectedDuty = DutiesDataGrid.SelectedItem as Duty;
            //if (SelectedDuty != null)
            //{
            //    DataWorker.SignUpToDutyForAdmin(SelectedDuty);
            //    DutiesDataGrid.ItemsSource = null;
            //    duties = DataWorker.GetAllDuties();
            //    DutiesDataGrid.ItemsSource = duties;
            //}
        }
    }
}
