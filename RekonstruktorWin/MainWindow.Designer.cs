namespace RekonstruktorWin
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawerShora = new RekonstruktorWin.Controls.Drawer();
            this.drawerZepredu = new RekonstruktorWin.Controls.Drawer();
            this.drawerZprava = new RekonstruktorWin.Controls.Drawer();
            this.pohledDratenehoModelu = new RekonstruktorWin.Components.IsometricView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxProjection = new System.Windows.Forms.CheckBox();
            this.checkBoxCross = new System.Windows.Forms.CheckBox();
            this.checkBoxSnap = new System.Windows.Forms.CheckBox();
            this.checkBoxStep = new System.Windows.Forms.CheckBox();
            this.checkBoxGrid = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rotationControl1 = new RekonstruktorWin.Controls.RotationControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3DCross = new System.Windows.Forms.CheckBox();
            this.checkBoxVsechnyPrusecnice = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.načístToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportovat3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nákresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyčistitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rekonstrukceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rekonstruovatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automatickyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NakresOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.NakresSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.ExportSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.drawerShora, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawerZepredu, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.drawerZprava, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pohledDratenehoModelu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(140, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(608, 462);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // drawerShora
            // 
            this.drawerShora.BackColor = System.Drawing.Color.Black;
            this.drawerShora.BarvaKursoru = System.Drawing.Color.LightGreen;
            this.drawerShora.BarvaMrizky = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.drawerShora.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawerShora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawerShora.ForeColor = System.Drawing.Color.White;
            this.drawerShora.Location = new System.Drawing.Point(307, 3);
            this.drawerShora.MeritkoZobrazeni = 10F;
            this.drawerShora.Name = "drawerShora";
            this.drawerShora.Pohled = null;
            this.drawerShora.Posun = new System.Drawing.SizeF(-10.2F, 10.8F);
            this.drawerShora.PrichytavatKeMrizce = true;
            this.drawerShora.PrichytavatKUseckam = false;
            this.drawerShora.RoztecMrizky = new System.Drawing.SizeF(2F, 2F);
            this.drawerShora.Size = new System.Drawing.Size(298, 225);
            this.drawerShora.TabIndex = 0;
            this.drawerShora.TabStop = false;
            this.drawerShora.ZobrazitKrizSouradnic = true;
            this.drawerShora.ZobrazitMrizku = true;
            this.drawerShora.ZobrazitOsy = true;
            this.drawerShora.ZobrazitPomocneCary = false;
            this.drawerShora.MouseLeave += new System.EventHandler(this.drawerZepredu_MouseLeave);
            this.drawerShora.UseckaOdebrana += new System.EventHandler<System.EventArgs>(this.drawer1_UseckaOdebrana);
            this.drawerShora.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawerZleva_MouseMove);
            this.drawerShora.MeritkoZmeneno += new System.EventHandler(this.drawer1_MeritkoZmeneno);
            this.drawerShora.UseckaPridana += new System.EventHandler<RekonstruktorWin.Controls.Drawer.NewLineEventArgs>(this.drawers_UseckaPridana);
            this.drawerShora.PosunZmenen += new System.EventHandler(this.drawer1_PosunZmenen);
            this.drawerShora.MouseEnter += new System.EventHandler(this.drawerZleva_MouseEnter);
            // 
            // drawerZepredu
            // 
            this.drawerZepredu.BackColor = System.Drawing.Color.Black;
            this.drawerZepredu.BarvaKursoru = System.Drawing.Color.LightGreen;
            this.drawerZepredu.BarvaMrizky = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.drawerZepredu.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawerZepredu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawerZepredu.ForeColor = System.Drawing.Color.White;
            this.drawerZepredu.Location = new System.Drawing.Point(307, 234);
            this.drawerZepredu.MeritkoZobrazeni = 10F;
            this.drawerZepredu.Name = "drawerZepredu";
            this.drawerZepredu.Pohled = null;
            this.drawerZepredu.Posun = new System.Drawing.SizeF(-10.2F, 10.8F);
            this.drawerZepredu.PrichytavatKeMrizce = true;
            this.drawerZepredu.PrichytavatKUseckam = false;
            this.drawerZepredu.RoztecMrizky = new System.Drawing.SizeF(2F, 2F);
            this.drawerZepredu.Size = new System.Drawing.Size(298, 225);
            this.drawerZepredu.TabIndex = 1;
            this.drawerZepredu.TabStop = false;
            this.drawerZepredu.ZobrazitKrizSouradnic = true;
            this.drawerZepredu.ZobrazitMrizku = true;
            this.drawerZepredu.ZobrazitOsy = true;
            this.drawerZepredu.ZobrazitPomocneCary = false;
            this.drawerZepredu.MouseLeave += new System.EventHandler(this.drawerZepredu_MouseLeave);
            this.drawerZepredu.UseckaOdebrana += new System.EventHandler<System.EventArgs>(this.drawer1_UseckaOdebrana);
            this.drawerZepredu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawerZleva_MouseMove);
            this.drawerZepredu.MeritkoZmeneno += new System.EventHandler(this.drawer2_MeritkoZmeneno);
            this.drawerZepredu.UseckaPridana += new System.EventHandler<RekonstruktorWin.Controls.Drawer.NewLineEventArgs>(this.drawers_UseckaPridana);
            this.drawerZepredu.PosunZmenen += new System.EventHandler(this.drawer2_PosunZmenen);
            this.drawerZepredu.MouseEnter += new System.EventHandler(this.drawerZleva_MouseEnter);
            // 
            // drawerZprava
            // 
            this.drawerZprava.BackColor = System.Drawing.Color.Black;
            this.drawerZprava.BarvaKursoru = System.Drawing.Color.LightGreen;
            this.drawerZprava.BarvaMrizky = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.drawerZprava.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawerZprava.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawerZprava.ForeColor = System.Drawing.Color.White;
            this.drawerZprava.Location = new System.Drawing.Point(3, 234);
            this.drawerZprava.MeritkoZobrazeni = 10F;
            this.drawerZprava.Name = "drawerZprava";
            this.drawerZprava.Pohled = null;
            this.drawerZprava.Posun = new System.Drawing.SizeF(-10.2F, 10.8F);
            this.drawerZprava.PrichytavatKeMrizce = true;
            this.drawerZprava.PrichytavatKUseckam = false;
            this.drawerZprava.RoztecMrizky = new System.Drawing.SizeF(2F, 2F);
            this.drawerZprava.Size = new System.Drawing.Size(298, 225);
            this.drawerZprava.TabIndex = 2;
            this.drawerZprava.TabStop = false;
            this.drawerZprava.ZobrazitKrizSouradnic = true;
            this.drawerZprava.ZobrazitMrizku = true;
            this.drawerZprava.ZobrazitOsy = true;
            this.drawerZprava.ZobrazitPomocneCary = false;
            this.drawerZprava.MouseLeave += new System.EventHandler(this.drawerZepredu_MouseLeave);
            this.drawerZprava.UseckaOdebrana += new System.EventHandler<System.EventArgs>(this.drawer1_UseckaOdebrana);
            this.drawerZprava.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawerZleva_MouseMove);
            this.drawerZprava.MeritkoZmeneno += new System.EventHandler(this.drawer3_MeritkoZmeneno);
            this.drawerZprava.UseckaPridana += new System.EventHandler<RekonstruktorWin.Controls.Drawer.NewLineEventArgs>(this.drawers_UseckaPridana);
            this.drawerZprava.PosunZmenen += new System.EventHandler(this.drawer3_PosunZmenen);
            this.drawerZprava.MouseEnter += new System.EventHandler(this.drawerZleva_MouseEnter);
            // 
            // pohledDratenehoModelu
            // 
            this.pohledDratenehoModelu.BackColor = System.Drawing.Color.Black;
            this.pohledDratenehoModelu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pohledDratenehoModelu.ForeColor = System.Drawing.Color.White;
            this.pohledDratenehoModelu.HlavniUsecky = new LibRekonstruktor.ProstoroveObjekty.Usecka[0];
            this.pohledDratenehoModelu.Location = new System.Drawing.Point(3, 3);
            this.pohledDratenehoModelu.MeritkoZobrazeni = 10F;
            this.pohledDratenehoModelu.Name = "pohledDratenehoModelu";
            this.pohledDratenehoModelu.PomocneUsecky = new LibRekonstruktor.ProstoroveObjekty.Usecka[0];
            this.pohledDratenehoModelu.PosunZobrazeni = new System.Drawing.SizeF(152F, 148F);
            this.pohledDratenehoModelu.Size = new System.Drawing.Size(298, 225);
            this.pohledDratenehoModelu.TabIndex = 3;
            this.pohledDratenehoModelu.TabStop = false;
            this.pohledDratenehoModelu.ZobrazitKrizOs = true;
            this.pohledDratenehoModelu.MouseLeave += new System.EventHandler(this.drawerZepredu_MouseLeave);
            this.pohledDratenehoModelu.MouseEnter += new System.EventHandler(this.isometricView1_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 462);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxProjection);
            this.groupBox3.Controls.Add(this.checkBoxCross);
            this.groupBox3.Controls.Add(this.checkBoxSnap);
            this.groupBox3.Controls.Add(this.checkBoxStep);
            this.groupBox3.Controls.Add(this.checkBoxGrid);
            this.groupBox3.Location = new System.Drawing.Point(5, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 153);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nastavení pohledů";
            // 
            // checkBoxProjection
            // 
            this.checkBoxProjection.Location = new System.Drawing.Point(6, 111);
            this.checkBoxProjection.Name = "checkBoxProjection";
            this.checkBoxProjection.Size = new System.Drawing.Size(100, 36);
            this.checkBoxProjection.TabIndex = 6;
            this.checkBoxProjection.Text = "Zobrazit vodící čáry";
            this.checkBoxProjection.UseVisualStyleBackColor = true;
            this.checkBoxProjection.CheckedChanged += new System.EventHandler(this.checkBoxProjection_CheckedChanged);
            // 
            // checkBoxCross
            // 
            this.checkBoxCross.AutoSize = true;
            this.checkBoxCross.Checked = true;
            this.checkBoxCross.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCross.Location = new System.Drawing.Point(6, 88);
            this.checkBoxCross.Name = "checkBoxCross";
            this.checkBoxCross.Size = new System.Drawing.Size(84, 17);
            this.checkBoxCross.TabIndex = 5;
            this.checkBoxCross.Text = "Zobrazit kříž";
            this.checkBoxCross.UseVisualStyleBackColor = true;
            this.checkBoxCross.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // checkBoxSnap
            // 
            this.checkBoxSnap.AutoSize = true;
            this.checkBoxSnap.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSnap.Name = "checkBoxSnap";
            this.checkBoxSnap.Size = new System.Drawing.Size(113, 17);
            this.checkBoxSnap.TabIndex = 2;
            this.checkBoxSnap.Text = "Chytat k vrcholům";
            this.checkBoxSnap.UseVisualStyleBackColor = true;
            this.checkBoxSnap.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBoxStep
            // 
            this.checkBoxStep.AutoSize = true;
            this.checkBoxStep.Checked = true;
            this.checkBoxStep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStep.Location = new System.Drawing.Point(6, 42);
            this.checkBoxStep.Name = "checkBoxStep";
            this.checkBoxStep.Size = new System.Drawing.Size(106, 17);
            this.checkBoxStep.TabIndex = 3;
            this.checkBoxStep.Text = "Chytat ke mřížce";
            this.checkBoxStep.UseVisualStyleBackColor = true;
            this.checkBoxStep.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBoxGrid
            // 
            this.checkBoxGrid.AutoSize = true;
            this.checkBoxGrid.Checked = true;
            this.checkBoxGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrid.Location = new System.Drawing.Point(6, 65);
            this.checkBoxGrid.Name = "checkBoxGrid";
            this.checkBoxGrid.Size = new System.Drawing.Size(98, 17);
            this.checkBoxGrid.TabIndex = 4;
            this.checkBoxGrid.Text = "Zobrazit mřížku";
            this.checkBoxGrid.UseVisualStyleBackColor = true;
            this.checkBoxGrid.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rotationControl1);
            this.groupBox2.Location = new System.Drawing.Point(5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 142);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3D rotace";
            // 
            // rotationControl1
            // 
            this.rotationControl1.AutoSize = true;
            this.rotationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rotationControl1.Enabled = false;
            this.rotationControl1.Location = new System.Drawing.Point(21, 19);
            this.rotationControl1.Name = "rotationControl1";
            this.rotationControl1.OvladaneZobrazeni = this.pohledDratenehoModelu;
            this.rotationControl1.Size = new System.Drawing.Size(85, 113);
            this.rotationControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3DCross);
            this.groupBox1.Controls.Add(this.checkBoxVsechnyPrusecnice);
            this.groupBox1.Location = new System.Drawing.Point(5, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nastavení 3D";
            // 
            // checkBox3DCross
            // 
            this.checkBox3DCross.AccessibleDescription = "";
            this.checkBox3DCross.AutoSize = true;
            this.checkBox3DCross.Checked = true;
            this.checkBox3DCross.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3DCross.Location = new System.Drawing.Point(6, 55);
            this.checkBox3DCross.Name = "checkBox3DCross";
            this.checkBox3DCross.Size = new System.Drawing.Size(84, 17);
            this.checkBox3DCross.TabIndex = 1;
            this.checkBox3DCross.Text = "Kříž počátku";
            this.checkBox3DCross.UseVisualStyleBackColor = true;
            this.checkBox3DCross.CheckedChanged += new System.EventHandler(this.checkBox3DCross_CheckedChanged);
            // 
            // checkBoxVsechnyPrusecnice
            // 
            this.checkBoxVsechnyPrusecnice.AccessibleDescription = "";
            this.checkBoxVsechnyPrusecnice.AutoSize = true;
            this.checkBoxVsechnyPrusecnice.Location = new System.Drawing.Point(6, 19);
            this.checkBoxVsechnyPrusecnice.Name = "checkBoxVsechnyPrusecnice";
            this.checkBoxVsechnyPrusecnice.Size = new System.Drawing.Size(77, 30);
            this.checkBoxVsechnyPrusecnice.TabIndex = 0;
            this.checkBoxVsechnyPrusecnice.Text = "Pohledové\r\nprusečnice";
            this.checkBoxVsechnyPrusecnice.UseVisualStyleBackColor = true;
            this.checkBoxVsechnyPrusecnice.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusInfo,
            this.toolStripStatusLabel1,
            this.StatusCoordinates});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(748, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusInfo
            // 
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.Size = new System.Drawing.Size(81, 17);
            this.StatusInfo.Text = "Rekonstruktor";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(615, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // StatusCoordinates
            // 
            this.StatusCoordinates.Name = "StatusCoordinates";
            this.StatusCoordinates.Size = new System.Drawing.Size(37, 17);
            this.StatusCoordinates.Text = "0; 0; 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.nákresToolStripMenuItem,
            this.oProgramuToolStripMenuItem,
            this.rekonstrukceToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.načístToolStripMenuItem,
            this.uložitJakoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportovat3DToolStripMenuItem,
            this.toolStripMenuItem1,
            this.konecToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // načístToolStripMenuItem
            // 
            this.načístToolStripMenuItem.Name = "načístToolStripMenuItem";
            this.načístToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.načístToolStripMenuItem.Text = "Otevřít";
            this.načístToolStripMenuItem.Click += new System.EventHandler(this.načístToolStripMenuItem_Click);
            // 
            // uložitJakoToolStripMenuItem
            // 
            this.uložitJakoToolStripMenuItem.Name = "uložitJakoToolStripMenuItem";
            this.uložitJakoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.uložitJakoToolStripMenuItem.Text = "Uložit jako";
            this.uložitJakoToolStripMenuItem.Click += new System.EventHandler(this.uložitJakoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 6);
            // 
            // exportovat3DToolStripMenuItem
            // 
            this.exportovat3DToolStripMenuItem.Enabled = false;
            this.exportovat3DToolStripMenuItem.Name = "exportovat3DToolStripMenuItem";
            this.exportovat3DToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exportovat3DToolStripMenuItem.Text = "Exportovat 3D";
            this.exportovat3DToolStripMenuItem.Click += new System.EventHandler(this.exportovat3DToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // nákresToolStripMenuItem
            // 
            this.nákresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vyčistitToolStripMenuItem});
            this.nákresToolStripMenuItem.Name = "nákresToolStripMenuItem";
            this.nákresToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.nákresToolStripMenuItem.Text = "Nákres";
            // 
            // vyčistitToolStripMenuItem
            // 
            this.vyčistitToolStripMenuItem.Name = "vyčistitToolStripMenuItem";
            this.vyčistitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.vyčistitToolStripMenuItem.Text = "Vyčistit";
            this.vyčistitToolStripMenuItem.Click += new System.EventHandler(this.vyčistitToolStripMenuItem_Click);
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.oProgramuToolStripMenuItem.Text = "O programu";
            this.oProgramuToolStripMenuItem.Click += new System.EventHandler(this.oProgramuToolStripMenuItem_Click);
            // 
            // rekonstrukceToolStripMenuItem
            // 
            this.rekonstrukceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rekonstruovatToolStripMenuItem1,
            this.filtrovatToolStripMenuItem,
            this.automatickyToolStripMenuItem});
            this.rekonstrukceToolStripMenuItem.Name = "rekonstrukceToolStripMenuItem";
            this.rekonstrukceToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.rekonstrukceToolStripMenuItem.Text = "Rekonstrukce";
            // 
            // rekonstruovatToolStripMenuItem1
            // 
            this.rekonstruovatToolStripMenuItem1.Name = "rekonstruovatToolStripMenuItem1";
            this.rekonstruovatToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.rekonstruovatToolStripMenuItem1.Text = "Rekonstruovat";
            this.rekonstruovatToolStripMenuItem1.Click += new System.EventHandler(this.rekonstruovatToolStripMenuItem1_Click);
            // 
            // filtrovatToolStripMenuItem
            // 
            this.filtrovatToolStripMenuItem.Name = "filtrovatToolStripMenuItem";
            this.filtrovatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filtrovatToolStripMenuItem.Text = "Filtrovat";
            this.filtrovatToolStripMenuItem.ToolTipText = "EXPERIMENTALNI! Použije filtr pro odstraneni prebytecnych hran v dratenem modelu." +
                "";
            this.filtrovatToolStripMenuItem.Click += new System.EventHandler(this.filtrovatToolStripMenuItem_Click);
            // 
            // automatickyToolStripMenuItem
            // 
            this.automatickyToolStripMenuItem.Checked = true;
            this.automatickyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automatickyToolStripMenuItem.Name = "automatickyToolStripMenuItem";
            this.automatickyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.automatickyToolStripMenuItem.Text = "Automaticky";
            this.automatickyToolStripMenuItem.Click += new System.EventHandler(this.automatickyToolStripMenuItem_Click);
            // 
            // NakresOpenDialog
            // 
            this.NakresOpenDialog.DefaultExt = "nakres";
            this.NakresOpenDialog.Filter = "Soubory nákresu|*.nakres";
            this.NakresOpenDialog.Title = "Otevřít nákres";
            // 
            // NakresSaveDialog
            // 
            this.NakresSaveDialog.DefaultExt = "nakres";
            this.NakresSaveDialog.Filter = "Soubory nákresu|*.nakres";
            this.NakresSaveDialog.Title = "Uložit nákres";
            // 
            // ExportSaveDialog
            // 
            this.ExportSaveDialog.DefaultExt = "drat";
            this.ExportSaveDialog.Filter = "Soubory drátěného modelu|*.drat";
            this.ExportSaveDialog.Title = "Exportovat model";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = global::RekonstruktorWin.Properties.Resources.OOCL2;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Rekonstruktor pravoúhlého promítání";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RekonstruktorWin.Controls.Drawer drawerShora;
        private RekonstruktorWin.Controls.Drawer drawerZepredu;
        private RekonstruktorWin.Controls.Drawer drawerZprava;
        private RekonstruktorWin.Components.IsometricView pohledDratenehoModelu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxVsechnyPrusecnice;
        private System.Windows.Forms.CheckBox checkBoxStep;
        private System.Windows.Forms.CheckBox checkBoxGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoordinates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxSnap;
        private System.Windows.Forms.GroupBox groupBox2;
        private RekonstruktorWin.Controls.RotationControl rotationControl1;
        private System.Windows.Forms.ToolStripStatusLabel StatusInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxCross;
        private System.Windows.Forms.CheckBox checkBox3DCross;
        private System.Windows.Forms.CheckBox checkBoxProjection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem načístToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportovat3DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nákresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vyčistitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog NakresOpenDialog;
        private System.Windows.Forms.SaveFileDialog NakresSaveDialog;
        private System.Windows.Forms.ToolStripMenuItem uložitJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.SaveFileDialog ExportSaveDialog;
        private System.Windows.Forms.ToolStripMenuItem rekonstrukceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rekonstruovatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filtrovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automatickyToolStripMenuItem;

    }
}

