using Newtonsoft.Json;
using PluginInterfase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Xml.Linq;

namespace my_primitive_paint
{

    
    public partial class mainForm : Form
    {
        public Bitmap bmap;
        public Graphics graphics;
        private bool configIsChanged;
        private int currentTheme = -1;

        public mainForm()
        {
            InitializeComponent();

            
    
            bmap = new Bitmap(picture.Width, picture.Height);
            graphics = Graphics.FromImage(bmap);

            RefreshPlugins();

            RefreshPluginsFactory();

            try
            {
                XDocument xdoc = XDocument.Load("configuration.xml");
                string theme = "-1";
                string lang = "-1";
                foreach (XElement configElement in xdoc.Element("configurations").Elements("config"))
                {
                    lang = configElement.Element("language").Value;
                    theme = configElement.Element("theme").Value;

                }

                ts_cmb.SelectedIndex = Convert.ToInt32(lang, 10);
                cmb_themes.SelectedIndex = currentTheme = Convert.ToInt32(theme, 10);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(message, title_mess, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            configIsChanged = false;

            CustomFigure.OpenCustomFigures(cmb_custom_figures, allFabrics);

        }


        private string message = "Something wrong...";
        private string title_mess = "Info";


        private readonly string pluginPath = System.IO.Path.Combine(
                                                Directory.GetCurrentDirectory(),
                                                "Plugins");
        private void RefreshPlugins()
        {
            try
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

                    //asm.GetTypes().Where(x => x.BaseType == typeof(MainFigure))

                    foreach (var type in types)
                    {
                        cb_figures.Items.Add(type.Name);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void RefreshPluginsFactory()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private List<Fabric> currentFabrics = new List<Fabric>();

        private void draw_Click(object sender, EventArgs e)
        {    
            if (IsInt(tb_x1.Text, tb_y1.Text, tb_x2.Text, tb_y2.Text) && (cb_figures.SelectedIndex > -1) && ((Convert.ToInt32(tb_x1.Text, 10) < picture.Width) &&
                (Convert.ToInt32(tb_y1.Text, 10) < picture.Height) && (Convert.ToInt32(tb_x2.Text, 10) < picture.Width) &&
                (Convert.ToInt32(tb_y2.Text, 10) < picture.Height)))
            {
                Point topLeft = new Point(Convert.ToInt32(tb_x1.Text, 10), Convert.ToInt32(tb_y1.Text));
                Point bottomRight = new Point(Convert.ToInt32(tb_x2.Text, 10), Convert.ToInt32(tb_y2.Text));
                figure = maker.FactoryMethod(fatness, color, topLeft, bottomRight);

                figureList.Add(figure);
                //figuresExs.Add(figure);

                figure.Draw(graphics);
                jsonList.Add(new InfoForJSON() { fatness = fatness, color = color, topLeft = topLeft, bottomRight = bottomRight, figureName = maker.ToString() });

                currentFabrics.Add(maker);
                picture.Image = bmap;
            }
            else
            {
                //tb_x1.Text = tb_x2.Text = tb_y1.Text = tb_y2.Text = "";
                MessageBox.Show(message, title_mess, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }



        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            jsonList.Clear();
            figureList.Clear();
            picture.Image = bmap;
            currentFabrics.Clear();
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
                            foreach(Fabric fab in allFabrics)
                            {
                                if(jSON.figureName == fab.ToString())
                                {
                                    jsonList.Add(jSON);
                                    Fabric factory = fab;
                                    figure = factory.FactoryMethod(jSON.fatness, jSON.color, jSON.topLeft, jSON.bottomRight);
                                    figure.Draw(graphics);
                                    picture.Image = bmap;
                                    break;
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(message, title_mess, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public List<Fabric> allFabrics = new List<Fabric>()
        {
            new RectangleFabric(),
            new CircleFabric(),
            new SquareFabric(),
            new EllipseFabric()
        };


        private void cb_figures_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmb_custom_figures.SelectedIndex = -1;
            maker = allFabrics[cb_figures.SelectedIndex];
        }


        private void ChangeLanguage(string lang)
        {


            /*using (ResXResourceWriter resx = new ResXResourceWriter(@".\ru-locale.resx"))
            {
                string[] figures = { "Rectangle", "Circle", "Квадрат", "Элипс" };
                string[] themes = {"Тёмная", "Светлая" };
                resx.AddResource("drawButton", "Все фигуры");
                resx.AddResource("draw", "Нарисовать");
                resx.AddResource("btn_clear", "Очистить");
                resx.AddResource("fileToolStripMenuItem", "Файл");
                resx.AddResource("openToolStripMenuItem", "Открыть");
                resx.AddResource("saveToolStripMenuItem", "Сохранить");
                resx.AddResource("editToolStripMenuItem", "Редактировать");
                resx.AddResource("ts_label", "Язык");
                resx.AddResource("cb_figures", figures);
                resx.AddResource("cmb_themes", themes);
                resx.AddResource("themes_label", "Темы");
                resx.AddResource("message", "Что-то не так...");
                resx.AddResource("title_mess", "Предупреждение");
                resx.AddResource("saveMsg", "Вы хотите сохранить изменения конфигурации?");
                resx.AddResource("saveMsg_title", "Сохранение");
            }*/

            try
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(lang))
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    string[] figures = { "Rectangle", "Circle", "Square", "Ellipse" };
                    string[] themes = { "Dark", "Light" };

                    foreach (DictionaryEntry entry in resxReader)
                    {
                        if ((string)entry.Key == "cb_figures")
                        {
                            figures = (string[])entry.Value;
                        }
                        else if ((string)entry.Key == "cmb_themes")
                        {
                            themes = (string[])entry.Value;
                        }
                        else
                        {
                            keyValuePairs.Add((string)entry.Key, (string)entry.Value);
                        }

                    }

                    foreach (Control c in this.Controls)
                    {
                        if (keyValuePairs.ContainsKey(c.Name))
                        {
                            c.Text = keyValuePairs[c.Name];
                        }

                        if (c is MenuStrip)
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

                        if (c is ToolStrip)
                        {
                            ts.Items[0].Text = keyValuePairs[ts.Items[0].Name];
                        }

                        if (c is ComboBox)
                        {
                            if (c.Name == "cb_figures")
                            {
                                cb_figures.Items.Clear();
                                foreach (var item in figures)
                                {
                                    cb_figures.Items.Add(item);
                                }
                            }

                            if (c.Name == "cmb_themes")
                            {

                                cmb_themes.Items.Clear();
                                foreach (var item in themes)
                                {
                                    cmb_themes.Items.Add(item);
                                }

                            }
                        }

                    }
                    message = keyValuePairs["message"];
                    title_mess = keyValuePairs["title_mess"];
                    saveMsg = keyValuePairs["saveMsg"];
                    saveMsg_title = keyValuePairs["saveMsg_title"];

                }
                RefreshPlugins();

                configIsChanged = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(message, title_mess, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                configIsChanged = false;
            }
            


            
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

        private void ChangeTheme(string theme)
        {
            /*using (ResXResourceWriter resx = new ResXResourceWriter(@".\dark-theme.resx"))
            {
                Color[] colors = { Color.Gray, Color.White };
                Color[] colorsStrip = { Color.FromArgb(50,171,164,164),Color.White };
                Color[] colorsItem = { Color.LightGray, Color.Black};
                Color[] buttColors = { Color.WhiteSmoke, Color.Black };
                resx.AddResource("this", colors);
                resx.AddResource("drawButton", buttColors);
                resx.AddResource("draw", buttColors);
                resx.AddResource("btn_clear", buttColors);
                resx.AddResource("menuStrip1", colorsStrip);
                resx.AddResource("fileToolStripMenuItem", colorsItem);
                resx.AddResource("openToolStripMenuItem", colors);
                resx.AddResource("saveToolStripMenuItem", colors);
                resx.AddResource("editToolStripMenuItem", colors);
                resx.AddResource("ts", colorsStrip);
                resx.AddResource("btn_add_custom_figure", buttColors);
                resx.AddResource("btn_delete_custom_figure", buttColors);
            }*/

            try
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(theme))
                {
                    Dictionary<string, Color[]> keyValuePairs = new Dictionary<string, Color[]>();
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        keyValuePairs.Add((string)entry.Key, (Color[])entry.Value);
                    }

                    foreach (Control c in this.Controls)
                    {
                        if (keyValuePairs.ContainsKey(c.Name))
                        {
                            c.BackColor = keyValuePairs[c.Name][0];
                            c.ForeColor = keyValuePairs[c.Name][1];
                        }

                        if (c is MenuStrip)
                        {
                            foreach (ToolStripMenuItem item in menuStrip1.Items)
                            {
                                item.BackColor = keyValuePairs[item.Name][0];
                                item.ForeColor = keyValuePairs[item.Name][1];
                                foreach (ToolStripMenuItem children in item.DropDownItems)
                                {
                                    children.BackColor = keyValuePairs[children.Name][0];
                                    children.ForeColor = keyValuePairs[children.Name][1];
                                }
                            }
                        }
                    }

                    this.BackColor = keyValuePairs["this"][0];
                    this.ForeColor = keyValuePairs["this"][1];

                }
                configIsChanged = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(message, title_mess, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                configIsChanged = false;
            }
            


        }

        private void cmb_themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cmb_themes.SelectedIndex != -1)
            {
                lbl_for_y2.Focus();
                currentTheme = cmb_themes.SelectedIndex;
                if (cmb_themes.SelectedIndex == 0)
                {
                    ChangeTheme(@".\dark-theme.resx");
                }
                else
                {
                    ChangeTheme(@".\light-theme.resx");
                }
            }
            
            
        }

        private string saveMsg = "Are you want to save configuration?";
        private string saveMsg_title = "Save";

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (configIsChanged)
            {
                DialogResult result = MessageBox.Show(saveMsg, saveMsg_title,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Information,
                                 MessageBoxDefaultButton.Button1,
                                 MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    XDocument xdoc = new XDocument(new XElement("configurations",
                                        new XElement("config",
                                            new XAttribute("name", "userConfig"),
                                            new XElement("language", ts_cmb.SelectedIndex),
                                            new XElement("theme", currentTheme))));
                    xdoc.Save("configuration.xml");

                    

                }
            }

            if (customFigureIsChange)
            {
                if (CustomFigure.savedFigures.Count > 0)
                {
                    CustomFigure.SavingCustomFigures();
                }
            }
            
        }

        private bool customFigureIsChange = false;
        private bool isDrawing = false;
        private Point start, finish;
        private Bitmap tempBm;
        private List<MainFigure> figureList = new List<MainFigure>();

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {

            if (isEdit)
            {
                /*//var croch = edit.PickFigure(figuresExs, e.Location);
                if (croch != null)
                {
                  //  edit.ClearEdit(figuresExs, graphics);
                    //edit.Crochet(croch, graphics);
                    picture.Image = bmap;
                }
                else
                {
                    //edit.ClearEdit(figuresExs, graphics);
                    picture.Image = bmap;
                }*/
            }
            else
            {
                if (isDrawing)
                {
                    finish = new Point(e.X, e.Y);
                    Graphics g = Graphics.FromImage(bmap);
                    figure.MouseDraw(g, finish);
                    isDrawing = false;
                    picture.Invalidate();
                    figureList.Add(figure);
                    //figuresExs.Add(figure);
                    jsonList.Add(new InfoForJSON() { fatness = fatness, color = color, topLeft = start, bottomRight = finish, figureName = maker.ToString() });
                }
            }
            
            
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (isEdit)
            {

            }
            else
            {
                if (isDrawing)
                {
                    finish = new Point(e.X, e.Y);
                    tempBm = new Bitmap(bmap);
                    picture.Image = tempBm;
                    Graphics g = Graphics.FromImage(tempBm);
                    figure.MouseDraw(g, finish);
                    g.Dispose();
                    picture.Invalidate();
                    GC.Collect();
                }
            }
            
        }

        //
        private List<MainFigure> figuresExs = new List<MainFigure>();
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (isEdit)
            {
                
            }
            else
            {
                if (cmb_custom_figures.SelectedIndex >= 0)
                {
                    
                    int index = cmb_custom_figures.SelectedIndex;
                    CustomFigure.DrawCustomFigure(index, graphics, e.Location);
                    
                    picture.Invalidate();
                    picture.Image = bmap;
                }
                else
                {
                    if (cb_figures.SelectedIndex >= 0)
                    {
                        isDrawing = true;
                        start = new Point(e.X, e.Y);
                        figure = maker.FactoryMethod(fatness, color, start, start);
                        currentFabrics.Add(maker);

                    }
                }
            }
            
        }

        private void cmb_custom_figures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_custom_figures.SelectedIndex >= 0)
            {
                cb_figures.SelectedIndex = -1;
            }
            
        }

        private bool isEdit = false;
        private Editing edit = null;

        private void checkbox_edit_CheckedChanged(object sender, EventArgs e)
        {
            if(isEdit == false)
            {
                if(edit == null)
                {
                    edit = new Editing();
                }
                isEdit = true;
            }
            else
            {
                isEdit = false;
                edit.ClearEdit(figureList, graphics);
                picture.Image = bmap;

            }
            
        }

        private void btn_delete_custom_figure_Click(object sender, EventArgs e)
        {
            if(cmb_custom_figures.SelectedIndex >= 0)
            {
                customFigureIsChange = true;
                CustomFigure.DeleteCustomFigure(cmb_custom_figures.SelectedIndex, cmb_custom_figures);
                //cmb_custom_figures.Items.RemoveAt(cmb_custom_figures.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please, pick any custom figure in the combobox", "Woops...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_add_custom_figure_Click(object sender, EventArgs e)
        {
            if (figureList.Count <= 1)
            {
                MessageBox.Show("One or less figures can not be customized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                customFigureIsChange = true;
                CustomFigure.AddCustomFigure(currentFabrics, figureList, cmb_custom_figures);
            }
        }
    }
}