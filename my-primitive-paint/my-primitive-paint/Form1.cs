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
            Bitmap bmap = new Bitmap(pictrueDrawing.Height, pictrueDrawing.Width);
            Graphics graphics = Graphics.FromImage(bmap);
          
            //Square square = new Square(4, 30, 30, 100);
           // square.Draw(graphics);
            
            //Rectangle rectangle = new Rectangle(4, 150, 150, 100, 50);
            //rectangle.Draw(graphics);

            //Ellipse ellipse = new Ellipse(2, 180, 180, 50, 100);
            //ellipse.Draw(graphics);

            //Circle circle = new Circle(3, 250, 250, 120);
            //circle.Draw(graphics);

            Point point;
            int k = 5;
            
            Point point1 = new Point(450, 30);
            Point point2 = new Point(400, 130);
            Point point3 = new Point(520, 90);
            Point point4 = new Point(380, 90);
            Point point5 = new Point(500, 130);
           // Point point6 = new Point(500, 30);
            Point[] points =
             {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5
             
             };

           // for (int i = 0; i < 5; i++)
           // {
           //     point = new Point((i + 5) * 10, (i + 5 + 10) * 10);
            //    points[i] = point;
            //}

            Polygon polygon = new Polygon(5, points);
            polygon.Draw(graphics);
            //  graphics.DrawPolygon(pen, points);
            List<MainFigure> Figures = new List<MainFigure>();
            Figures.Add(new Square(4, 30, 30, 100));
            Figures.Add(new Rectangle(4, 150, 30, 100, 50));
            Figures.Add(new Ellipse(2, 180, 180, 50, 100));
            Figures.Add(new Circle(3, 250, 250, 120)); 
            Figures.Add(new Polygon(5, points));

            ListOfFigures listOfFigures = new ListOfFigures(Figures);
            listOfFigures.Draw(graphics);

            pictrueDrawing.Image = bmap;

        }
    }
}
