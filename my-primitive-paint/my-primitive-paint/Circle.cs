using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    public class Circle : MainFigure
    {
        private Point point;
        private int radius;
        public Circle(float fatness, Color color, Point point, int radius)
        {
            this.color = color;
            this.fatness = fatness;
            this.point = point;
            this.radius = radius;
        }
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(color, fatness);
            graphics.DrawEllipse(pen, point.X, point.Y, radius, radius);
        }
    }
}
