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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.pictrue = new System.Windows.Forms.PictureBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.tb_x1 = new System.Windows.Forms.TextBox();
            this.tb_y1 = new System.Windows.Forms.TextBox();
            this.tb_y2 = new System.Windows.Forms.TextBox();
            this.tb_x2 = new System.Windows.Forms.TextBox();
            this.lbl_for_y2 = new System.Windows.Forms.Label();
            this.lbl_for_x2 = new System.Windows.Forms.Label();
            this.lbl_for_y1 = new System.Windows.Forms.Label();
            this.lbl_for_x1 = new System.Windows.Forms.Label();
            this.rb_square = new System.Windows.Forms.RadioButton();
            this.rb_reactangle = new System.Windows.Forms.RadioButton();
            this.rb_ellipse = new System.Windows.Forms.RadioButton();
            this.rb_circle = new System.Windows.Forms.RadioButton();
            this.draw = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictrue)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictrue
            // 
            this.pictrue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.pictrue, "pictrue");
            this.pictrue.Name = "pictrue";
            this.pictrue.TabStop = false;
            // 
            // drawButton
            // 
            this.drawButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.drawButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.drawButton, "drawButton");
            this.drawButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawButton.Name = "drawButton";
            this.drawButton.UseVisualStyleBackColor = false;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // tb_x1
            // 
            resources.ApplyResources(this.tb_x1, "tb_x1");
            this.tb_x1.Name = "tb_x1";
            // 
            // tb_y1
            // 
            resources.ApplyResources(this.tb_y1, "tb_y1");
            this.tb_y1.Name = "tb_y1";
            // 
            // tb_y2
            // 
            resources.ApplyResources(this.tb_y2, "tb_y2");
            this.tb_y2.Name = "tb_y2";
            // 
            // tb_x2
            // 
            resources.ApplyResources(this.tb_x2, "tb_x2");
            this.tb_x2.Name = "tb_x2";
            // 
            // lbl_for_y2
            // 
            resources.ApplyResources(this.lbl_for_y2, "lbl_for_y2");
            this.lbl_for_y2.Name = "lbl_for_y2";
            // 
            // lbl_for_x2
            // 
            resources.ApplyResources(this.lbl_for_x2, "lbl_for_x2");
            this.lbl_for_x2.Name = "lbl_for_x2";
            // 
            // lbl_for_y1
            // 
            resources.ApplyResources(this.lbl_for_y1, "lbl_for_y1");
            this.lbl_for_y1.Name = "lbl_for_y1";
            // 
            // lbl_for_x1
            // 
            resources.ApplyResources(this.lbl_for_x1, "lbl_for_x1");
            this.lbl_for_x1.Name = "lbl_for_x1";
            // 
            // rb_square
            // 
            resources.ApplyResources(this.rb_square, "rb_square");
            this.rb_square.Name = "rb_square";
            this.rb_square.TabStop = true;
            this.rb_square.UseVisualStyleBackColor = true;
            this.rb_square.CheckedChanged += new System.EventHandler(this.rb_square_CheckedChanged);
            // 
            // rb_reactangle
            // 
            resources.ApplyResources(this.rb_reactangle, "rb_reactangle");
            this.rb_reactangle.Name = "rb_reactangle";
            this.rb_reactangle.TabStop = true;
            this.rb_reactangle.UseVisualStyleBackColor = true;
            this.rb_reactangle.CheckedChanged += new System.EventHandler(this.rb_reactangle_CheckedChanged);
            // 
            // rb_ellipse
            // 
            resources.ApplyResources(this.rb_ellipse, "rb_ellipse");
            this.rb_ellipse.Name = "rb_ellipse";
            this.rb_ellipse.TabStop = true;
            this.rb_ellipse.UseVisualStyleBackColor = true;
            this.rb_ellipse.CheckedChanged += new System.EventHandler(this.rb_ellipse_CheckedChanged);
            // 
            // rb_circle
            // 
            resources.ApplyResources(this.rb_circle, "rb_circle");
            this.rb_circle.Name = "rb_circle";
            this.rb_circle.TabStop = true;
            this.rb_circle.UseVisualStyleBackColor = true;
            this.rb_circle.CheckedChanged += new System.EventHandler(this.rb_circle_CheckedChanged);
            // 
            // draw
            // 
            this.draw.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.draw, "draw");
            this.draw.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.draw.Name = "draw";
            this.draw.UseVisualStyleBackColor = false;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.btn_clear, "btn_clear");
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.editToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.rb_circle);
            this.Controls.Add(this.rb_ellipse);
            this.Controls.Add(this.rb_reactangle);
            this.Controls.Add(this.rb_square);
            this.Controls.Add(this.lbl_for_x1);
            this.Controls.Add(this.lbl_for_y1);
            this.Controls.Add(this.lbl_for_x2);
            this.Controls.Add(this.lbl_for_y2);
            this.Controls.Add(this.tb_x2);
            this.Controls.Add(this.tb_y2);
            this.Controls.Add(this.tb_y1);
            this.Controls.Add(this.tb_x1);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.pictrue);
            this.Controls.Add(this.menuStrip1);
            this.Name = "mainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictrue)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictrue;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox tb_x1;
        private System.Windows.Forms.TextBox tb_y1;
        private System.Windows.Forms.TextBox tb_y2;
        private System.Windows.Forms.TextBox tb_x2;
        private System.Windows.Forms.Label lbl_for_y2;
        private System.Windows.Forms.Label lbl_for_x2;
        private System.Windows.Forms.Label lbl_for_y1;
        private System.Windows.Forms.Label lbl_for_x1;
        private System.Windows.Forms.RadioButton rb_square;
        private System.Windows.Forms.RadioButton rb_reactangle;
        private System.Windows.Forms.RadioButton rb_ellipse;
        private System.Windows.Forms.RadioButton rb_circle;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}

