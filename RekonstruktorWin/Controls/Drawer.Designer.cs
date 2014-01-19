namespace RekonstruktorWin.Controls
{
    partial class Drawer
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
            this.contextMenuLine = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuLineName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLineOdebrat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuLine
            // 
            this.contextMenuLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLineName,
            this.toolStripMenuItem1,
            this.menuLineOdebrat});
            this.contextMenuLine.Name = "contextMenuLine";
            this.contextMenuLine.Size = new System.Drawing.Size(118, 54);
            // 
            // menuLineName
            // 
            this.menuLineName.Enabled = false;
            //this.menuLineName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuLineName.Name = "menuLineName";
            this.menuLineName.Size = new System.Drawing.Size(117, 22);
            this.menuLineName.Text = "(X,Y)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // menuLineOdebrat
            // 
            this.menuLineOdebrat.Name = "menuLineOdebrat";
            this.menuLineOdebrat.Size = new System.Drawing.Size(117, 22);
            this.menuLineOdebrat.Text = "Odebrat";
            this.menuLineOdebrat.Click += new System.EventHandler(this.menuLineOdebrat_Click);
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Name = "Drawer";
            this.Size = new System.Drawing.Size(204, 216);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Drawer_MouseWheel);
            this.MouseLeave += new System.EventHandler(this.Drawer_MouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawer_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawer_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Drawer_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawer_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drawer_MouseUp);
            this.contextMenuLine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuLine;
        private System.Windows.Forms.ToolStripMenuItem menuLineName;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuLineOdebrat;
    }
}
