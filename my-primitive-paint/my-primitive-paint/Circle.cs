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
        private float fatness;
        public Circle(float fatness, int x, int y, int width) : base(x, y, width)
        {
            this.fatness = fatness;
        }
        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Red, fatness);
            graphics.DrawEllipse(pen, x, y, width, width);
        }
    }
}
