namespace my_primitive_paint
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawButton = new System.Windows.Forms.Button();
            this.tb_x1 = new System.Windows.Forms.TextBox();
            this.tb_y1 = new System.Windows.Forms.TextBox();
            this.tb_y2 = new System.Windows.Forms.TextBox();
            this.tb_x2 = new System.Windows.Forms.TextBox();
            this.lbl_for_y2 = new System.Windows.Forms.Label();
            this.lbl_for_x2 = new System.Windows.Forms.Label();
            this.lbl_for_y1 = new System.Windows.Forms.Label();
            this.lbl_for_x1 = new System.Windows.Forms.Label();
            this.draw = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picture = new System.Windows.Forms.PictureBox();
            this.cb_figures = new System.Windows.Forms.ComboBox();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.ts_label = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_cmb = new System.Windows.Forms.ToolStripComboBox();
            this.cmb_themes = new System.Windows.Forms.ComboBox();
            this.themes_label = new System.Windows.Forms.Label();
            this.btn_add_custom_figure = new System.Windows.Forms.Button();
            this.btn_delete_custom_figure = new System.Windows.Forms.Button();
            this.cmb_custom_figures = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawButton
            // 
            this.drawButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.drawButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drawButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.drawButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawButton.Location = new System.Drawing.Point(1132, 499);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(106, 42);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "Draw figures";
            this.drawButton.UseVisualStyleBackColor = false;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // tb_x1
            // 
            this.tb_x1.Location = new System.Drawing.Point(1005, 80);
            this.tb_x1.Name = "tb_x1";
            this.tb_x1.Size = new System.Drawing.Size(52, 22);
            this.tb_x1.TabIndex = 2;
            // 
            // tb_y1
            // 
            this.tb_y1.Location = new System.Drawing.Point(1005, 142);
            this.tb_y1.Name = "tb_y1";
            this.tb_y1.Size = new System.Drawing.Size(52, 22);
            this.tb_y1.TabIndex = 3;
            // 
            // tb_y2
            // 
            this.tb_y2.Location = new System.Drawing.Point(1083, 142);
            this.tb_y2.Name = "tb_y2";
            this.tb_y2.Size = new System.Drawing.Size(52, 22);
            this.tb_y2.TabIndex = 4;
            // 
            // tb_x2
            // 
            this.tb_x2.Location = new System.Drawing.Point(1083, 80);
            this.tb_x2.Name = "tb_x2";
            this.tb_x2.Size = new System.Drawing.Size(52, 22);
            this.tb_x2.TabIndex = 5;
            // 
            // lbl_for_y2
            // 
            this.lbl_for_y2.AutoSize = true;
            this.lbl_for_y2.Location = new System.Drawing.Point(1080, 122);
            this.lbl_for_y2.Name = "lbl_for_y2";
            this.lbl_for_y2.Size = new System.Drawing.Size(23, 17);
            this.lbl_for_y2.TabIndex = 6;
            this.lbl_for_y2.Text = "y2";
            // 
            // lbl_for_x2
            // 
            this.lbl_for_x2.AutoSize = true;
            this.lbl_for_x2.Location = new System.Drawing.Point(1080, 60);
            this.lbl_for_x2.Name = "lbl_for_x2";
            this.lbl_for_x2.Size = new System.Drawing.Size(22, 17);
            this.lbl_for_x2.TabIndex = 7;
            this.lbl_for_x2.Text = "x2";
            // 
            // lbl_for_y1
            // 
            this.lbl_for_y1.AutoSize = true;
            this.lbl_for_y1.Location = new System.Drawing.Point(1002, 122);
            this.lbl_for_y1.Name = "lbl_for_y1";
            this.lbl_for_y1.Size = new System.Drawing.Size(23, 17);
            this.lbl_for_y1.TabIndex = 8;
            this.lbl_for_y1.Text = "y1";
            // 
            // lbl_for_x1
            // 
            this.lbl_for_x1.AutoSize = true;
            this.lbl_for_x1.Location = new System.Drawing.Point(1002, 60);
            this.lbl_for_x1.Name = "lbl_for_x1";
            this.lbl_for_x1.Size = new System.Drawing.Size(22, 17);
            this.lbl_for_x1.TabIndex = 9;
            this.lbl_for_x1.Text = "x1";
            // 
            // draw
            // 
            this.draw.BackColor = System.Drawing.Color.DimGray;
            this.draw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw.ForeColor = System.Drawing.Color.White;
            this.draw.Location = new System.Drawing.Point(1132, 192);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(128, 29);
            this.draw.TabIndex = 15;
            this.draw.Text = "Draw";
            this.draw.UseVisualStyleBackColor = false;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_clear.Location = new System.Drawing.Point(1132, 432);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(106, 39);
            this.btn_clear.TabIndex = 16;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.editToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picture.Location = new System.Drawing.Point(0, 31);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(959, 531);
            this.picture.TabIndex = 18;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            // 
            // cb_figures
            // 
            this.cb_figures.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cb_figures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_figures.FormattingEnabled = true;
            this.cb_figures.Items.AddRange(new object[] {
            "Rectangle",
            "Circle",
            "Square",
            "Ellipse"});
            this.cb_figures.Location = new System.Drawing.Point(978, 192);
            this.cb_figures.Name = "cb_figures";
            this.cb_figures.Size = new System.Drawing.Size(148, 24);
            this.cb_figures.TabIndex = 19;
            this.cb_figures.SelectionChangeCommitted += new System.EventHandler(this.cb_figures_SelectionChangeCommitted);
            // 
            // ts
            // 
            this.ts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_label,
            this.toolStripSeparator2,
            this.ts_cmb});
            this.ts.Location = new System.Drawing.Point(0, 560);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(1272, 28);
            this.ts.TabIndex = 0;
            // 
            // ts_label
            // 
            this.ts_label.Name = "ts_label";
            this.ts_label.Size = new System.Drawing.Size(77, 25);
            this.ts_label.Text = "Language:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // ts_cmb
            // 
            this.ts_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ts_cmb.Items.AddRange(new object[] {
            "русский (Россия)",
            "English (United State)"});
            this.ts_cmb.Name = "ts_cmb";
            this.ts_cmb.Size = new System.Drawing.Size(180, 28);
            this.ts_cmb.SelectedIndexChanged += new System.EventHandler(this.ts_cmb_SelectedIndexChanged);
            // 
            // cmb_themes
            // 
            this.cmb_themes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_themes.FormattingEnabled = true;
            this.cmb_themes.Items.AddRange(new object[] {
            "Dark",
            "Light"});
            this.cmb_themes.Location = new System.Drawing.Point(979, 261);
            this.cmb_themes.Name = "cmb_themes";
            this.cmb_themes.Size = new System.Drawing.Size(147, 24);
            this.cmb_themes.TabIndex = 20;
            this.cmb_themes.SelectedIndexChanged += new System.EventHandler(this.cmb_themes_SelectedIndexChanged);
            // 
            // themes_label
            // 
            this.themes_label.AutoSize = true;
            this.themes_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themes_label.Location = new System.Drawing.Point(974, 238);
            this.themes_label.Name = "themes_label";
            this.themes_label.Size = new System.Drawing.Size(69, 20);
            this.themes_label.TabIndex = 21;
            this.themes_label.Text = "Themes";
            // 
            // btn_add_custom_figure
            // 
            this.btn_add_custom_figure.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_add_custom_figure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_custom_figure.ForeColor = System.Drawing.Color.White;
            this.btn_add_custom_figure.Location = new System.Drawing.Point(979, 432);
            this.btn_add_custom_figure.Name = "btn_add_custom_figure";
            this.btn_add_custom_figure.Size = new System.Drawing.Size(97, 39);
            this.btn_add_custom_figure.TabIndex = 22;
            this.btn_add_custom_figure.Text = "Add CF";
            this.btn_add_custom_figure.UseVisualStyleBackColor = false;
            this.btn_add_custom_figure.Click += new System.EventHandler(this.btn_add_custom_figure_Click);
            // 
            // btn_delete_custom_figure
            // 
            this.btn_delete_custom_figure.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_delete_custom_figure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_delete_custom_figure.ForeColor = System.Drawing.Color.White;
            this.btn_delete_custom_figure.Location = new System.Drawing.Point(979, 499);
            this.btn_delete_custom_figure.Name = "btn_delete_custom_figure";
            this.btn_delete_custom_figure.Size = new System.Drawing.Size(97, 42);
            this.btn_delete_custom_figure.TabIndex = 23;
            this.btn_delete_custom_figure.Text = "Delete CF";
            this.btn_delete_custom_figure.UseVisualStyleBackColor = false;
            // 
            // cmb_custom_figures
            // 
            this.cmb_custom_figures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_custom_figures.FormattingEnabled = true;
            this.cmb_custom_figures.Location = new System.Drawing.Point(979, 356);
            this.cmb_custom_figures.Name = "cmb_custom_figures";
            this.cmb_custom_figures.Size = new System.Drawing.Size(148, 24);
            this.cmb_custom_figures.TabIndex = 24;
            this.cmb_custom_figures.SelectedIndexChanged += new System.EventHandler(this.cmb_custom_figures_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(979, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Custom figures";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1272, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_custom_figures);
            this.Controls.Add(this.btn_delete_custom_figure);
            this.Controls.Add(this.btn_add_custom_figure);
            this.Controls.Add(this.themes_label);
            this.Controls.Add(this.cmb_themes);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.cb_figures);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.lbl_for_x1);
            this.Controls.Add(this.lbl_for_y1);
            this.Controls.Add(this.lbl_for_x2);
            this.Controls.Add(this.lbl_for_y2);
            this.Controls.Add(this.tb_x2);
            this.Controls.Add(this.tb_y2);
            this.Controls.Add(this.tb_y1);
            this.Controls.Add(this.tb_x1);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1290, 635);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "my-paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox tb_x1;
        private System.Windows.Forms.TextBox tb_y1;
        private System.Windows.Forms.TextBox tb_y2;
        private System.Windows.Forms.TextBox tb_x2;
        private System.Windows.Forms.Label lbl_for_y2;
        private System.Windows.Forms.Label lbl_for_x2;
        private System.Windows.Forms.Label lbl_for_y1;
        private System.Windows.Forms.Label lbl_for_x1;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.ComboBox cb_figures;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripLabel ts_label;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox ts_cmb;
        public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_themes;
        private System.Windows.Forms.Label themes_label;
        private System.Windows.Forms.Button btn_add_custom_figure;
        private System.Windows.Forms.Button btn_delete_custom_figure;
        public System.Windows.Forms.ComboBox cmb_custom_figures;
        private System.Windows.Forms.Label label1;
    }
}

