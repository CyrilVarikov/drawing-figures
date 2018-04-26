using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Linq;
using PluginInterfase;

namespace my_primitive_paint
{
    public partial class mainForm : Form
    {
        public Bitmap bmap;
        public Graphics graphics;
        public mainForm()
        {
            InitializeComponent();

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

            //берем из директории все файлы с расширением .dll      
            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                //загружаем сборку
                Assembly asm = Assembly.LoadFrom(file);
               
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
            Figures.Add(new Square(4, Color.Aqua, new Point(30, 30), new Point(130,130)));
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
        private List<ForJSON> jsonList = new List<ForJSON>();

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
                jsonList.Add(new ForJSON() { fatness = fatness, color = color, topLeft = topLeft, bottomRight = bottomRight, fabric = maker.GetType()});
                

                picture.Image = bmap;
            } else
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
                            ForJSON jSON = JsonConvert.DeserializeObject<ForJSON>(dataBlock);
                            jsonList.Add(jSON);
                            Fabric factory = (Fabric)Activator.CreateInstance(jSON.fabric);
                            figure = factory.FactoryMethod(jSON.fatness, jSON.color, jSON.topLeft, jSON.bottomRight);
                            figure.Draw(graphics);

                            picture.Image = bmap;
                        }
                        catch
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
                StreamReader stream = new StreamReader(openFileDialog.OpenFile());

                string data = stream.ReadToEnd();

                string[] dataArray = data.Split('\n');

                stream.Close();
                EditDrawedFigures edit = new EditDrawedFigures(dataArray);
                edit.Show();

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
                StreamWriter stream = new StreamWriter(saveFileDialog.OpenFile());

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
                stream.Close();
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
    }

       
}
