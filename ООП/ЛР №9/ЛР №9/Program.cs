using System;

namespace ЛР__9
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] Users = new User[3];
            Users[0] = new User();
            Users[1] = new User();
            Users[2] = new User();
            Users[0].Move += (user, bias) => Console.WriteLine($"Пользователь {user} сдвинул объект на {bias} метров.");
            Users[0].Squeeze += (user, factor) => Console.WriteLine($"Пользователь {user} сжал объект. Коэффициент сжатия: {factor}.");

            Users[1].Move += (user, bias) => Console.WriteLine($"Пользователь {user} сдвинул объект на {bias} метров.");

            Random rnd = new Random();

            foreach(User u in Users)
            {
                u.move(u, rnd.NextDouble());
                u.squeeze(u, rnd.NextDouble());
            }
            Console.WriteLine("---------------------------------");

            // Обработка строки

            string String = "Hello  World!";
            StringProcessing str = new StringProcessing();
            Func<string, string> StringProcessingDelegate = str => str.ToLower();
            String = StringProcessingDelegate(String);
            Console.WriteLine(String);
            StringProcessingDelegate += str => str.ToUpper();
            String = StringProcessingDelegate(String);
            Console.WriteLine(String);
            StringProcessingDelegate += str.RemovePunctuationMarks;
            String = StringProcessingDelegate(String);
            Console.WriteLine(String);
            StringProcessingDelegate += str.Trim;
            String = StringProcessingDelegate(String);
            Console.WriteLine(String);
            Func<string, char, string> StringProcessingWithoutParameters = (str, ch) => str += ch;
            String = StringProcessingWithoutParameters(String, 'w');
            Console.WriteLine(String);


        }
        class User
        {
            public delegate void Operation(User user, double param);
            public event Operation Move;
            public event Operation Squeeze;
            
            public string str { get; set; }

            public void move(User user, double bias)
            {
                if (Move == null)
                    Console.WriteLine("Вызвано событие Move");
                else
                    Move(user, bias);
            }
            public void squeeze(User user, double factor)
            {
                if (Squeeze == null)
                    Console.WriteLine("Вызвано событие Squeeze");
                else
                    Squeeze(user, factor);
            }
        }

        class StringProcessing
        {
            public string RemovePunctuationMarks(string str)
            {
                string PunctuatinMarks = ",.;:-!";
                for (int i = 0; i < str.Length; i++)
                {
                    foreach (char PunctuationMark in PunctuatinMarks)
                        if (str[i] == PunctuationMark)
                            str = str.Remove(i, 1);
                }
                return str;
            }
            public string Trim(string str)
            {
                for (int i = 0; i < str.Length; i++)
                    if (str[i] == ' ' && str[i + 1] == ' ')
                        str = str.Remove(i + 1, 1);
                return str;
            }
        }
    }
}
