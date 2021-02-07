using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ЛР__14
{
    [Serializable]
    public class Circle : Figure
    {
        [NonSerialized]
        [XmlIgnore]
        public int NonSerializedInt = 5;
        public Circle(int Size, string Color)
        {
            size = Size;
            color = Color;

        }
        public Circle()
        {

        }
        public override void show()
        {
            base.show();
            Console.WriteLine("круг");
        }
        public void printSize(int Size)
        {
            Console.WriteLine($"Радиус круга: {Size}");
            size = Size;
        }
        public override string ToString()
        {
            return "Color: " + color + "\nSize: " + size;
        }
    }
}
