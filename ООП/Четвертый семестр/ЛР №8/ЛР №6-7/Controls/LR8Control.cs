using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace ЛР__6_7.Controls
{
    class LR8Control : Control
    {
        private Ellipse ellipse = new Ellipse();
        public LR8Control(double width = 50, double height = 50)
        {
            Width = width;
            Height = height;

            ellipse.Width = Width;
            ellipse.Height = Height;
            ellipse.Fill = Brushes.LightPink;
            ellipse.StrokeThickness = ellipse.Width <= ellipse.Height ? ellipse.Width / 15 : ellipse.Height / 15;
            DoubleCollection dc = new DoubleCollection(2);
            dc.Add(4);
            dc.Add(2);
            ellipse.StrokeDashArray = dc;
            ellipse.Stroke = Brushes.Gray;
            ellipse.StrokeDashCap = PenLineCap.Round;

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 360;
            animation.Duration = TimeSpan.FromSeconds(5);
            //нужно придумать анимацию поворота
            animation.BeginAnimation(ellipse.RenderTransform = )


        }


    }
}
