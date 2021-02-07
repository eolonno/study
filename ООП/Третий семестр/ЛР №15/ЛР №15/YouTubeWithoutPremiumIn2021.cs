using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ЛР__15
{
    static class YouTubeWithoutPremiumIn2021
    {
        private static SemaphoreSlim Semaphore = new SemaphoreSlim(1);
        private struct UseInfo
        {
            public int Time { get; }
            public User user { get; }
            public List<Channel> Channels { get; }
            public bool IsWorks { get; set; }
            public UseInfo(User u, List<Channel> channels, int time)
            {
                Time = time;
                user = u;
                Channels = channels;
                IsWorks = true;
            }
        }
        private static int TimeToExit = 5000;
        public static void Work()
        {
            List<User> Users = new List<User>();
            Users.Add(new User("Иван"));
            Users.Add(new User("Петр"));
            Users.Add(new User("Алексей"));
            Users.Add(new User("Василий"));

            List<Channel> Channels = new List<Channel>();
            Channels.Add(new Channel("BBC"));
            Channels.Add(new Channel("T-Series"));

            Random rnd = new Random();

            foreach(var u in Users)
            {
                Thread.Sleep(50);
                new Thread(new ParameterizedThreadStart(ChannelUse)).Start(new UseInfo(u, Channels, rnd.Next(2000, 7000)));
            }
        }
        private static void ChannelUse(object Info)
        {
            UseInfo useInfo = (UseInfo)Info;
            Timer timer = new Timer(new TimerCallback(UserLeave), useInfo, TimeToExit, 0);
            Random rnd = new Random();
            while (true)
            {
                foreach (var channel in useInfo.Channels)
                {
                    Semaphore.Wait();
                    if (useInfo.IsWorks == false)
                        goto END;
                    if (channel.Used == false)
                    {
                        timer.Change(TimeToExit + useInfo.Time + 10, 0);
                        channel.Used = true;
                        channel.UserName = useInfo.user.Name;
                        Console.WriteLine($"{channel.Name} используется пользователем {useInfo.user.Name}.");
                        Semaphore.Release();
                        Thread.Sleep(useInfo.Time);
                        Semaphore.Wait();
                        channel.Used = false;
                        channel.UserName = null;
                        Console.WriteLine($"{useInfo.user.Name} покинул канал {channel.Name}.");
                        timer.Change(TimeToExit, 0);
                        Semaphore.Release();
                        Thread.Sleep(rnd.Next(700, 3000));
                        Semaphore.Wait();
                    }
                    Semaphore.Release();
                }
            }
            END:
                return;
        }
        private static void UserLeave(object useInfo)
        {
            UseInfo Info = (UseInfo)useInfo;
            Info.IsWorks = false;
            Console.WriteLine(((UseInfo)useInfo).user.Name + " покинул сервис.");
        }
    }
}
