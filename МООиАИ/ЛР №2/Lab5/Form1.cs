using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private double alfa = 0.06;
        private double beta = 0.04;
        private double population = 10000;
        private double gama = 1.02;
        private double year = 1;

        public Form1()
        {
            InitializeComponent();
            fillTable();
        }

        public void fillTable()
        {
            string k = (population * Math.Pow(1 + alfa - beta, 10 - 1) * 0.8).ToString("F0");
            int d = 0;
            for (int i = 0; i < 50; i++)
            {
                dataGridView1.Rows.Add
                (
                    year,
                    (population * Math.Pow(1 + alfa - beta, year - 1)).ToString("F0")
                );
                
                chart1.Series[0].Points.AddXY(year, population * Math.Pow(1 + alfa - beta, year - 1));
                if (i > 9 && i < 21)
                {
                    chart2.Series[0].Points.AddXY(year, (population * Math.Pow(1 + alfa - beta, year - 1)).ToString("F0"));
                    chart2.Series[1].Points.AddXY(year, (int.Parse(k) * Math.Pow(1 + alfa - beta, year - 1) * 0.8 * (Math.Pow(1+alfa-beta, d+1))).ToString("F0"));
                }
                year++;
            }

            listBox1.Items.Add("A) Удвоение населения через: " + Math.Ceiling(Math.Log(2,gama)) + " лет. ");
        
            listBox1.Items.Add("\n");
            listBox1.Items.Add("\n");
            listBox1.Items.Add("Б) До падения на 20% на 10ый год, численность населения составляла: " + (population*Math.Pow(1+alfa-beta,10-1)).ToString("F0"));
            listBox1.Items.Add("После падения численности населения на 20%, численность населения составила: " + (population*Math.Pow(1+alfa-beta,10-1)*0.8).ToString("F0"));    
            listBox1.Items.Add("Восстановится население до численности: " + (population*Math.Pow(1+alfa-beta,10-1)*0.8*Math.Pow(1+alfa-beta,12)).ToString("F0") + " через 12 лет. ") ;  
        }

        private void логарифмическаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
