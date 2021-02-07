using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace ЛР__14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circle> cicrles = new List<Circle>();
            cicrles.Add(new Circle(12, "Red"));
            cicrles.Add(new Circle(2, "Purple"));
            cicrles.Add(new Circle(5, "Pink"));
            cicrles.Add(new Circle(33, "Orange"));
            cicrles.Add(new Circle(52, "White"));
            CustomSerializer.XMLSerializer(cicrles);
            CustomSerializer.BinSerializer(cicrles);
            CustomSerializer.JSONSerializer(cicrles);

            //List<Circle> Returned = CustomDeserializer.BinDeserializer();
            //List<Circle> Returned = CustomDeserializer.JSONDeserializer();
            List<Circle> Returned = CustomDeserializer.XMLDeserializer();

            foreach (var circle in Returned)
            {
                Console.WriteLine(circle);
                Console.WriteLine("----------------------");
            }

            // Выборка
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Circle.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            var element = xRoot.SelectSingleNode("Circle[color='Red']");
            if (element != null)
                Console.WriteLine("\n" + element.OuterXml);

            element = xRoot.SelectSingleNode("Circle[size='52']");
            if (element != null)
                Console.WriteLine(element.OuterXml + "\n");

            // Linq to XML
            XDocument xDocument = new XDocument();
            XElement Illustrator = new XElement("program");
            Illustrator.Add(new XAttribute("name", "Illustrator"));
            Illustrator.Add(new XElement("price", "1622 RUB"));
            Illustrator.Add(new XElement("period", "12 months"));

            XElement InCopy = new XElement("program");
            InCopy.Add(new XAttribute("name", "InCopy"));
            InCopy.Add(new XElement("price", "386 RUB"));
            InCopy.Add(new XElement("period", "12 months"));

            XElement Photoshop = new XElement("program");
            Photoshop.Add(new XAttribute("name", "Photoshop"));
            Photoshop.Add(new XElement("price", "800 RUB"));
            Photoshop.Add(new XElement("period", "6 months"));

            XElement Programs = new XElement("Programs");

            Programs.Add(Illustrator);
            Programs.Add(InCopy);
            Programs.Add(Photoshop);

            xDocument.Add(Programs);
            xDocument.Save("AdobePrograms.xml");

            XDocument xDocRoot = XDocument.Load("AdobePrograms.xml");
            var items = from xe in xDocRoot.Element("Programs").Elements("program")
                        where xe.Attribute("name").Value == "InCopy" || xe.Element("period").Value == "6 months"
                        select new AdobeProgram
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value,
                            Period = xe.Element("period").Value
                        };
            foreach(var item in items)
            {
                Console.WriteLine($"Name: {item.Name}\nPrice: {item.Price}\nPeriod: {item.Period}");
                Console.WriteLine("----------------------");
            }
        }
        class AdobeProgram
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Period { get; set; }
        }
    }
}
