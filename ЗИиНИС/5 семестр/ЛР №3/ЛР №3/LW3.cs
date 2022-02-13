using System;
using System.IO;

namespace ЛР__3
{
    public static class LW3
    {
        public static string toBase64(string path)
        {
            string text;
            using(StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(text));
        }
        public static void createBase64Doc()
        {
            using (FileStream fs = new FileStream("base64.txt", FileMode.OpenOrCreate))
            {
                fs.Write(System.Text.Encoding.Unicode.GetBytes(toBase64("latin.txt")));
            }
        }
        public static string createReport()
        {
            double base64ES = LW2.EntropyOfAlphabet(LW2.Alphabets.Base64),
                   latinES = LW2.EntropyOfAlphabet(LW2.Alphabets.Latin),
                   base64EC = Math.Log2("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".Length),
                   latinEC = Math.Log2("qwertyuiopasdfghjklzxcvbnm".Length);
            string report = "";
            report += "Base64 entropy (Shennon): " + base64ES + "\n";
            report += "Latin entropy (Shennon): " + latinES + "\n";
            report += "Base64 entropy (Chartly): " + base64EC + "\n";
            report += "Latin entropy (Chartly): " + latinEC + "\n";
            report += "Redundancy of base64: " + (base64EC - base64ES) / base64EC * 100 + "%\n";
            report += "Redundancy of latin: " + (latinEC - latinES) / latinEC * 100 + "%\n";
            return report;
        }
        public static byte[] XOR(byte[] buf1, byte[] buf2)
        {
            byte[] ans = new byte[buf1.Length];
            if (buf1.Length == buf2.Length)
            {
                for (int i = 0; i < buf1.Length; i++)
                {
                    ans[i] = (byte)(buf1[i] ^ buf2[i]);
                }
            }
            return ans;
        }
        public static byte[] myXOR(byte[] buf1, byte[] buf2)
        {
            byte[] ans = new byte[buf1.Length];
            if(buf1.Length == buf2.Length)
            {
                for(int i = 0; i < buf1.Length; i++)
                {
                    string buf1In2 = Convert.ToString(buf1[i], 2);
                    string buf2In2 = Convert.ToString(buf2[i], 2);
                    string bitAns = "";
                    for(int j = 0; j < buf2In2.Length; j++)
                    {
                        if (buf1In2[j] == '0' && buf2In2[j] == '0'
                           || buf1In2[j] == '1' && buf2In2[j] == '1')
                            bitAns += '0';
                        else
                            bitAns += '1';
                    }
                    ans[i] = (byte)Convert.ToInt32(bitAns, 2);
                }
            }
            return ans;
        }
    }
}
