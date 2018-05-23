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
        private int width;
        public Square(float fatness, Color color, Point topLeft, Point bottomRight) : base(fatness, color, topLeft, bottomRight)
        {
            width = bottomRight.X - topLeft.X;
        }
        public override void Draw(Graphics graphics) 
        {
            graphics.DrawRectangle(pen, topLeft.X, topLeft.Y, width, width);
        }

        public override void MouseDraw(Graphics g, Point finish)
        {
            if(finish.X < topLeft.X || finish.Y < topLeft.Y)
            {
                g.DrawRectangle(pen, finish.X, finish.Y, topLeft.X - finish.X, topLeft.X - finish.X);
                width = topLeft.X - finish.X;
            }
            else
            {
                width = finish.X - topLeft.X;
                g.DrawRectangle(pen, topLeft.X, topLeft.Y, finish.X - topLeft.X, finish.X - topLeft.X);
            }
            
            g.Dispose();
        }

    }
}
