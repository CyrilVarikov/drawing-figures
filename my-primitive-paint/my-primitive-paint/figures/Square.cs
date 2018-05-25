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
            /*if(finish.X < topLeft.X || finish.Y < topLeft.Y)
            {
                g.DrawRectangle(pen, finish.X, finish.Y, topLeft.Y - finish.Y, topLeft.Y - finish.Y);
                width = topLeft.Y - finish.Y;
                bottomRight = new Point(topLeft.X + width, topLeft.Y);
            }
            else
            {*/
            width = finish.Y - topLeft.Y;
            g.DrawRectangle(pen, topLeft.X, topLeft.Y, finish.Y - topLeft.Y, finish.Y - topLeft.Y);
            bottomRight = new Point(topLeft.X + width, finish.Y);
            
            
            g.Dispose();
        }

    }
}
