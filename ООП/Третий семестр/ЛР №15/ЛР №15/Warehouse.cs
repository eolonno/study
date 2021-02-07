using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Linq;

namespace ЛР__15
{
    static class Warehouse
    {
        private static string Path = "Goods.txt";
        private static int Carriage = 0;
        private static Mutex mutex = new Mutex();
        private struct MachineInfo
        {
            public int Time { get; set; }
            public int Number { get;  }
            public MachineInfo(int time, int num)
            {
                Time = time;
                Number = num;
            }
        }
        public static void WarehouseUnloading()
        {
            new Thread(new ParameterizedThreadStart(Machine)).Start(new MachineInfo(100, 1));
            new Thread(new ParameterizedThreadStart(Machine)).Start(new MachineInfo(300, 2));
            new Thread(new ParameterizedThreadStart(Machine)).Start(new MachineInfo(150, 3));
        }
        private static void Machine(object MachineInfo)
        {
            while (Carriage != File.ReadLines(Path).Count())
            {
                mutex.WaitOne();
                if(Carriage != File.ReadLines(Path).Count())
                    Console.WriteLine("Машина №" + ((MachineInfo)MachineInfo).Number + ": " + File.ReadLines(Path).ElementAt(Carriage++));
                Thread.Sleep(((MachineInfo)MachineInfo).Time);
                mutex.ReleaseMutex();
            }
        }
    }
}
