using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text.Json;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> Users = new List<User>();
            Users.Add(new User(){ Login = "user1", Name = "Bob", Password = "123"});
            Users.Add(new User(){ Login = "user2", Name = "Nick", Password = "343"});
            Users.Add(new User(){ Login = "user3", Name = "Ivan", Password = "562"});
            Users.Add(new User(){ Login = "user4", Name = "Josh", Password = "294"});

            Serialization.XML(Users);
        }
        [Serializable]
        public class User
        {
            public string Name { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public User(){}
        }
        internal static class Serialization
        {
            public static void XML(List<User> Users)
            {
                XmlSerializer xml = new XmlSerializer(typeof(User));
                using (FileStream fs = new FileStream("xml.xml", FileMode.Create))
                {
                    xml.Serialize(fs, Users);
                }
            }
            public static void JSON(List<User> Users)
            {
                using(StreamWriter fs = new StreamWriter("json.json"))
                {
                    fs.WriteLine(JsonSerializer.Serialize(Users));
                }
            }
            public static void Binary(List<User> Users)
            {
                using(FileStream fs = new FileStream("bin.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(fs, Users);
                }
            }
            //public static void SOAP(List<User> Users)
            //{
            //    SoapFormatter soap = new SoapFormatter();
            //    using(FileStream fs = new FileStream("soap.soap", FileMode.Create))
            //    {
            //        soap.Serialize(fs, Users);
            //    }
            //}
            public static void JSONContracts(List<User> Users)
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<User>));

                using (FileStream fs = new FileStream("json1.json", FileMode.Create))
                {
                    json.WriteObject(fs, Users);
                }
            }
            public static void XMLContracts(List<User> Users)
            {
                DataContractSerializer xml = new DataContractSerializer(typeof(List<User>));
                using(FileStream fs = new FileStream("xml1.xml", FileMode.Create))
                {
                    xml.WriteObject(fs, Users);
                }
            }
        }
    }
}
