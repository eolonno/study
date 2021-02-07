using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ЛР__13
{
    static class AYVFileManager
    {
        public static void AYVInspector()
        {
            Directory.CreateDirectory("AYVInspect");
            var drive = DriveInfo.GetDrives()[1];
            string Message = "Список файлов и папок:\n";
            Message += FilesAndDirectories(drive.Name);
            File.AppendAllText("AYVInspect/Disk" + drive.Name.Remove(1) + "Info.txt", Message);
            File.Copy("AYVInspect/Disk" + drive.Name.Remove(1) + "Info.txt", "AYVInspect/Disk" + drive.Name.Remove(1) + "Info[1].txt");
            File.Delete("AYVInspect/Disk" + drive.Name.Remove(1) + "Info.txt");

            
        }
        private static string FilesAndDirectories(string path)
        {
            string Message = "";
            List<string> ls = GetRecursFiles(path);
            foreach (string fname in ls)
            {
                Message += fname;
            }
            return Message;
        }
        private static List<string> GetRecursFiles(string start_path)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(start_path);
                foreach (string folder in folders)
                {
                    ls.Add("Папка: " + folder + "\n");
                    ls.AddRange(GetRecursFiles(folder));
                    AYVLog.Log(folder, "Чтение имени папки");
                }
                string[] files = Directory.GetFiles(start_path);
                foreach (string filename in files)
                {
                    ls.Add("Файл: " + filename + "\n");
                    AYVLog.Log(filename, "Чтение имени файла");
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return ls;
        }
    }
}
