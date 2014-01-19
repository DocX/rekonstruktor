namespace RekonstruktorWin.Components
{
    partial class IsometricView
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
            this.SuspendLayout();
            // 
            // IsometricView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "IsometricView";
            this.Size = new System.Drawing.Size(304, 296);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.IsometricView_MouseWheel);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.IsometricView_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.IsometricView_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IsometricView_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IsometricView_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
