using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace ЛР__6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Circle Circle1 = new Circle();
            //Circle1.printSize(5);
            //Circle1.printSize();
            //Console.WriteLine(Circle1.ToString());

            //List<UI> Figures = new List<UI>();
            //Figures.Add(Circle1);
            //Figures.Add(new Circle() { size = 55.54 });
            //Figures.Add(new Rect() { size = 23.2 });

            //List<ControlElement> CE = new List<ControlElement>();
            //CE.Add(new Checkbox());
            //CE.Add(new Radiobutton());
            //CE.Add(new Button());
            //Printer printer = new Printer();
            //foreach (ControlElement E in CE)
            //{
            //    printer.IAmPrinting(E);
            //    if (E is Radiobutton)
            //        Console.WriteLine($" - {EControlElements.RadioButton}");
            //    else if (E is Button)
            //        Console.WriteLine($" - {EControlElements.Button}");
            //    else if (E is Checkbox)
            //        Console.WriteLine($" - {EControlElements.Checkbox}");
            //}

            UI UserIntarface = new UI();
            UIController uiController = new UIController();
            bool isWork = true;
            UserIntarface.Add(new Checkbox());
            UserIntarface.Add(new Radiobutton());
            UserIntarface.Add(new Button());
            UserIntarface.Add(new Circle(), 23.2);
            UserIntarface.Add(new Circle(), 55.54);
            UserIntarface.Add(new Rect(), 23.2);
            do
            {
                switch (UserIntarface.menu())
                {
                    case 1: uiController.PrintList(UserIntarface); break;
                    case 2: Console.WriteLine("Количество всех созданных элементов: " + uiController.ElementCounter(UserIntarface)); break;
                    case 3: Console.WriteLine("Общая площадь всех фигур: " + uiController.TotalArea(UserIntarface)); break;
                    case 4: isWork = false; break;
                    default: Console.WriteLine("Некорректно введенные данные!"); break;
                }
            } while (isWork);
        }
    }
    enum EControlElements { RadioButton, Button, Checkbox };
    struct Types
    {
        private string str;
        private int integer;
    }
    public interface IControl
    {
        void show();
        void input();
        void resize();
    }

    public partial class Figure : IControl
    {
        public double size { get; set; }
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
            Console.WriteLine($"Площадь: {size}");
        }
    }

    public sealed class Circle : Figure
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("круг");
        }
        public void printSize(int Size)
        {
            Console.WriteLine($"Площадь круга: {Size}");
            size = Size;
        }
    }

    public sealed class Rect : Figure
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("прямоугольник");
        }
    }
    public interface IControleElement
    {
        void Click();
    }
    public abstract class ControlElement
    {
        public abstract void Click();
        public bool isControlElement = true;
    }

    public class Checkbox : ControlElement, IControleElement
    {
        private int number { get; set; }
        public override void Click()
        {
            number = Convert.ToInt32(Console.ReadLine());
        }
    }

    public class Radiobutton : ControlElement, IControleElement
    {
        private bool isPressed { get; set; } = false;
        public override void Click()
        {
            isPressed = Convert.ToBoolean(Console.ReadLine());
        }
    }

    public class Button : ControlElement, IControleElement
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
    public partial class UI
    {
        
        public List<object> Elements = new List<object>();
        
        public byte menu()
        {
            Console.Write($"1. Вывести список всех кнопок\n" +
                          $"2. Вывести общее количество всех элементов\n" +
                          $"3. Найти общую площадь, всех фигур\n" +
                          $"4. Выход\n" +
                          $"$ ");
            return Convert.ToByte(Console.ReadLine());

        }
    }
    public class UIController
    {
        public void PrintList(UI UI)
        {
            foreach (object obj in UI.Elements)
                try
                {
                    if (((ControlElement)obj).isControlElement)
                        Console.WriteLine(obj);
                }
                catch (System.InvalidCastException) { continue; }
        }
        public int ElementCounter(UI UI)
        {
            return UI.Elements.Count;
        }
        public double TotalArea(UI UI)
        {
            double Area = 0;
            foreach (object obj in UI.Elements)
            {
                try
                {
                    Area += ((Figure)obj).size;
                }
                catch (System.InvalidCastException) { continue; }
            }
            return Area;
        }
    }
}
