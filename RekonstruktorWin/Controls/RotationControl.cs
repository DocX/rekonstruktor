using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RekonstruktorWin.Components;

namespace RekonstruktorWin.Controls
{
    public partial class RotationControl : UserControl
    {
        public RotationControl()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        enum Smer
        {
            Minus,
            Plus
        }

        const float delta = 0.2f;

        IsometricView zobrazeni;

        public IsometricView OvladaneZobrazeni
        {
            get { return zobrazeni; }
            set { zobrazeni = value; Enabled = zobrazeni != null; }
        }

        float deltaX, deltaY, deltaZ;

        void stop()
        {
            timer.Enabled = false;
            deltaX = deltaY = deltaZ = 0;
        }

        void start(ref float var, Smer smer)
        {
            deltaX = deltaY = deltaZ = 0;
            switch (smer)
            {
                case Smer.Minus:
                    var = -delta;
                    break;
                case Smer.Plus:
                    var = delta;
                    break;
                default:
                    break;
            }
            timer.Enabled = true;
        }

        private void buttonXminus_MouseDown(object sender, MouseEventArgs e)
        {
            start(ref deltaX, Smer.Minus);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemX(deltaX);
            zobrazeni.RotovatKolemY(deltaY);
            zobrazeni.RotovatKolemZ(deltaZ);
        }

        private void buttonXminus_MouseUp(object sender, MouseEventArgs e)
        {
            stop();
        }

        private void buttonXplus_MouseDown(object sender, MouseEventArgs e)
        {
            start(ref deltaX, Smer.Plus);
        }

        private void buttonYminus_MouseDown(object sender, MouseEventArgs e)
        {
            start(ref deltaY, Smer.Minus);
        }

        private void buttonZminus_MouseDown(object sender, MouseEventArgs e)
        {
            start(ref deltaZ, Smer.Minus);
        }

        private void buttonYplus_MouseDown(object sender, MouseEventArgs e)
        {
            start(ref deltaY, Smer.Plus);
        }

        private void buttonZplus_MouseDown(object sender, MouseEventArgs e)
        {
            start(ref deltaZ, Smer.Plus);
        }

        private void buttonXminus_Click(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemX(-delta);
        }

        private void buttonXplus_Click(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemX(delta);
        }

        private void buttonYminus_Click(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemY(-delta);
        }

        private void buttonZminus_Click(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemZ(-delta);
        }

        private void buttonYplus_Click(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemY(delta);
        }

        private void buttonZplus_Click(object sender, EventArgs e)
        {
            zobrazeni.RotovatKolemZ(delta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPredvolene.Show(sender as Control, new Point(0, 0), ToolStripDropDownDirection.BelowRight);
        }

        private void sEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.SE);
        }

        private void sWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.SW);
        }

        private void nEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.NE);
        }

        private void nWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.NW);
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.Top);
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.Bottom);
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.Left);
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.Right);
        }

        private void frontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.Front);
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zobrazeni.NastavitPohled(IsometricView.Pohledy.Back);
        }

    }
}
