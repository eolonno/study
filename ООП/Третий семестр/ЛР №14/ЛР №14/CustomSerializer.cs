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
    static class CustomSerializer
    {
        private static string subl = "D:\\SOFT\\Sublime Text 3\\sublime_text.exe";
        public static void XMLSerializer(List<Circle> circle)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Circle>));
            using(FileStream fs = new FileStream("Circle.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, circle);
            }
            Process.Start(subl, "Circle.xml");
        }
        public static void BinSerializer(List<Circle> circle)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Circle.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, circle);
            }
            Process.Start(subl, "Circle.bin");
        }
        public static void JSONSerializer(List<Circle> circle)
        {
            using (FileStream fs = new FileStream("Circle.json", FileMode.OpenOrCreate))
            {
                var json = Encoding.Default.GetBytes(JsonSerializer.Serialize(circle));
                fs.Write(json, 0, json.Length);
            }
            Process.Start(subl, "Circle.json");
        }
    }
}
