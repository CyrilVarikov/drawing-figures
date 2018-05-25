using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_primitive_paint
{
    public class Editing
    {

        private MainFigure croch = null;
        public MainFigure PickFigure(List<MainFigure> figures, Point location)
        {
            foreach(var figure in figures)
            {
                if((figure.topLeft.X <= location.X && figure.bottomRight.X >= location.X) && 
                    (figure.topLeft.Y <= location.Y && figure.bottomRight.Y >= location.Y)) 
                {
                    if (croch != null && (croch.topLeft.X < figure.topLeft.X))
                    {
                        croch = (MainFigure)Activator.CreateInstance(figure.GetType(), 4, Color.CornflowerBlue, new Point(figure.topLeft.X - 4, figure.topLeft.Y - 4), new Point(figure.bottomRight.X + 4, figure.bottomRight.Y + 4));

                    }
                } 
            }
            return null;
        }

        public void Crochet (MainFigure figure, Graphics g)
        {
            figure.Draw(g);
        }

        public void ClearEdit(List<MainFigure> figures, Graphics g)
        {
            g.Clear(Color.White);
            foreach (var figure in figures)
            {
                figure.Draw(g);
            }
        }
    }
}
