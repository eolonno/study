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
    public partial class Form2 : Form
    {
        private double plankaresource = 5000000;
        private double gama = 1.02;
        private int year = 1;
        public Form2()
        {
            InitializeComponent();
            fillTable();
        }
        public void fillTable()
        {
            double value = 10000;          
            dataGridView1.Rows.Add
                (
                    year,
                    10000
                );
            for (int i = 2; i < 51; i++)
            {
                value = value + gama * (1 - (value / plankaresource)) * value;
                dataGridView1.Rows.Add
                (
                    i,
                   value.ToString("F0")
                );               
                chart1.Series[0].Points.AddXY(i,value);                
            }
        }           
    }                            
}