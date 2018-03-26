using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    public abstract class MainFigure 
    {
        public int x, y;
        public int width, height;
        public Point[] points;
        public MainFigure(int x1, int y1, int width, int height) // elipse and rectrangle
        {
            this.x = x1;
            this.y = y1;
            this.width = width;
            this.height = height;
        }

        public MainFigure(int x, int y, int width) //circle and square
        {
            this.x = x;
            this.y = y;
            this.width = width;
        }

        public MainFigure(Point[] points) //polygon
        {
            this.points = points;
        }

        public abstract void Draw(Graphics graphics);
    }
}
