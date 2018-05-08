using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Linq;
using PluginInterfase;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Resources;
using System.Collections;

namespace my_primitive_paint
{
    public partial class mainForm : Form
    {
        public Bitmap bmap;
        public Graphics graphics;
        public mainForm()
        {
            InitializeComponent();

            ts_cmb.SelectedIndex = 1;


            bmap = new Bitmap(picture.Width, picture.Height);
            graphics = Graphics.FromImage(bmap);

            RefreshPlugins();

            RefreshPluginsFactory();

        }





        private readonly string pluginPath = System.IO.Path.Combine(
                                                Directory.GetCurrentDirectory(),
                                                "Plugins");
        private void RefreshPlugins()
        {
            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var types = asm.GetTypes().
                               Where(t => t.GetInterfaces().
                               Where(i => i.FullName == typeof(IFigure).FullName).Any());

                foreach (var type in types)
                {
                    cb_figures.Items.Add(type.Name);
                }
            }
        }

        private void RefreshPluginsFactory()
        {
            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            //get all.dll      
            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                //load assembly
                Assembly asm = Assembly.LoadFrom(file);

                //get needed things
                var types = asm.GetTypes().
                               Where(t => t.GetInterfaces().
                               Where(i => i.FullName == typeof(IFabric).FullName).Any());

                foreach (var type in types)
                {
                    var plugin = (Fabric)Activator.CreateInstance(type);
                    allFabrics.Add(plugin);
                }
            }
        }




        private void drawButton_Click(object sender, EventArgs e)
        {

            Point point1 = new Point(450, 50);
            Point point2 = new Point(370, 150);
            Point point3 = new Point(540, 100);
            Point point4 = new Point(360, 100);
            Point point5 = new Point(530, 150);
            Point[] points =
             {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5

             };

            List<MainFigure> Figures = new List<MainFigure>();
            Figures.Add(new Square(4, Color.Aqua, new Point(30, 30), new Point(130, 130)));
            Figures.Add(new Rectangle(3, Color.Black, new Point(150, 30), new Point(250, 90)));
            Figures.Add(new Ellipse(2, Color.Aquamarine, new Point(200, 110), new Point(350, 200)));
            Figures.Add(new Circle(4, Color.Aqua, new Point(30, 200), new Point(130, 130)));
            Figures.Add(new Polygon(5, Color.Chocolate, points));

            ListOfFigures listOfFigures = new ListOfFigures(Figures);
            listOfFigures.Draw(graphics);

            picture.Image = bmap;

        }

        private MainFigure figure;
        public Fabric maker;

        private bool IsInt(string x1, string y1, string x2, string y2)
        {
            int res = 0;
            if (Int32.TryParse(x1, out res) && Int32.TryParse(y1, out res) && Int32.TryParse(x2, out res) && Int32.TryParse(y2, out res))
            {
                return true;
            }

            return false;
        }

        private const int fatness = 4;
        private Color color = Color.Aquamarine;
        private List<InfoForJSON> jsonList = new List<InfoForJSON>();

        private void draw_Click(object sender, EventArgs e)
        {



            if (IsInt(tb_x1.Text, tb_y1.Text, tb_x2.Text, tb_y2.Text) && (cb_figures.SelectedIndex > -1) && ((Convert.ToInt32(tb_x1.Text, 10) < picture.Width) &&
                (Convert.ToInt32(tb_y1.Text, 10) < picture.Height) && (Convert.ToInt32(tb_x2.Text, 10) < picture.Width) &&
                (Convert.ToInt32(tb_y2.Text, 10) < picture.Height)))
            {
                Point topLeft = new Point(Convert.ToInt32(tb_x1.Text, 10), Convert.ToInt32(tb_y1.Text));
                Point bottomRight = new Point(Convert.ToInt32(tb_x2.Text, 10), Convert.ToInt32(tb_y2.Text));
                figure = maker.FactoryMethod(fatness, color, topLeft, bottomRight);

                figure.Draw(graphics);
                jsonList.Add(new InfoForJSON() { fatness = fatness, color = color, topLeft = topLeft, bottomRight = bottomRight, possitionFabric = cb_figures.SelectedIndex });


                picture.Image = bmap;
            }
            else
            {
                tb_x1.Text = tb_x2.Text = tb_y1.Text = tb_y2.Text = "";
                MessageBox.Show("Invalid coordinate entered or no figure selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }



        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            jsonList.Clear();
            picture.Image = bmap;
        }


        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "/files";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = "figures";
            openFileDialog.DefaultExt = ".json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream = new StreamReader(openFileDialog.OpenFile());

                string data = stream.ReadToEnd();
                {
                    string[] dataArray = data.Split('\n');
                    foreach (string dataBlock in dataArray)
                    {
                        try
                        {
                            InfoForJSON jSON = JsonConvert.DeserializeObject<InfoForJSON>(dataBlock);
                            jsonList.Add(jSON);
                            Fabric factory = allFabrics[jSON.possitionFabric];
                            figure = factory.FactoryMethod(jSON.fatness, jSON.color, jSON.topLeft, jSON.bottomRight);
                            figure.Draw(graphics);

                            picture.Image = bmap;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Some figure is not valid...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                    }
                }
                stream.Close();

            }
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "/files";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = "figures";
            openFileDialog.DefaultExt = ".json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader stream = new StreamReader(openFileDialog.OpenFile()))
                {
                    string data = stream.ReadToEnd();

                    string[] dataArray = data.Split('\n');

                    EditDrawedFigures edit = new EditDrawedFigures(dataArray);
                    edit.Show();
                }
            }
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "figures";
            saveFileDialog.DefaultExt = ".json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter stream = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    using (JsonWriter writer = new JsonTextWriter(stream))
                    {
                        for (int i = 0; i < jsonList.Count; i++)
                        {
                            serializer.Serialize(writer, jsonList[i]);
                            if (i != jsonList.Count - 1)
                                stream.Write('\n');
                        }
                    }
                };
            }
        }

        List<Fabric> allFabrics = new List<Fabric>()
        {
            new RectangleFabric(),
            new CircleFabric(),
            new SquareFabric(),
            new EllipseFabric()
        };


        private void cb_figures_SelectionChangeCommitted(object sender, EventArgs e)
        {
            maker = allFabrics[cb_figures.SelectedIndex];
        }


        private void ChangeLanguage(string lang)
        {


            /*using (ResXResourceWriter resx = new ResXResourceWriter(@".\en-locale.resx"))
            {
                string[] figures = { "Rectangle", "Circle", "Square", "Ellipse" };
                resx.AddResource("drawButton", "All figures");
                resx.AddResource("draw", "Draw");
                resx.AddResource("btn_clear", "Clear");
                resx.AddResource("fileToolStripMenuItem", "File");
                resx.AddResource("openToolStripMenuItem", "Open");
                resx.AddResource("saveToolStripMenuItem", "Save");
                resx.AddResource("editToolStripMenuItem", "Edit");
                resx.AddResource("ts_label", "Language");
                resx.AddResource("cb_figures", figures);
                //resx.AddResource("Title", "Classic American Cars");
                //resx.AddResource("Title", "Classic American Cars");
                //resx.AddResource("Title", "Classic American Cars");
                //resx.AddResource("Title", "Classic American Cars");
            }*/

            
            using (ResXResourceReader resxReader = new ResXResourceReader(lang))
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                string[] figures = {"Rectangle","Circle","Square","Ellipse" };
                foreach (DictionaryEntry entry in resxReader)
                {
                    if((string)entry.Key == "cb_figures")
                    {
                        figures = (string[])entry.Value;
                    }
                    else
                    {
                        keyValuePairs.Add((string)entry.Key, (string)entry.Value);
                    }
                    
                }

                foreach( Control c in this.Controls)
                {
                    if (keyValuePairs.ContainsKey(c.Name))
                    {
                        c.Text = keyValuePairs[c.Name];
                    }

                    if(c is MenuStrip)
                    {
                        foreach (ToolStripMenuItem item in menuStrip1.Items)
                        {
                            item.Text = keyValuePairs[item.Name];
                            foreach (ToolStripMenuItem children in item.DropDownItems)
                            {
                                children.Text = keyValuePairs[children.Name];
                            }
                        }
                    }

                    if(c is ToolStrip)
                    {
                        ts.Items[0].Text = keyValuePairs[ts.Items[0].Name];
                    }

                    if(c is ComboBox)
                    {
                        cb_figures.Items.Clear();
                        foreach(var item in figures)
                        {
                            cb_figures.Items.Add(item);
                        }
                    }
                    
                }

            }


            RefreshPlugins();
        }


        private void ts_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_for_y2.Focus();
            if (ts_cmb.SelectedIndex == 0)
            {
                ChangeLanguage(@".\ru-locale.resx");
            }
            else
            {
                ChangeLanguage(@".\en-locale.resx");
            }
        }
    }
}