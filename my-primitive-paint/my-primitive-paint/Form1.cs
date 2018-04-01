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
        public Bitmap bmap;
        public Graphics graphics;
        public mainForm()
        {
            InitializeComponent();
            bmap = new Bitmap(pictrueDrawing.Height, pictrueDrawing.Width);
            graphics = Graphics.FromImage(bmap);
        }

        
        private void drawButton_Click(object sender, EventArgs e)
        {
            
           

            /*Square square = new Square(4, Color.Aqua, new Point(30,30), 100);
            square.Draw(graphics);

            Rectangle rectangle = new Rectangle(1, Color.Beige, new Point(150,150), new Point(150, 50));
            rectangle.Draw(graphics);

            Ellipse ellipse = new Ellipse(2, Color.Aquamarine, new Point(400,400), new Point(600,600));
            ellipse.Draw(graphics);

            Circle circle = new Circle(4, Color.Aqua, new Point(30, 700), 100);
            circle.Draw(graphics);*/
            
            
            Point point1 = new Point(450, 50);
            Point point2 = new Point(370, 150);
            Point point3 = new Point(540, 100);
            Point point4 = new Point(360, 100);
            Point point5 = new Point(530, 150);
           // Point point6 = new Point(500, 30);
            Point[] points =
             {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5
             
             };


            //Polygon polygon = new Polygon(5, Color.BurlyWood, points);
            //polygon.Draw(graphics);
            //  graphics.DrawPolygon(pen, points);
            List<MainFigure> Figures = new List<MainFigure>();
            Figures.Add(new Square(4, Color.Aqua, new Point(30, 30), new Point(130,130)));
            Figures.Add(new Rectangle(3, Color.Black, new Point(150, 30), new Point(250, 90)));
            Figures.Add(new Ellipse(2, Color.Aquamarine, new Point(200, 110), new Point(350, 200)));
            Figures.Add(new Circle(4, Color.Aqua, new Point(30, 200), new Point(130, 130))); 
            Figures.Add(new Polygon(5, Color.Chocolate, points));

            ListOfFigures listOfFigures = new ListOfFigures(Figures);
            listOfFigures.Draw(graphics);

            pictrueDrawing.Image = bmap;

        }

        private MainFigure mainFigure;
        private Fabric maker;

        private bool IsInt(string x1, string y1, string x2, string y2)
        {
            int res = 0;
            if (Int32.TryParse(x1, out res) && Int32.TryParse(y1, out res) && Int32.TryParse(x2, out res) && Int32.TryParse(y2, out res))
            {
                return true;
            }
            return false;
        }

        private void draw_Click(object sender, EventArgs e)
        {

            if (IsInt(tb_x1.Text, tb_y1.Text, tb_x2.Text, tb_y2.Text))
            {
                mainFigure = maker.FactoryMethod(4, Color.Aquamarine,
                                new Point(Convert.ToInt32(tb_x1.Text, 10), Convert.ToInt32(tb_y1.Text)),
                                new Point(Convert.ToInt32(tb_x2.Text, 10), Convert.ToInt32(tb_y2.Text)));
                mainFigure.Draw(graphics);


                pictrueDrawing.Image = bmap;
            } else
            {
                MessageBox.Show("Input correct coordinate", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

            
        }

        private void rb_square_CheckedChanged(object sender, EventArgs e)
        {
            maker = new SquareFabric();
        }

        private void rb_reactangle_CheckedChanged(object sender, EventArgs e)
        {
            maker = new RectangleFabric();
        }

        private void rb_ellipse_CheckedChanged(object sender, EventArgs e)
        {
            maker = new EllipseFabric();
        }

        private void rb_circle_CheckedChanged(object sender, EventArgs e)
        {
            maker = new CircleFabric();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictrueDrawing.Image = bmap;
        }
    }

       
}
