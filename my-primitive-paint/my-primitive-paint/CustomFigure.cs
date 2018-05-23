using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_primitive_paint
{
    public class CustomFigure
    {
        static List<List<MainFigure>> savedFigures = new List<List<MainFigure>>();
        

        public static void AddCustomFigure(List<MainFigure> figures, ComboBox combobox)
        {
            combobox.Items.Add("CustomFigures" + savedFigures.Count.ToString());
            savedFigures.Add(figures);
        }

        public static void DrawCustomFigure(int index, Graphics g)
        {
            foreach(var figure in savedFigures[index])
            {
                figure.Draw(g);
            }
        }
    }
}
