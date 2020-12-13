using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ЛР__6
{
    partial class UI
    {
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
}
