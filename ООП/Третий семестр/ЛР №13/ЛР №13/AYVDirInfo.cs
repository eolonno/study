using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ЛР__13
{
    static class AYVDirInfo
    {
        public static void Info(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                Console.WriteLine("Количество файлов: " + directory.GetFiles().Length);
                Console.WriteLine("Время создания: " + directory.CreationTime);
                Console.WriteLine("Количество поддиректорий: " + directory.GetDirectories().Length);
                Console.WriteLine("Родительская директория: " + directory.Parent);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
