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
using Dormitory.Data;
using Dormitory.Models;
using Dormitory.Views.UserWindows;
using System.Linq;

namespace Dormitory.Frames.UserFrames
{
    /// <summary>
    /// Логика взаимодействия для UserRegOnDutyFrame.xaml
    /// </summary>
    public partial class UserRegOnDutyFrame : UserControl
    {
        private List<Duty> _duties { get; set; }
        public List<Duty> duties
        {
            get { return _duties; }
            set
            {
                var OrderedList = value.OrderBy(x => x.TimeOfDuty).Select(x => x);
                if (_duties != null)
                    _duties.Clear();
                foreach (var v in OrderedList)
                    _duties.Add(v as Duty);
            }
        }
        public UserRegOnDutyFrame()
        {
            InitializeComponent();
            _duties = new List<Duty>();
            duties = DataWorker.GetAllDuties();

            if (duties[duties.Count - 1].TimeOfDuty.Month != DateTime.Now.Month)
            {
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                while (startDate != endDate)
                {
                    DateTime TimeToDuty = new DateTime(startDate.Year, startDate.Month, startDate.Day, 8, 0, 0);
                    for (int i = 0; i < 7; i++)
                    {
                        DataWorker.AddDutyTime(TimeToDuty);
                        TimeToDuty = TimeToDuty.AddHours(2).AddMinutes(30);
                    }
                    startDate = startDate.AddDays(1);
                }
            }

            duties = DataWorker.GetAllDuties();
            DutiesDataGrid.ItemsSource = duties;
            DutiesDataGrid.SelectedCellsChanged += DutiesDataGrid_SelectedCellsChanged;
        }

        private void DutiesDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Duty SelectedDuty = DutiesDataGrid.SelectedItem as Duty;
            if (SelectedDuty != null)
            {
                if (SelectedDuty.Orderly == null)
                    DataWorker.SignUpToDuty(SelectedDuty);
                else if (SelectedDuty.Orderly == DataWorker.User.Nickname)
                    DataWorker.RemoveDuty(SelectedDuty);
                DutiesDataGrid.ItemsSource = null;
                duties = DataWorker.GetAllDuties();
                DutiesDataGrid.ItemsSource = duties;
            }
        }
    }
}
