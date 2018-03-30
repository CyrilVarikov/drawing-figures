using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    public class Polygon : MainFigure
    {
        private Point[] points;
        public Polygon(float fatness, Color color, Point[] points) 
        {
            this.fatness = fatness;
            this.color = color;
            this.points = points;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(color, fatness);
            graphics.DrawPolygon(pen, points);
        }
    }
}
