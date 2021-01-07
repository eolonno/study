using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> Users = new List<User>();
            Users.Add(new User("Ivan", "a@example.com", "123"));
            Users.Add(new User("Petr", "c@example.com", "123"));
            Users.Add(new User("Gosha", "a@example.com", "123"));
            Users.Add(new User("Daniil", "a@example.com", "123"));
            Users.Add(new User("Alexey", "op@example.com", "123"));

            for (int i = 0; i < Users.Count - 1; i++)
                Console.WriteLine($"Результат сравнения {Users[i]} и {Users[i + 1]}: {Users[i].CompareTo(Users[i + 1])}");

            foreach (var user in Users)
            {
                WebNet.Add(user);
                Console.WriteLine(user.Status);
            }

            Console.WriteLine("Count: " + WebNet.CountOfSingIn());
            WebNet.Serialization();

        }
        public static class WebNet
        {
            private static LinkedList<User> GitHub = new LinkedList<User>();
            public static void Add(User u)
            {
                GitHub.AddLast(u);
            }
            public static void Remove(User u)
            {
                GitHub.Remove(u);
            }
            public static int CountOfSingIn()
            {
                return GitHub.Where(x => x.Status == Statuses.SingnIn).Count();
            }
            public static void Serialization()
            {
                
                using (FileStream fs = new FileStream("Users.bin", FileMode.Create))
                {
                    List<User> Users = new List<User>();
                    foreach (var user in GitHub.Where(x => x.Status == Statuses.SingnIn))
                        Users.Add(user);
                    //XmlSerializer xml = new XmlSerializer(Users.GetType());
                    //xml.Serialize(fs, Users);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, Users);

                }
            }
        }
        [Serializable]
        public class User : IComparable
        {
            public User(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
                Random rnd = new Random();
                Status = (Statuses)rnd.Next(0, 2);
                ID = id++;
            }
            private static int id = 1;
            public string Name { get; set; }
            public int ID { get; private set; }
            private string Email { get; set; }
            private string Password { get; set; }
            public Statuses Status { get; set; }

            public int CompareTo(object obj)
            {
                return Email.CompareTo(((User)obj).Email);
            }

            public override bool Equals(object obj)
            {
                return ID == ((User)obj).ID;
            }
            public override int GetHashCode()
            {
                return ID;
            }
            public override string ToString()
            {
                return Name;
            }

        }
        public enum Statuses
        {
            SingnIn,
            SingOut
        }
    }
}
