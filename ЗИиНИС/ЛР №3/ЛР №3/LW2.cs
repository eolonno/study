using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ЛР__3
{
    public static class LW2
    {
        public enum Alphabets
        {
            Latin,
            Cyrillic,
            Binary,
            Base64
        }
        public static double EntropyOfAlphabet(Alphabets Alphabet, float errorProbability = 0)
        {
            string alphabet = "";
            string path = "";
            if (Alphabet == Alphabets.Latin)
            {
                alphabet = "qwertyuiopasdfghjklzxcvbnm";
                path = "latin.txt";
            }
            else if(Alphabet == Alphabets.Cyrillic)
            {
                path = "cyrillic.txt";
                alphabet = "йцукенгшщзхъфывапролджэячсмитьбю";
            }
            else if(Alphabet == Alphabets.Binary)
            {
                path = "binary.bin";
                alphabet = "01";
            }
            else if(Alphabet == Alphabets.Base64)
            {
                path = "base64.txt";
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            }

            Dictionary<char, int> numberOfOccurrences = new Dictionary<char, int>();
            foreach(var ch in alphabet)
                numberOfOccurrences.Add(ch, 0);

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                text = text.ToLower();
                foreach(var ch in text.Select((value, i) => new { i, value }))
                {
                    if (alphabet.Contains(ch.value))
                        numberOfOccurrences[ch.value]++;
                    else if(Alphabet != Alphabets.Base64)
                        text.Remove(ch.i);
                }

                double answer = 0;
                foreach (var ch in alphabet)
                {
                    if (numberOfOccurrences[ch] != 0)
                    {
                        double P = (double)numberOfOccurrences[ch] / (double)text.Length * (1 - errorProbability);
                        answer += P * Math.Log2(P);
                    }
                }

                return -answer;
            }

        }
    }
}
