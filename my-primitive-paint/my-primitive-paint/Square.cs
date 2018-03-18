using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    public class Square : MainFigure 
    {
        private float width;
        public Square(float width, int x1, int y1, int x2, int y2) : base (x1, y1, x2, y2)
        {
            this.width = width;
        }
        public void Draw(Graphics graphics, Pen pen) 
        {
            pen = new Pen(Color.Green, width);
            graphics.DrawRectangle(pen, x1, y1, x2, y2);
        }


    }
}
