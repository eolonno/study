using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР__14
{
    interface IControl
    {
        void show();
        void input();
        void resize();
    }
    [Serializable]
    public class Figure : IControl
    {
        public int size { get; set; }
        public string color { get; set; }

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
}
