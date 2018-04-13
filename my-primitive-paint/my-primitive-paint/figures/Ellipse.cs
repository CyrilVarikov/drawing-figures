using System.Drawing;


namespace my_primitive_paint
{
    public class Ellipse : MainFigure
    {
        public Ellipse(float fatness, Color color, Point topLeft, Point bottomRight) : base(fatness, color, topLeft, bottomRight) { }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(pen, topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
        }
    }
}
