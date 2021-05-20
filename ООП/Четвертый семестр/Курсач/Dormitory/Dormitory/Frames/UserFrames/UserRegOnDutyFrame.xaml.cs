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
        public List<Duty> duties { get; set; }
        public UserRegOnDutyFrame()
        {
            InitializeComponent();

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
        }

        private void SignUpToDuty(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
