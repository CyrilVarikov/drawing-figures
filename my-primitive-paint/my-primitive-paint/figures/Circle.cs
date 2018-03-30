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
        private Point topLeft;
        private int radius;
        public Circle(float fatness, Color color, Point topLeft, Point bottomRight)
        {
            this.color = color;
            this.fatness = fatness;
            this.topLeft = topLeft;
            this.radius = bottomRight.X - topLeft.X;
        }
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(color, fatness);
            graphics.DrawEllipse(pen, topLeft.X, topLeft.Y, radius, radius);
        }
    }
}
