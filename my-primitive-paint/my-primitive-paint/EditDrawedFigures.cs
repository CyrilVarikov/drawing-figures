using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_primitive_paint
{
    public partial class EditDrawedFigures : Form
    {
        public EditDrawedFigures(string[] data)
        {
            
            InitializeComponent();
            for (int i = 0; i < data.Length; i++)
            {
                rtb_json.Text += data[i];
                if(i != data.Length - 1)
                {
                    rtb_json.Text += "\n\n";
                }
            }
              
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "figures";
            saveFileDialog.DefaultExt = ".json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(saveFileDialog.OpenFile());

                stream.Write(rtb_json.Text.Replace("\n\n", "\n"));
                stream.Close();
            }
        }
    }
}
