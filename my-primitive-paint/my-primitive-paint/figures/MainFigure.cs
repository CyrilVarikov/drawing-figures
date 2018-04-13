using Newtonsoft.Json;
using System;
using System.Drawing;




namespace my_primitive_paint
{

    public abstract class MainFigure 
    {
        [JsonProperty]
        public Color color;
   
        [JsonProperty]
        public float fatness;

        [NonSerializedAttribute]
        public Pen pen;

        [JsonProperty]
        public Point topLeft;

        [JsonProperty]
        public Point bottomRight;

        [NonSerializedAttribute]
        public Point[] points;

        [JsonConstructor]
        public MainFigure(float fatness, Color color, Point topLeft, Point bottomRight)
        {
            this.fatness = fatness;
            this.color = color;
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            pen = new Pen(color, fatness);
        }

        public MainFigure(float fatness, Color color, Point[] points)
        {
            this.points = points;
            this.fatness = fatness;
            this.color = color;
            pen = new Pen(color, fatness);
        }


        public virtual void Draw(Graphics graphics) { }

 
    }
}
