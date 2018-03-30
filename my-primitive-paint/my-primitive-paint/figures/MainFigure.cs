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
        

        public abstract void Draw(Graphics graphics);
    }
}
