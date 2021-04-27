using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ЛР__9
{
    public static class UserRoutedUICommand
    {
        static RoutedUICommand changeBackground = new RoutedUICommand("Изменить фон", "ChangeBackground", typeof(UserRoutedUICommand));
        public static RoutedUICommand ChangeBackground { get { return changeBackground; } }
    }
}
