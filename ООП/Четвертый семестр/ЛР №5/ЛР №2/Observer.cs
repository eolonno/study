using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР__2
{
    class Observer : IObserver
    {
        public void Notify(string msg, string heading)
        {
            MessageBox.Show(msg, heading);
        }
    }
}
