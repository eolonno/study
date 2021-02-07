using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator.Sin(textBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calculator.SecondDegree(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculator.Cos(textBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculator.Tan(textBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calculator.Ctg(textBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Calculator.ThirdDegree(textBox1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Calculator.Clear(textBox1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Calculator.SomeDegree(textBox1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Calculator.MemoryPlus(textBox1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Calculator.MemoryMinus(textBox1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Calculator.MemoryRead(textBox1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Calculator.MemoryClear(textBox1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Calculator.MemorySave(textBox1);
        }
    }
}
