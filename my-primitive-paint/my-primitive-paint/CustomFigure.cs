using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_primitive_paint
{
    public class CustomFigure
    {
        public static List<List<MainFigure>> savedFigures = new List<List<MainFigure>>();
        

        public static void AddCustomFigure(List<MainFigure> figures, ComboBox combobox)
        {
            List<MainFigure> temp = new List<MainFigure>(figures);
            combobox.Items.Add("CustomFigures" + savedFigures.Count.ToString());
            savedFigures.Add(temp);
        }

        private static MainFigure GetBiggestFigure(List<MainFigure> figures)
        {
            MainFigure biggestFigrue = null;
            foreach(var figure in figures)
            {
                if(biggestFigrue == null)
                {
                    biggestFigrue = figure;
                }
                else
                {
                    if(((biggestFigrue.bottomRight.X - biggestFigrue.topLeft.X) 
                        + (biggestFigrue.bottomRight.Y - biggestFigrue.topLeft.Y)) * 2 < ((figure.bottomRight.X - figure.topLeft.X)
                        + (figure.bottomRight.Y - figure.topLeft.Y)) * 2)
                    {
                        biggestFigrue = figure;
                    }
                }
            }
            return biggestFigrue;
        }

        private static Point GetCenterOfFigure(MainFigure figure)
        {
            return new Point(figure.topLeft.X + ((figure.bottomRight.X - figure.topLeft.X) / 2),
                figure.topLeft.Y + ((figure.bottomRight.Y - figure.topLeft.Y) / 2));
        }

        private static int GetOffsetX(Point mainCenter, Point figureCenter)
        {
            if (mainCenter.X > figureCenter.X)
            {
                return -(mainCenter.X - figureCenter.X);
            }
            else
            {
                return figureCenter.X - mainCenter.X;
            }
        }

        private static int GetOffsetY(Point mainCenter, Point figureCenter)
        {
            if (mainCenter.Y > figureCenter.Y)
            {
                return -(mainCenter.Y - figureCenter.Y);
            }
            else
            {
                return figureCenter.Y - mainCenter.Y;
            }
        }

        private static Point GetNewCenter(Point center, int offsetX, int offsetY)
        {
            return new Point(center.X + offsetX, center.Y + offsetY);
        }

        private static MainFigure GetFigure(Point center, MainFigure figure)
        {
            int newTopLeftX, newTopLeftY;
            int newBottomRightX, newBottomRightY;

            newTopLeftX = center.X - ((figure.bottomRight.X - figure.topLeft.X) / 2);
            newTopLeftY = center.Y - ((figure.bottomRight.Y - figure.topLeft.Y) / 2);

            newBottomRightX = center.X + ((figure.bottomRight.X - figure.topLeft.X) / 2);
            newBottomRightY = center.Y + ((figure.bottomRight.Y - figure.topLeft.Y) / 2);


            return (MainFigure)Activator.CreateInstance(figure.GetType(), 3, Color.Aquamarine,
                new Point(newTopLeftX, newTopLeftY),
                new Point(newBottomRightX, newBottomRightY));
        }

        public static List<MainFigure> DrawCustomFigure(int index, Graphics g, Point possition)
        {
            

            MainFigure biggestFigure = GetBiggestFigure(savedFigures[index]);
            //biggestFigure = GetFigure(possition, biggestFigure);
            Point oldCenter = GetCenterOfFigure(biggestFigure);
            //biggestFigure.Draw(g);

            //savedFigures[index].Remove(biggestFigure);

            int offsetX = 0;
            int offsetY = 0;
            MainFigure tempFigure;

            foreach (var figure in savedFigures[index])
            {
                Point centerFigure = GetCenterOfFigure(figure);
                offsetX = GetOffsetX(oldCenter, centerFigure);
                offsetY = GetOffsetY(oldCenter, centerFigure);

                Point newCenter = GetNewCenter(possition, offsetX, offsetY);

                tempFigure = GetFigure(newCenter, figure);
                tempFigure.Draw(g);
                
            }
            return savedFigures[index];
        }

        public static void DeleteCustomFigure(int index)
        {
            savedFigures.RemoveAt(index);
        }

        public static void SavingCustomFigures()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "CustomFigures";
            saveFileDialog.DefaultExt = ".json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter stream = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    using (JsonWriter writer = new JsonTextWriter(stream))
                    {
                        for (int i = 0; i < savedFigures.Count; i++)
                        {
                            serializer.Serialize(writer, savedFigures[i]);
                            if (i != savedFigures.Count - 1)
                                stream.Write('\n');
                        }
                    }
                };
            }
        }
    }
}
