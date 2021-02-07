using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing.Drawing2D;

namespace lab3_kgig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       //-------------------------------------------------------
        }

        private double f1(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return Math.Sin(x) / x;
        }

        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list = new PointPairList();

            double xmin = -3*Math.PI;
            double xmax = 3*Math.PI;

            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += Math.PI/36 )
            {
                // добавим в список точку
                list.Add(x, f1(x));
            }

            // Создадим кривую с названием "Sin(x/x)", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("Sin(x/x)", list, Color.Blue, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        private double f2(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return Math.Pow(x, 3);
        }

        private void DrawGraph1()
        {
            GraphPane pane = zedGraph1.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            double xmin = -5;
            double xmax = 5;

            for (double x = xmin; x <= xmax; x += 0.25)
            {
                
                list.Add(x, f2(x));
            }

            LineItem myCurve = pane.AddCurve("X^3)", list, Color.Green, SymbolType.None);

            zedGraph1.AxisChange();

            zedGraph1.Invalidate();
        }

        private double f3(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return Math.Sqrt(x)*Math.Sin(x);
        }

        private void DrawGraph2()
        {
            GraphPane pane = zedGraph2.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            double xmin = 0;
            double xmax = 6*Math.PI;

            for (double x = xmin; x <= xmax; x += Math.PI/36)
            {

                list.Add(x, f2(x));
            }

            LineItem myCurve = pane.AddCurve("Sqrt(x)*Sin(x)", list, Color.Red, SymbolType.None);
            myCurve.Line.Style = DashStyle.Dot;

            zedGraph2.AxisChange();

            zedGraph2.Invalidate();
        }

        private double f4(double x)
        {
            //if (x == 0)
            //{
            //    return 1;
            //}

            return Math.Pow(x,2);
        }

        private void DrawGraph3()
        {
            GraphPane pane = zedGraph3.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            double xmin = -10;
            double xmax = 10;

            for (double x = xmin; x <= xmax; x += 0.25)
            {

                list.Add(x, f4(x));
            }

            LineItem myCurve = pane.AddCurve("x^2", list, Color.Black, SymbolType.None);
          
            zedGraph3.AxisChange();

            zedGraph3.Invalidate();
        }

        private void F_1_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void F_2_Click(object sender, EventArgs e)
        {
            DrawGraph1();
        }

        private void F_3_Click(object sender, EventArgs e)
        {
            DrawGraph2();
        }

        private void F_4_Click(object sender, EventArgs e)
        {
            DrawGraph3();
        }

        private void F_ALL_Click(object sender, EventArgs e)
        {
            DrawGraph();
            DrawGraph1();
            DrawGraph2();
            DrawGraph3();
        }

      
    }
}
