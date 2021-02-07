using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ЛР__13
{
    static class AYVDiskInfo
    {
        public static void Info() {
            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    Console.WriteLine("Имя диска: " + drive.Name);
                    Console.WriteLine("Файловая система: " + drive.DriveFormat);
                    Console.WriteLine("Тип диска: " + drive.DriveType);
                    Console.WriteLine("Общий объем свободного места (в байтах): " + drive.TotalFreeSpace);
                    Console.WriteLine("Размер диска (в байтах): " + drive.TotalSize);
                    Console.WriteLine("Метка тома диска: " + drive.VolumeLabel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
