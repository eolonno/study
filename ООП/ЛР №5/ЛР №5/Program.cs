using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Xml.Serialization;

namespace ЛР__5
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle Circle1 = new Circle();
            Circle1.printSize(5);
            Circle1.printSize();
            Console.WriteLine(Circle1.ToString());
            List<ControlElement> CE = new List<ControlElement>();
            CE.Add(new Checkbox());
            CE.Add(new Radiobutton());
            CE.Add(new Button());
            Printer printer = new Printer();
            foreach(ControlElement E in CE)
            {
                printer.IAmPrinting(E);
                if (E is Radiobutton)
                    Console.WriteLine(" - RadioButton");
                else if (E is Button)
                    Console.WriteLine(" - Button");
                else if (E is Checkbox)
                    Console.WriteLine(" - Checkbox");
            }
        }
    }

    interface IControl
    {
        void show();
        void input();
        void resize();
    }

    class Figure : IControl
    {
        protected int size { get; set; }
        private string color { get; set; }

        public virtual void show()
        {
            Console.Write("Фигура: ");
        }
        public void resize()
        {
            Console.Write("Введите размер: ");
            size = Convert.ToInt32(Console.ReadLine());
        }
        public void input()
        {
            color = Console.ReadLine();
        }
        public void printSize()
        {
            Console.WriteLine($"Размер: {size}");
        }

        public override string ToString()
        {
            return "Использован метод ToString()";
        }
    }

    sealed class Circle : Figure
    {
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
            return "Использован метод ToString()";
        }
    }

    sealed class Rect : Figure
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("прямоугольник");
        }
    }
    interface IControleElement
    {
        void Click();
    }
    abstract class ControlElement
    {
        public abstract void Click();     
    }

    class Checkbox : ControlElement, IControleElement
    {
        private int number { get; set; }
        public override void Click()
        {
            number = Convert.ToInt32(Console.ReadLine());
        }
    }

    class Radiobutton : ControlElement, IControleElement
    {
        private bool isPressed { get; set; } = false;
        public override void Click()
        {
            isPressed = Convert.ToBoolean(Console.ReadLine());
        }
    }

    class Button : ControlElement, IControleElement
    {
        private int count { get; set; } = 0;
        public override void Click()
        {
            Console.WriteLine("Кликните на кнопку");
            Console.ReadKey();
            count++;
        }
    }
    class Printer
    {
        public virtual void IAmPrinting(object someObj)
        {
            Console.Write(someObj.GetType());
        }
    }
}
