using System;
using System.Collections.Generic;
using System.IO;

namespace ЛР__13
{
    class Program
    {
        static void Main(string[] args)
        {
            //AYVDirInfo.Info("D:\\Учеба\\ООП\\ЛР №13");
            //Separator();
            //AYVDiskInfo.Info();
            //Separator();
            //AYVFileInfo.Info(Path.GetRandomFileName());
            //Separator();

            //AYVFileManager.AYVInspector();
            List<string>? list = new List<string>();
            //list = AYVLog.SearchByDay("5");
            //list = AYVLog.Search("Adobe Photoshop 2020");
            //foreach (var sm in list)
            //    Console.WriteLine(sm);
            Console.WriteLine(AYVLog.RemoverByTime(Convert.ToDateTime("05.12.2020 17:03:17"), Convert.ToDateTime("05.12.2020 17:06:35")));

        }
        public static void Separator()
        {
            Console.WriteLine("----------------------------------");
        }
    }
}
    
