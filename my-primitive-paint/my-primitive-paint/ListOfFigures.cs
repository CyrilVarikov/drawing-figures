using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    public class ListOfFigures
    {
        private List<MainFigure> figures;

        public ListOfFigures(List<MainFigure> figures)
        {
            this.figures = figures;
        }

        public void Draw(Graphics graphics)
        {
            foreach( MainFigure figure in figures)
            {
                figure.Draw(graphics);
            }
        }
    }
}
