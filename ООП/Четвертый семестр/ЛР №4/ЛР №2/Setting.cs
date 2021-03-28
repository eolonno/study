using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР__2
{
    class Settings
    {
        private static Settings instance;
        public readonly string settings = $"Цвет фона: {Form1.DefaultBackColor}\nРазмер стандартного шрифта:{Form1.DefaultFont.Size}";
        private Settings() { }
        public static Settings GetSettings()
        {
            return instance ?? (instance = new Settings());
        }
    }
}
