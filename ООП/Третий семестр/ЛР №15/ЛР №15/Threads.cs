using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;


namespace ЛР__15
{
    public static class Threads
    {
        public static void ProcessInfo()
        {
            string Path = "ProcessInfo.txt";
            using (StreamWriter sw = new StreamWriter(Path, false, Encoding.Default))
            {
                foreach (Process process in Process.GetProcesses())
                {
                    try
                    {
                        sw.WriteLine($"Process name: {process.ProcessName}\n" +
                            $"ID: {process.Id}\n" +
                            $"Priority: {process.PriorityClass}\n" +
                            $"Start time: {process.StartTime}\n" +
                            $"Total processor time: {process.TotalProcessorTime}");
                        sw.WriteLine("-------------------------\n");
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
        public static void WorkWithDomain()
        {
            string Path = "DomainInfo.txt";
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            using (StreamWriter sw = new StreamWriter(Path, false, Encoding.Default))
            {
                sw.WriteLine($"Name: {CurrentDomain.FriendlyName}\n" +
                    $"Setup information: {CurrentDomain.SetupInformation}\n");
                sw.WriteLine("All assemblies:");
                foreach (var assembly in CurrentDomain.GetAssemblies())
                    sw.WriteLine(assembly.FullName);
            }

            // New domain
            //AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            //foreach (var assembly in CurrentDomain.GetAssemblies())
            //    newDomain.Load(assembly.FullName);
            //AppDomain.Unload(newDomain);
        }
        private static Mutex mutex = new Mutex();
        public static void ThreadingCounter()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(Thread1));
            Thread thread2 = new Thread(new ParameterizedThreadStart(Thread2));
            Console.Write("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            thread1.Start(n);
            thread2.Start(n);
        }
        private static void Thread1(object N)
        {
            for (int i = 1; i <= (int)N; i++)
            {
                mutex.WaitOne();
                Console.WriteLine("Thread 1 works: " + i);
                Console.WriteLine($"Thread info:\n{ThreadInfo(Thread.CurrentThread)}");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
            }
        }
        private static void Thread2(object N)
        {
            for (int i = 1; i <= (int)N; i++)
            {
                mutex.WaitOne();
                Console.WriteLine("Thread 2 works: " + i);
                Console.WriteLine($"Thread info:\n{ThreadInfo(Thread.CurrentThread)}");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
            }
        }
        private static string ThreadInfo(Thread thread)
        {
            return $"Status: {thread.ThreadState}\n" +
                $"Name: {thread.Name}\n" +
                $"Priority: {thread.Priority}\n" +
                $"ID: {thread.GetHashCode()}\n" +
                $"-------------------------------------------";
        }
        public struct ThreadsSettings
        {
            public int N { get; set; }
            public bool InTurn { get; set; }
            public ThreadsSettings(int n, bool inTurn)
            {
                N = n;
                InTurn = inTurn;
            }
        }
        private static string path = "ThreadingSplitCounter.txt";
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public static void ThreadingSplitCounter(bool InTurn)
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(Thread3));
            Thread thread2 = new Thread(new ParameterizedThreadStart(Thread4));

            Console.Write("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            thread1.Priority = ThreadPriority.Highest;
            ThreadsSettings TS = new ThreadsSettings(n, InTurn);
            
            thread1.Start(TS);
            thread2.Start(TS);
        }
        private static void Thread3(object threadsSettings)
        {
            if (!((ThreadsSettings)threadsSettings).InTurn)
                autoResetEvent.WaitOne();
            for (int i = 1; i <= ((ThreadsSettings)threadsSettings).N; i+=2)
            {
                using(StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    string Message = "Thread 1: " + i;
                    Console.WriteLine(Message);
                    sw.WriteLine(Message);
                }
                Thread.Sleep(1000);

                if ((i == ((ThreadsSettings)threadsSettings).N - 1 || i == ((ThreadsSettings)threadsSettings).N) && ((ThreadsSettings)threadsSettings).InTurn == false)
                    autoResetEvent.Close();
                else
                {
                    autoResetEvent.Set();
                    autoResetEvent.WaitOne();
                }
            }
        }
        private static void Thread4(object threadsSettings)
        {
            if (((ThreadsSettings)threadsSettings).InTurn)
                autoResetEvent.WaitOne();
            for (int i = 2; i <= ((ThreadsSettings)threadsSettings).N; i += 2)
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    string Message = "Thread 2: " + i;
                    Console.WriteLine(Message);
                    sw.WriteLine(Message);
                }
                Thread.Sleep(300);
                autoResetEvent.Set();
                if(i == ((ThreadsSettings)threadsSettings).N)
                    autoResetEvent.Close();
                else
                    autoResetEvent.WaitOne();
            }
        }
        private static int Seconds = 1;
        public static void TimerProgram()
        {
            Timer timer = new Timer(new TimerCallback(TimerThread), null, 0, 1000);
            Thread.Sleep(9000);
        }
        private static void TimerThread(object obj)
        {
            Console.WriteLine("Секунд прошло с начала работы таймера: " + Seconds++);
        }
    }
}
