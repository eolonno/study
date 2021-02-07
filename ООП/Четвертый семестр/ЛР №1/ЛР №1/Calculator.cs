using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР__1
{
    public static class Calculator
    {
        private static double MemValue = 0;
        public static void MemorySave(TextBox textBox)
        {
            if (!ErrorsCheck(textBox.Text))
                return;
            MemValue = Convert.ToDouble(textBox.Text);
        }
        public static void MemoryPlus(TextBox textBox)
        {
            if (!ErrorsCheck(textBox.Text))
                return;

            textBox.Text = (MemValue + Convert.ToDouble(textBox.Text)).ToString();
        }
        public static void MemoryMinus(TextBox textBox)
        {
            if (!ErrorsCheck(textBox.Text))
                return;

            textBox.Text = (Convert.ToDouble(textBox.Text) - MemValue).ToString();
        }
        public static void MemoryRead(TextBox textBox)
        {
            textBox.Text = MemValue.ToString();
        }
        public static void MemoryClear(TextBox textBox)
        {
            MemValue = 0;
        }
        static public void Sin(TextBox textBox1)
        {
            if (!ErrorsCheck(textBox1.Text))
                return;

            textBox1.Text = Math.Sin(Convert.ToDouble(textBox1.Text)).ToString();
        }

        static public void SecondDegree(TextBox textBox1)
        {
            if (!ErrorsCheck(textBox1.Text))
                return;

            textBox1.Text = Math.Pow(Convert.ToDouble(textBox1.Text), 2).ToString();
        }
        static private bool ErrorsCheck(string Number)
        {
            try
            {
                Convert.ToDouble(Number);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
                return false;
            }
        }

        static public void Cos(TextBox textBox1)
        {
            if (!ErrorsCheck(textBox1.Text))
                return;

            textBox1.Text = Math.Cos(Convert.ToDouble(textBox1.Text)).ToString();
        }

        static public void Tan(TextBox textBox1)
        {
            if (!ErrorsCheck(textBox1.Text))
                return;

            textBox1.Text = Math.Tan(Convert.ToDouble(textBox1.Text)).ToString();
        }

        static public void Ctg(TextBox textBox1)
        {
            if (!ErrorsCheck(textBox1.Text))
                return;

            textBox1.Text = (Math.Cos(Convert.ToDouble(textBox1.Text)) / Math.Sin(Convert.ToDouble(textBox1.Text))).ToString();
        }

        static public void ThirdDegree(TextBox textBox1)
        {
            if (!ErrorsCheck(textBox1.Text))
                return;

            textBox1.Text = Math.Pow(Convert.ToDouble(textBox1.Text), 3).ToString();
        }

        static public void Clear(TextBox textBox1)
        {
            textBox1.Text = "0";
        }

        static public void SomeDegree(TextBox textBox1)
        {
            try
            {
                if (textBox1.Text.Where(x => x.Equals('^')).Count() > 1)
                    throw new Exception("Много степенных знаков!");
                else if(textBox1.Text.Where(x => x.Equals('^')).Count() == 0)
                    throw new Exception("Не хватает степенного знака!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
                return;
            }

            string Number = "", Stage = "";
            bool WasSign = false;
            foreach (var num in textBox1.Text)
            {
                if (num == '^')
                {
                    WasSign = true;
                    continue;
                }
                if (!WasSign)
                    Number += num;
                else Stage += num;
            }
            textBox1.Text = Math.Pow(Convert.ToDouble(Number), Convert.ToDouble(Stage)).ToString();
        }
    }
}
