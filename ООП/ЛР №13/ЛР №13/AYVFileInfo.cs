using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ЛР__13
{
    static class AYVFileInfo
    {
        public static void Info(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                Console.WriteLine("Польный путь: " + file.FullName);
                Console.WriteLine("Размер:" + file.Length);
                Console.WriteLine("Расширение: " + file.Extension);
                Console.WriteLine("Имя: " + file.Name);
                Console.WriteLine("Дата создания: " + File.GetCreationTime(path));
                Console.WriteLine("Дата изменения: " + File.GetLastWriteTime(path));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
