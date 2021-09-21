using System;

namespace ЛР__2
{
    class Program
    {
        static void Main(string[] args)
        {
            //First task
            Console.WriteLine("Entropy of alphabets");
            Console.WriteLine("Cyrillic: " + Task.EntropyOfAlphabet(Task.Alphabets.Cyrillic));
            Console.WriteLine("Latin: " + Task.EntropyOfAlphabet(Task.Alphabets.Latin));

            //Second task
            Console.WriteLine("Binary: " + Task.EntropyOfAlphabet(Task.Alphabets.Binary));
            Console.WriteLine();

            //Third task
            Console.WriteLine("The amount of information in my full name (Latin): " + (Task.EntropyOfAlphabet(Task.Alphabets.Latin) * "Anikeyenka Yegor Vyacheslavovich".Length));
            Console.WriteLine("The amount of information in my full name (ASCII): " + 
                (Task.EntropyOfAlphabet(Task.Alphabets.Binary) *
                 System.Text.Encoding.Unicode.GetBytes("Anikeyenka Yegor Vyacheslavovich").Length));

            //Fourth task
            Console.WriteLine("The amount of information in my full name (ASCII, error probability 0.1): " +
                (Task.EntropyOfAlphabet(Task.Alphabets.Binary, 0.1f) *
                 System.Text.Encoding.Unicode.GetBytes("Anikeyenka Yegor Vyacheslavovich").Length));
            Console.WriteLine("The amount of information in my full name (ASCII, error probability 0.5): " +
                (Task.EntropyOfAlphabet(Task.Alphabets.Binary, 0.5f) *
                 System.Text.Encoding.Unicode.GetBytes("Anikeyenka Yegor Vyacheslavovich").Length));
            Console.WriteLine("The amount of information in my full name (ASCII, error probability 1): " +
                (Double.IsNaN(Task.EntropyOfAlphabet(Task.Alphabets.Binary, 1f)) ? 0 : Task.EntropyOfAlphabet(Task.Alphabets.Binary, 1f) *
                 System.Text.Encoding.Unicode.GetBytes("Anikeyenka Yegor Vyacheslavovich").Length));



        }
    }
}
