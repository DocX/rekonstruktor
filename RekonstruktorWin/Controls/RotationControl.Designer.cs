namespace RekonstruktorWin.Controls
{
    partial class RotationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonXminus = new System.Windows.Forms.Button();
            this.buttonZminus = new System.Windows.Forms.Button();
            this.buttonYminus = new System.Windows.Forms.Button();
            this.buttonYplus = new System.Windows.Forms.Button();
            this.buttonZplus = new System.Windows.Forms.Button();
            this.buttonXplus = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.MenuPredvolene = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPredvolene.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonXminus
            // 
            this.buttonXminus.Location = new System.Drawing.Point(0, 0);
            this.buttonXminus.Name = "buttonXminus";
            this.buttonXminus.Size = new System.Drawing.Size(28, 23);
            this.buttonXminus.TabIndex = 0;
            this.buttonXminus.Text = "-";
            this.buttonXminus.UseVisualStyleBackColor = true;
            this.buttonXminus.Click += new System.EventHandler(this.buttonXminus_Click);
            this.buttonXminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseDown);
            this.buttonXminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseUp);
            // 
            // buttonZminus
            // 
            this.buttonZminus.Location = new System.Drawing.Point(0, 58);
            this.buttonZminus.Name = "buttonZminus";
            this.buttonZminus.Size = new System.Drawing.Size(28, 23);
            this.buttonZminus.TabIndex = 4;
            this.buttonZminus.Text = "-";
            this.buttonZminus.UseVisualStyleBackColor = true;
            this.buttonZminus.Click += new System.EventHandler(this.buttonZminus_Click);
            this.buttonZminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZminus_MouseDown);
            this.buttonZminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseUp);
            // 
            // buttonYminus
            // 
            this.buttonYminus.Location = new System.Drawing.Point(0, 29);
            this.buttonYminus.Name = "buttonYminus";
            this.buttonYminus.Size = new System.Drawing.Size(28, 23);
            this.buttonYminus.TabIndex = 2;
            this.buttonYminus.Text = "-";
            this.buttonYminus.UseVisualStyleBackColor = true;
            this.buttonYminus.Click += new System.EventHandler(this.buttonYminus_Click);
            this.buttonYminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonYminus_MouseDown);
            this.buttonYminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseUp);
            // 
            // buttonYplus
            // 
            this.buttonYplus.Location = new System.Drawing.Point(54, 29);
            this.buttonYplus.Name = "buttonYplus";
            this.buttonYplus.Size = new System.Drawing.Size(28, 23);
            this.buttonYplus.TabIndex = 3;
            this.buttonYplus.Text = "+";
            this.buttonYplus.UseVisualStyleBackColor = true;
            this.buttonYplus.Click += new System.EventHandler(this.buttonYplus_Click);
            this.buttonYplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonYplus_MouseDown);
            this.buttonYplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseUp);
            // 
            // buttonZplus
            // 
            this.buttonZplus.Location = new System.Drawing.Point(54, 58);
            this.buttonZplus.Name = "buttonZplus";
            this.buttonZplus.Size = new System.Drawing.Size(28, 23);
            this.buttonZplus.TabIndex = 5;
            this.buttonZplus.Text = "+";
            this.buttonZplus.UseVisualStyleBackColor = true;
            this.buttonZplus.Click += new System.EventHandler(this.buttonZplus_Click);
            this.buttonZplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZplus_MouseDown);
            this.buttonZplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseUp);
            // 
            // buttonXplus
            // 
            this.buttonXplus.Location = new System.Drawing.Point(54, 0);
            this.buttonXplus.Name = "buttonXplus";
            this.buttonXplus.Size = new System.Drawing.Size(28, 23);
            this.buttonXplus.TabIndex = 1;
            this.buttonXplus.Text = "+";
            this.buttonXplus.UseVisualStyleBackColor = true;
            this.buttonXplus.Click += new System.EventHandler(this.buttonXplus_Click);
            this.buttonXplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXplus_MouseDown);
            this.buttonXplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXminus_MouseUp);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(34, 5);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 6;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(34, 34);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 7;
            this.labelY.Text = "Y";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(34, 63);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 13);
            this.labelZ.TabIndex = 8;
            this.labelZ.Text = "Z";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Předvolené";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuPredvolene
            // 
            this.MenuPredvolene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topToolStripMenuItem,
            this.bottomToolStripMenuItem,
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.frontToolStripMenuItem,
            this.backToolStripMenuItem,
            this.sWToolStripMenuItem,
            this.sEToolStripMenuItem,
            this.nEToolStripMenuItem,
            this.nWToolStripMenuItem});
            this.MenuPredvolene.Name = "MenuPredvolene";
            this.MenuPredvolene.Size = new System.Drawing.Size(153, 246);
            // 
            // sEToolStripMenuItem
            // 
            this.sEToolStripMenuItem.Name = "sEToolStripMenuItem";
            this.sEToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sEToolStripMenuItem.Text = "SE";
            this.sEToolStripMenuItem.Click += new System.EventHandler(this.sEToolStripMenuItem_Click);
            // 
            // sWToolStripMenuItem
            // 
            this.sWToolStripMenuItem.Name = "sWToolStripMenuItem";
            this.sWToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sWToolStripMenuItem.Text = "SW";
            this.sWToolStripMenuItem.Click += new System.EventHandler(this.sWToolStripMenuItem_Click);
            // 
            // nEToolStripMenuItem
            // 
            this.nEToolStripMenuItem.Name = "nEToolStripMenuItem";
            this.nEToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nEToolStripMenuItem.Text = "NE";
            this.nEToolStripMenuItem.Click += new System.EventHandler(this.nEToolStripMenuItem_Click);
            // 
            // nWToolStripMenuItem
            // 
            this.nWToolStripMenuItem.Name = "nWToolStripMenuItem";
            this.nWToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nWToolStripMenuItem.Text = "NW";
            this.nWToolStripMenuItem.Click += new System.EventHandler(this.nWToolStripMenuItem_Click);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leftToolStripMenuItem.Text = "Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rightToolStripMenuItem.Text = "Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bottomToolStripMenuItem.Text = "Bottom";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.bottomToolStripMenuItem_Click);
            // 
            // frontToolStripMenuItem
            // 
            this.frontToolStripMenuItem.Name = "frontToolStripMenuItem";
            this.frontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.frontToolStripMenuItem.Text = "Front";
            this.frontToolStripMenuItem.Click += new System.EventHandler(this.frontToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // RotationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.buttonYplus);
            this.Controls.Add(this.buttonZplus);
            this.Controls.Add(this.buttonXplus);
            this.Controls.Add(this.buttonYminus);
            this.Controls.Add(this.buttonZminus);
            this.Controls.Add(this.buttonXminus);
            this.Name = "RotationControl";
            this.Size = new System.Drawing.Size(85, 113);
            this.MenuPredvolene.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonXminus;
        private System.Windows.Forms.Button buttonZminus;
        private System.Windows.Forms.Button buttonYminus;
        private System.Windows.Forms.Button buttonYplus;
        private System.Windows.Forms.Button buttonZplus;
        private System.Windows.Forms.Button buttonXplus;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip MenuPredvolene;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nWToolStripMenuItem;
    }
}
