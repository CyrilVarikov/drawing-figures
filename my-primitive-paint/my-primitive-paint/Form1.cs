using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_primitive_paint
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            Point[] points = { new Point(10, 10), new Point(100, 10), new Point(100, 100) };
            Bitmap bmap = new Bitmap(pictrueDrawing.Height, pictrueDrawing.Width);
            Graphics graphics = Graphics.FromImage(bmap);
            Pen pen = new Pen(Color.Blue);
            pen.Width = 2F;
            Square square = new Square(4, 10, 10, 100, 100);
            square.Draw(graphics, pen);
            pictrueDrawing.Image = bmap;

            //  graphics.DrawPolygon(pen, points);

        }
    }
}
