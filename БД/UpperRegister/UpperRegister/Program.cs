using System;
using System.IO;

namespace UpperRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                using(StreamWriter fs = new StreamWriter("output.txt"))
                {
                    fs.Write(sr.ReadToEnd().ToUpper());
                }
            }
        }
    }
}
