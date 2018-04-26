using my_primitive_paint;
using PluginInterfase;
using System.Drawing;

namespace PluginForTriangle
{
    public class Triangle : MainFigure, IFigure
    {
        private Point[] pointsT;
        public Triangle(float fatness, Color color, Point topLeft, Point bottomRight) : base(fatness, color, topLeft, bottomRight)
        {
            Point[] points =
            {
                topLeft,
                new Point(topLeft.X, bottomRight.Y),
                bottomRight
            };

            pointsT = points;

        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawPolygon(pen, pointsT);
        }

    }
       

    public class TriangleFabric : Fabric, IFabric
    {
        public override MainFigure FactoryMethod(float fatness, Color color, Point upperLeft, Point lowerRight)
        {
            return new Triangle(fatness, color, upperLeft, lowerRight);
        }
    }

       


}

