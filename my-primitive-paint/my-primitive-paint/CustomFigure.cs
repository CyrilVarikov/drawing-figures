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
    public static class CustomFigure
    {
        public static List<List<MainFigure>> savedFigures = new List<List<MainFigure>>();
        public static List<List<Fabric>> fabrics = new List<List<Fabric>>();

        public static void AddCustomFigure(List<Fabric> currFabics, List<MainFigure> figures, ComboBox combobox)
        {
            List<MainFigure> temp = new List<MainFigure>(figures);
            List<Fabric> tempCurrFab = new List<Fabric>(currFabics);
            combobox.Items.Add("CustomFigures" + savedFigures.Count.ToString());
            savedFigures.Add(temp);
            fabrics.Add(tempCurrFab);
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
            Point oldCenter = GetCenterOfFigure(biggestFigure);

            List<MainFigure> temps = new List<MainFigure>();

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
                temps.Add(tempFigure);
            }

            return temps;
        }

        public static void DeleteCustomFigure(int index, ComboBox cmb)
        {
            savedFigures.RemoveAt(index);
            fabrics.RemoveAt(index);
            cmb.Items.Clear();
            for(int i = 0; i < savedFigures.Count; i++)
            {
                cmb.Items.Add("CustomFigures" + i.ToString());

            }
        }

        private static List<InfoForJSON> jsonList = new List<InfoForJSON>();
        private static List<int> countFigures = new List<int>();
        public static void SavingCustomFigures()
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "CustomFigures";
            saveFileDialog.DefaultExt = ".json";*/

            try
            {
                using (StreamWriter stream = new StreamWriter(@"CustomFigures.json", false))
                {
                    int i = 0;
                    int j = 0;
                    Fabric fabric;
                    foreach (var figures in savedFigures)
                    {
                        j = 0;
                        countFigures.Add(figures.Count);
                        foreach (var figure in figures)
                        {
                            fabric = fabrics[i][j];
                            jsonList.Add(new InfoForJSON() { fatness = figure.pen.Width, color = figure.pen.Color, topLeft = figure.topLeft, bottomRight = figure.bottomRight, figureName = fabric.ToString() });
                            j++;
                        }
                        i++;
                    }
                    JsonSerializer serializer = new JsonSerializer();

                    using (JsonWriter writer = new JsonTextWriter(stream))
                    {
                        serializer.Serialize(writer, countFigures);
                        stream.Write('\n');
                        for (i = 0; i < jsonList.Count; i++)
                        {
                            serializer.Serialize(writer, jsonList[i]);
                            if (i != jsonList.Count - 1)
                                stream.Write('\n');
                        }
                    }
                };
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        public static void OpenCustomFigures(ComboBox combobox, List<Fabric> exsistingFabric) 
        {
            try
            {
                using (StreamReader stream = new StreamReader(@"CustomFigures.json"))
                {
                    if (stream.Peek() != -1)
                    {
                        MainFigure figure;
                        List<MainFigure> figures = new List<MainFigure>();
                        List<Fabric> fabrics = new List<Fabric>();
                        string data = stream.ReadToEnd();
                        string[] dataArray = data.Split('\n');
                        List<int> countFigures = JsonConvert.DeserializeObject<List<int>>(dataArray[0]);
                        int j = 1;
                        foreach (var count in countFigures)
                        {

                            for (int i = j; i < count + j; i++)
                            {
                                InfoForJSON jSON = JsonConvert.DeserializeObject<InfoForJSON>(dataArray[i]);
                                foreach (Fabric fab in exsistingFabric)
                                {
                                    if (jSON.figureName == fab.ToString())
                                    {
                                        jsonList.Add(jSON);
                                        figure = fab.FactoryMethod(jSON.fatness, jSON.color, jSON.topLeft, jSON.bottomRight);
                                        figures.Add(figure);
                                        fabrics.Add(fab);
                                        break;
                                    }
                                }
                            }
                            AddCustomFigure(fabrics, figures, combobox);
                            fabrics.Clear();
                            figures.Clear();
                            j = count + j;

                        }
                    } 
                    
                    
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong...", "Problems", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //continue;
            }

            jsonList.Clear();
            
        }
    }
}
