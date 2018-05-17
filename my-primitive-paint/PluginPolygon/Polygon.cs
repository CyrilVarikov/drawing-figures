using my_primitive_paint;
using PluginInterfase;
using System.Drawing;

namespace PluginPolygon
{
    public class Polygon : MainFigure, IFigure
    {
        private Point[] pointsT;
        public Polygon(float fatness, Color color, Point topLeft, Point bottomRight) : base(fatness, color, topLeft, bottomRight)
        {
            Point[] points =
            {
                new Point (topLeft.X + ((bottomRight.X - topLeft.X) / 2), topLeft.Y),
                new Point(topLeft.X, bottomRight.Y / 2),
                new Point((topLeft.X + bottomRight.X / 6), bottomRight.Y),
                new Point(topLeft.X + bottomRight.X / 2, bottomRight.Y),
                new Point(bottomRight.X, bottomRight.Y / 2)            
            };

            pointsT = points;

        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawPolygon(pen, pointsT);
        }

        public override void MouseDraw(Graphics g, Point finish)
        {
            Point[] points =
            {
                new Point (topLeft.X + ((finish.X - topLeft.X) / 2), topLeft.Y),
                new Point(topLeft.X, finish.Y / 2),
                new Point((topLeft.X + finish.X / 6), finish.Y),
                new Point(topLeft.X + finish.X / 2, finish.Y),
                new Point(finish.X, finish.Y / 2)
            };

            pointsT = points;

            g.DrawPolygon(pen, pointsT);
        }

    }


    public class PolygonFabric : Fabric, IFabric
    {
        public override MainFigure FactoryMethod(float fatness, Color color, Point upperLeft, Point lowerRight)
        {
            return new Polygon(fatness, color, upperLeft, lowerRight);
        }
    }
}
