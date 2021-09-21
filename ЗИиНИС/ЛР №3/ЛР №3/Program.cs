using System;
using System.Text;

namespace ЛР__3
{
    class Program
    {
        static void Main(string[] args)
        {
            //LW3.createBase64Doc();

            Console.WriteLine(LW3.createReport());

            Console.Write("ASCII XOR: ");
            string surname = "Anikeyenka",
                   name =    "Yegor",
                   surnameASCII = "",
                   nameASCII = "";
           
            foreach (var ch in surname)
                surnameASCII += Convert.ToInt32(ch);
            foreach (var ch in name)
                nameASCII += Convert.ToInt32(ch);
            while (surnameASCII.Length != nameASCII.Length)
                nameASCII += '0';
            foreach (var ch in LW3.XOR(Encoding.Unicode.GetBytes(surnameASCII), Encoding.Unicode.GetBytes(nameASCII)))
                Console.Write(ch);
            Console.WriteLine();

            Console.Write("Base64 XOR: ");
            string name64 = Convert.ToBase64String(Encoding.Unicode.GetBytes(name)),
                   surname64 = Convert.ToBase64String(Encoding.Unicode.GetBytes(surname));

            while (surname64.Length != name64.Length)
                name64 += '0';
            foreach (var ch in LW3.XOR(Encoding.Unicode.GetBytes(surname64), Encoding.Unicode.GetBytes(name64)))
                Console.Write(ch);

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("aXORbXORb: \t");
            byte[] aXORbXORb = LW3.XOR(Encoding.Unicode.GetBytes(surname64), LW3.XOR(Encoding.Unicode.GetBytes(name64), Encoding.Unicode.GetBytes(surname64)));
            foreach (var ch in aXORbXORb)
                Console.Write(ch);
            Console.WriteLine();
            Console.Write("a: \t\t");
            foreach (var ch in Encoding.Unicode.GetBytes(name64))
                Console.Write(ch);
        }
    }
}
