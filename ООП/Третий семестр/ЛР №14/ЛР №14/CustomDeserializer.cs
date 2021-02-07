using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace ЛР__14
{
    public static class CustomDeserializer
    {
        public static List<Circle> JSONDeserializer()
        {
            using (FileStream fs = File.OpenRead("Circle.json"))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string circle = Encoding.Default.GetString(array);
                return JsonSerializer.Deserialize<List<Circle>>(circle);
            }
        }
        public static List<Circle> XMLDeserializer()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Circle>));
            using (FileStream fs = File.OpenRead("Circle.xml"))
            {
                return xml.Deserialize(fs) as List<Circle>;
                
            }
        }
        public static List<Circle> BinDeserializer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.OpenRead("Circle.bin"))
            {
                return formatter.Deserialize(fs) as List<Circle>;
            }
        }
    }
}
