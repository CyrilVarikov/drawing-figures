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
        public Color color;
        public float fatness;
        protected Pen pen;

        public MainFigure(float fatness, Color color)
        {
            this.fatness = fatness;
            this.color = color;
            pen = new Pen(color, fatness);
        }


        public virtual void Draw(Graphics graphics) { }
    }
}
