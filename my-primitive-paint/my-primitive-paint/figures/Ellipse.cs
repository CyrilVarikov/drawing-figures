using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    public class Ellipse : MainFigure
    {
        private Point topLeft, bottomRight;

        public Ellipse(float fatness, Color color, Point topLeft, Point bottomRight)
        {
            this.color = color;
            this.fatness = fatness;
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(color, fatness);
            graphics.DrawEllipse(pen, topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
        }
    }
}
