using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ЛР__7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] x = new int[3];
                x[3] = 5;
                int zero = 0;
                int res = 5 / zero;
                throw new Exception("Ошибка №1");
                throw new Exception("Ошибка №2");
            }
            catch(Exception ex)
            {
                new ConsoleLogger("ERROR", ex.Message);
                new FileLogger("ERROR", ex.Message);
            }
            finally
            {
                Console.WriteLine("Сработал блок finally");
            }
            Console.WriteLine("Если Вы введете 0, то программа экстренно завершится");
            Debug.Assert(Convert.ToByte(Console.ReadLine()) != 0);
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
            try
            {
                size = Convert.ToInt32(Console.ReadLine());
                if (size < 0)
                    throw (new Exception("Размер не может быть отрицательным!"));
            }
            catch(Exception ex)
            {
                new ConsoleLogger("ERROR", ex.Message);
                new FileLogger("ERROR", ex.Message);
                return;
            }
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
    public interface IControlElement
    {
        void Click();
    }
    public abstract class ControlElement
    {
        public abstract void Click();
        public bool isControlElement = true;
    }

    public class Checkbox : ControlElement, IControlElement
    {
        private int number { get; set; }
        public override void Click()
        {
            number = Convert.ToInt32(Console.ReadLine());
        }
    }

    public class Radiobutton : ControlElement, IControlElement
    {
        private bool isPressed { get; set; } = false;
        public override void Click()
        {
            isPressed = Convert.ToBoolean(Console.ReadLine());
        }
    }

    public class Button : ControlElement, IControlElement
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
    public class UI
    {

        public List<object> Elements = new List<object>();

        public byte menu()
        {
            Console.Write($"1. Вывести список всех кнопок\n" +
                          $"2. Вывести общее количество всех элементов\n" +
                          $"3. Найти общую площадь, всех фигур\n" +
                          $"4. Выход\n" +
                          $"$ ");
            try
            {
                byte choice = Convert.ToByte(Console.ReadLine());
                if (choice > 4 || choice < 1)
                    throw (new Exception("Неверно введенные данные!"));
                else return choice;
            }
            catch(Exception ex)
            {
                new ConsoleLogger("ERROR", ex.Message);
                new FileLogger("ERROR", ex.Message);
                return 0;
            }

        }
        public void Add(Rect Figure, double Size)
        {
            Figure.size = Size;
            Elements.Add(Figure);
        }
        public void Add(Circle Figure, double Size)
        {
            Figure.size = Size;
            Elements.Add(Figure);
        }
        public void Add(Button CE)
        {
            Elements.Add(CE);
        }
        public void Add(Checkbox CE)
        {
            Elements.Add(CE);
        }
        public void Add(Radiobutton CE)
        {
            Elements.Add(CE);
        }
        public object this[int index]
        {
            get
            {
                return Elements[index];
            }
        }
        public void Delete(int index)
        {
            Elements.Remove(index);
        }
        public void Print()
        {
            foreach (object obj in Elements)
                Console.WriteLine(obj);
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
                catch (InvalidCastException ex) 
                {
                    new ConsoleLogger("ERROR", ex.Message);
                    new FileLogger("ERROR", ex.Message);
                    continue; 
                }
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
                catch (InvalidCastException ex) 
                {
                    new ConsoleLogger("INFO", ex.Message);
                    new FileLogger("INFO", ex.Message);
                    continue; 
                }
            }
            return Area;
        }
    }
    class Logger
    {
        protected string Message { get; set; }
    }
    class FileLogger : Logger
    {
        public FileLogger(string type, string msg)
        {
            DateTime now = DateTime.Now;
            Message = now + " " + type + ": " +msg + '\n';
            File.AppendAllText("D:\\Учеба\\ООП\\ЛР №7\\log.txt", Message);
        }
    }
    class ConsoleLogger : Logger
    {
        public ConsoleLogger(string type, string msg)
        {
            Message = DateTime.Now + " " + type + ": " + msg;
            Console.WriteLine(Message);
        }
    }
}
