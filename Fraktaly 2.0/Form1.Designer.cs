namespace Fraktaly_2._0
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sierpinskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kochToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.JmenoFraktalu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_sier = new System.Windows.Forms.Panel();
            this.panel_koch = new System.Windows.Forms.Panel();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.hilbertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_hilbert = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel_sier.SuspendLayout();
            this.panel_koch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.panel_hilbert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(210, 34);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(100, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(794, 692);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(126)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Helvetica World", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(9, 674);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = new System.Drawing.Font("Mensch", 27F);
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.numericUpDown1.Location = new System.Drawing.Point(0, 50);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(190, 45);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Tag = "sier";
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fractalToolStripMenuItem,
            this.colorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fractalToolStripMenuItem
            // 
            this.fractalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sierpinskiToolStripMenuItem,
            this.kochToolStripMenuItem,
            this.hilbertToolStripMenuItem});
            this.fractalToolStripMenuItem.Name = "fractalToolStripMenuItem";
            this.fractalToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fractalToolStripMenuItem.Text = "Fractal";
            // 
            // sierpinskiToolStripMenuItem
            // 
            this.sierpinskiToolStripMenuItem.Image = global::Fraktaly_2._0.Properties.Resources.icon;
            this.sierpinskiToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.sierpinskiToolStripMenuItem.Name = "sierpinskiToolStripMenuItem";
            this.sierpinskiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sierpinskiToolStripMenuItem.Text = "Sierpinski";
            this.sierpinskiToolStripMenuItem.Click += new System.EventHandler(this.sierpinskiToolStripMenuItem_Click);
            // 
            // kochToolStripMenuItem
            // 
            this.kochToolStripMenuItem.Name = "kochToolStripMenuItem";
            this.kochToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kochToolStripMenuItem.Text = "Koch";
            this.kochToolStripMenuItem.Click += new System.EventHandler(this.kochToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bWToolStripMenuItem,
            this.greenWhiteToolStripMenuItem});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // bWToolStripMenuItem
            // 
            this.bWToolStripMenuItem.Name = "bWToolStripMenuItem";
            this.bWToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bWToolStripMenuItem.Text = "B&&W";
            this.bWToolStripMenuItem.Click += new System.EventHandler(this.bWToolStripMenuItem_Click);
            // 
            // greenWhiteToolStripMenuItem
            // 
            this.greenWhiteToolStripMenuItem.Name = "greenWhiteToolStripMenuItem";
            this.greenWhiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.greenWhiteToolStripMenuItem.Text = "Green/White";
            this.greenWhiteToolStripMenuItem.Click += new System.EventHandler(this.greenWhiteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label1.Font = new System.Drawing.Font("Helvetica World", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 50);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number of vertices:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // JmenoFraktalu
            // 
            this.JmenoFraktalu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(64)))), ((int)(((byte)(85)))));
            this.JmenoFraktalu.Font = new System.Drawing.Font("Helvetica World", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.JmenoFraktalu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.JmenoFraktalu.Location = new System.Drawing.Point(10, 34);
            this.JmenoFraktalu.Name = "JmenoFraktalu";
            this.JmenoFraktalu.Size = new System.Drawing.Size(190, 50);
            this.JmenoFraktalu.TabIndex = 7;
            this.JmenoFraktalu.Text = "Sierpinski";
            this.JmenoFraktalu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label2.Font = new System.Drawing.Font("Helvetica World", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.label2.Location = new System.Drawing.Point(0, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 50);
            this.label2.TabIndex = 9;
            this.label2.Text = "Number of dots:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.Font = new System.Drawing.Font("Mensch", 23F);
            this.numericUpDown2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.numericUpDown2.Increment = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(0, 150);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(190, 39);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.Tag = "sier";
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label3.Font = new System.Drawing.Font("Helvetica World", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 50);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of steps:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel_sier
            // 
            this.panel_sier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_sier.Controls.Add(this.label1);
            this.panel_sier.Controls.Add(this.numericUpDown1);
            this.panel_sier.Controls.Add(this.label2);
            this.panel_sier.Controls.Add(this.numericUpDown2);
            this.panel_sier.Location = new System.Drawing.Point(224, 44);
            this.panel_sier.Name = "panel_sier";
            this.panel_sier.Size = new System.Drawing.Size(190, 568);
            this.panel_sier.TabIndex = 11;
            // 
            // panel_koch
            // 
            this.panel_koch.Controls.Add(this.label3);
            this.panel_koch.Controls.Add(this.numericUpDown3);
            this.panel_koch.Location = new System.Drawing.Point(424, 44);
            this.panel_koch.Name = "panel_koch";
            this.panel_koch.Size = new System.Drawing.Size(190, 568);
            this.panel_koch.TabIndex = 10;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.numericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown3.Font = new System.Drawing.Font("Mensch", 23F);
            this.numericUpDown3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.numericUpDown3.Location = new System.Drawing.Point(0, 50);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(190, 39);
            this.numericUpDown3.TabIndex = 10;
            this.numericUpDown3.Tag = "sier";
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // hilbertToolStripMenuItem
            // 
            this.hilbertToolStripMenuItem.Name = "hilbertToolStripMenuItem";
            this.hilbertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hilbertToolStripMenuItem.Text = "Hilbert";
            this.hilbertToolStripMenuItem.Click += new System.EventHandler(this.hilbertToolStripMenuItem_Click);
            // 
            // panel_hilbert
            // 
            this.panel_hilbert.Controls.Add(this.label4);
            this.panel_hilbert.Controls.Add(this.numericUpDown4);
            this.panel_hilbert.Location = new System.Drawing.Point(620, 44);
            this.panel_hilbert.Name = "panel_hilbert";
            this.panel_hilbert.Size = new System.Drawing.Size(190, 568);
            this.panel_hilbert.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label4.Font = new System.Drawing.Font("Helvetica World", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 50);
            this.label4.TabIndex = 10;
            this.label4.Text = "Number of steps:H";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.numericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown4.Font = new System.Drawing.Font("Mensch", 23F);
            this.numericUpDown4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.numericUpDown4.Location = new System.Drawing.Point(0, 50);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(190, 39);
            this.numericUpDown4.TabIndex = 10;
            this.numericUpDown4.Tag = "sier";
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1016, 738);
            this.Controls.Add(this.panel_hilbert);
            this.Controls.Add(this.JmenoFraktalu);
            this.Controls.Add(this.panel_sier);
            this.Controls.Add(this.panel_koch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "Fractals";
            this.ResizeEnd += new System.EventHandler(this.button1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel_sier.ResumeLayout(false);
            this.panel_koch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.panel_hilbert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fractalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sierpinskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kochToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label JmenoFraktalu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_sier;
        private System.Windows.Forms.Panel panel_koch;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.ToolStripMenuItem bWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilbertToolStripMenuItem;
        private System.Windows.Forms.Panel panel_hilbert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
    }
}

