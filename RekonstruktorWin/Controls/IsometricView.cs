using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibRekonstruktor.ProstoroveObjekty;
using System.Drawing.Drawing2D;
using LibRekonstruktor.Algebra;

namespace RekonstruktorWin.Components
{
    public partial class IsometricView : UserControl
    {
        public IsometricView()
        {
            InitializeComponent();

            usecky = new Usecka[0];
            pomocne = new Usecka[0];

            meritko = 10f;

            maticeTransformace = new Matice(2, 3);
            resetovatMaticiTransformace();

            osaXpen = new Pen(Color.Red, 2.5f);
            osaYpen = new Pen(Color.Green, 2.5f);
            osaZpen = new Pen(Color.Blue, 2.5f);

            zobrazitKrizOs = true;

            Centrovat();
        }

        #region Vlastnosti

        Usecka[] usecky, pomocne;

        /// <summary>
        /// Odkaz na seznam hlavnich usecek vykreslenych barvou popredi
        /// </summary>
        public Usecka[] HlavniUsecky
        {
            get { return usecky; }
            set { if (value == null) throw new ArgumentNullException(); usecky = value; Invalidate(); }
        }

        /// <summary>
        /// Odkaz na seznam pomocnych usecek, vykreslenych tenkou carou
        /// </summary>
        public Usecka[] PomocneUsecky
        {
            get { return pomocne; }
            set { if (value == null) throw new ArgumentNullException(); pomocne = value; Invalidate(); }
        }

        SizeF posun;
        /// <summary>
        /// Posun horniho leveho rohu zobrazovane oblasti (v pixelech)
        /// </summary>
        public SizeF PosunZobrazeni
        {
            get { return posun; }
            set { posun = value; Invalidate(); }
        }

        float meritko;
        /// <summary>
        /// Meritko zobrazeni objektu
        /// </summary>
        public float MeritkoZobrazeni
        {
            get { return meritko; }
            set { if (value <= 0) throw new ArgumentException(); meritko = value; Invalidate(); }
        }

        Pen osaXpen, osaYpen, osaZpen;
        public Pen PeroOsyX
        {
            get { return osaXpen; }
            set { if (value == null) throw new ArgumentNullException(); osaXpen = value; Invalidate(); }
        }

        public Pen PeroOsyY
        {
            get { return osaYpen; }
            set { if (value == null) throw new ArgumentNullException(); osaYpen = value; Invalidate(); }
        }

        public Pen PeroOsyZ
        {
            get { return osaZpen; }
            set { if (value == null) throw new ArgumentNullException(); osaZpen = value; Invalidate(); }
        }

        bool zobrazitKrizOs;
        public bool ZobrazitKrizOs
        {
            get { return zobrazitKrizOs; }
            set { zobrazitKrizOs = value; Invalidate(); }
        }


        /// <summary>
        /// Instance matice zobrazeni typu 2x3. Sloupce jsou (X,Y,Z) radky (X,Y)
        /// </summary>
        public Matice MaticeTransformace
        {
            get { return maticeTransformace; }
        }

        #endregion

        #region Isometricke zobrazeni

        #region Matice zobrazeni
        const float tm11 = 0.70710678118654752440084436210485f;
        const float tm12 = 0.70710678118654752440084436210485f;
        const float tm13 = 0f;
        const float tm21 = 0.40824829046386301636621401245098f;
        const float tm22 = -0.40824829046386301636621401245098f;
        const float tm23 = -0.81649658092772603273242802490196f;
        #endregion

        PointF zobrazit(Bod b)
        {
            Bod zobrazeny = maticeTransformace * b;
            PointF bod = new PointF();
            bod.X = zobrazeny.X * meritko;
            bod.Y = zobrazeny.Y * meritko;
            bod = bod + posun;
            return bod;
        }

        /// <summary>
        /// Zobrazi uscku z prostoru na plochu pomoci isometrickeho zobrazeni
        /// </summary>
        /// <param name="u">Zobrazena usecka</param>
        /// <param name="a">Prvni krajni bod obrazu usecky</param>
        /// <param name="b">Druhy krajni bod obrazu usecky</param>
        void zobrazit(Usecka u, ref PointF a, ref PointF b)
        {
            a = zobrazit(u.A);
            b = zobrazit(u.B);
        }

        #region Rotace

        Matice maticeTransformace;

        /// <summary>
        /// Rotovat objekt kolem soucasne osy X
        /// </summary>
        /// <param name="angle">Uhel rotace v radianech</param>
        public void RotovatKolemX(float angle)
        {
            Matice r = new Matice(3, 3);
            r[0, 0] = 1f; r[1, 0] = 0f; r[2, 0] = 0f;
            r[0, 1] = 0f; r[1, 1] = (float)Math.Cos(angle); r[2, 1] = (float)Math.Sin(angle);
            r[0, 2] = 0f; r[1, 2] = (float)-Math.Sin(angle); r[2, 2] = (float)Math.Cos(angle);

            maticeTransformace = maticeTransformace * r;
            Invalidate();
        }

        /// <summary>
        /// Rotovat objekt kolem soucasne osy Y
        /// </summary>
        /// <param name="angle">Uhel rotace v radianech</param>
        public void RotovatKolemY(float angle)
        {
            Matice r = new Matice(3, 3);
            r[0, 0] = (float)Math.Cos(angle); r[1, 0] = 0f; r[2, 0] = -(float)Math.Sin(angle);
            r[0, 1] = 0f; r[1, 1] = 1f; r[2, 1] = 0f;
            r[0, 2] = (float)Math.Sin(angle); r[1, 2] = 0f; r[2, 2] = (float)Math.Cos(angle);

            maticeTransformace = maticeTransformace * r;
            Invalidate();
        }

        /// <summary>
        /// Rotovat objekt kolem soucasne osy Z
        /// </summary>
        /// <param name="angle">Uhel rotace v radianech</param>
        public void RotovatKolemZ(float angle)
        {
            Matice r = new Matice(3, 3);
            r[0, 0] = (float)Math.Cos(angle); r[1, 0] = (float)Math.Sin(angle); r[2, 0] = 0f;
            r[0, 1] = -(float)Math.Sin(angle); r[1, 1] = (float)Math.Cos(angle); r[2, 1] = 0f;
            r[0, 2] = 0f; r[1, 2] = 0f; r[2, 2] = 1f;

            maticeTransformace = maticeTransformace * r;
            Invalidate();
        }

        private void resetovatMaticiTransformace()
        {
            maticeTransformace[0, 0] = tm11;
            maticeTransformace[0, 1] = tm12;
            maticeTransformace[0, 2] = tm13;
            maticeTransformace[1, 0] = tm21;
            maticeTransformace[1, 1] = tm22;
            maticeTransformace[1, 2] = tm23;
        }

        #endregion

        #region Standartni pohledy
        
        /// <summary>
        /// Preddefionvane pohledy
        /// </summary>
        public enum Pohledy
        {
            SE,
            SW,
            NE,
            NW,
            Top,
            Bottom,
            Left,
            Right,
            Front,
            Back
        }

        /// <summary>
        /// Nastavi standartni pohled
        /// </summary>
        /// <param name="pohled">Typ pohledu</param>
        public void NastavitPohled(Pohledy pohled)
        {
            switch (pohled)
            {
                case Pohledy.SE:
                    resetovatMaticiTransformace();
                    break;
                case Pohledy.SW:
                    resetovatMaticiTransformace();
                    RotovatKolemZ((float)(Math.PI / 2));
                    break;
                case Pohledy.NE:
                    resetovatMaticiTransformace();
                    RotovatKolemZ(-(float)(Math.PI / 2)); break;
                case Pohledy.NW:
                    resetovatMaticiTransformace();
                    RotovatKolemZ((float)(Math.PI )); break;
                case Pohledy.Top:
                    MaticeTransformace[0, 0] = 1;
                    MaticeTransformace[0, 1] = 0;
                    MaticeTransformace[0, 2] = 0;
                    MaticeTransformace[1, 0] = 0;
                    MaticeTransformace[1, 1] = -1;
                    MaticeTransformace[1, 2] = 0;
                    break;
                case Pohledy.Bottom:
                    MaticeTransformace[0, 0] = 1;
                    MaticeTransformace[0, 1] = 0;
                    MaticeTransformace[0, 2] = 0;
                    MaticeTransformace[1, 0] = 0;
                    MaticeTransformace[1, 1] = 1;
                    MaticeTransformace[1, 2] = 0;
                    break;
                case Pohledy.Left:
                    MaticeTransformace[0, 0] = 0;
                    MaticeTransformace[0, 1] = -1;
                    MaticeTransformace[0, 2] = 0;
                    MaticeTransformace[1, 0] = 0;
                    MaticeTransformace[1, 1] = 0;
                    MaticeTransformace[1, 2] = -1;
                    break;
                case Pohledy.Right:
                    MaticeTransformace[0, 0] = 0;
                    MaticeTransformace[0, 1] = 1;
                    MaticeTransformace[0, 2] = 0;
                    MaticeTransformace[1, 0] = 0;
                    MaticeTransformace[1, 1] = 0;
                    MaticeTransformace[1, 2] = -1;
                    break;
                case Pohledy.Front:
                    MaticeTransformace[0, 0] = 1;
                    MaticeTransformace[0, 1] = 0;
                    MaticeTransformace[0, 2] = 0;
                    MaticeTransformace[1, 0] = 0;
                    MaticeTransformace[1, 1] = 0;
                    MaticeTransformace[1, 2] = -1;
                    break;
                case Pohledy.Back:
                    MaticeTransformace[0, 0] = -1;
                    MaticeTransformace[0, 1] = 0;
                    MaticeTransformace[0, 2] = 0;
                    MaticeTransformace[1, 0] = 0;
                    MaticeTransformace[1, 1] = 0;
                    MaticeTransformace[1, 2] = -1;
                    break;
            }
            Invalidate();
        }

        #endregion

        #endregion

        #region Vykresleni

        public void Centrovat()
        {
            posun.Width = this.ClientSize.Width / 2;
            posun.Height = this.ClientSize.Height / 2;
            Invalidate();
        }
        
        void Vykreslit(Graphics g)
        {
            g.Clear(BackColor);

            g.SmoothingMode = SmoothingMode.HighQuality;

            PointF a = new PointF();
            PointF b = new PointF();



            #region Vedlejsi hrany
            Pen pen = new Pen(Color.LightGray);
            pen.Color = Color.LightGray;
            pen.DashStyle = DashStyle.DashDot;
            pen.Width = 0.5f;

            foreach (var usecka in pomocne)
            {
                zobrazit(usecka, ref a, ref b);

                g.DrawLine(pen, a, b);
            }

            #endregion

            #region Hlavni hrany drateneho modelu
            pen = new Pen(ForeColor, 2f);

            foreach (var usecka in usecky)
            {
                zobrazit(usecka, ref a, ref b);
                g.DrawLine(pen, a, b);
            }
            #endregion

            #region Kriz os

            if (zobrazitKrizOs)
            {
                float oldMeritko = meritko;
                meritko = 1;

                zobrazit(new Usecka(new Bod(0, 0, 0), new Bod(30, 0, 0)), ref a, ref b);
                g.DrawLine(osaXpen, a, b);

                zobrazit(new Usecka(new Bod(0, 0, 0), new Bod(0, 30, 0)), ref a, ref b);
                g.DrawLine(osaYpen, a, b);

                zobrazit(new Usecka(new Bod(0, 0, 0), new Bod(0, 0, 30)), ref a, ref b);
                g.DrawLine(osaZpen, a, b);

                meritko = oldMeritko;
            }

            #endregion
        }

        #endregion

        #region Obsluha vnejsich udalosti

        private PointF predchoziMys;

        private void IsometricView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                predchoziMys = e.Location;
            }
        }

        private void IsometricView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
            {
                this.posun.Height += (float)(e.Y - predchoziMys.Y) ;
                this.posun.Width += (float)(e.X - predchoziMys.X);
                predchoziMys = e.Location;
                this.Invalidate();
            }
            else if ((e.Button & MouseButtons.Right) == MouseButtons.Right && (e.Button & MouseButtons.Left) == MouseButtons.Left )
            {
                RotovatKolemZ(-(float)(e.X - predchoziMys.X) / 40f );
                predchoziMys = e.Location;
                this.Invalidate();
            }
            else if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                RotovatKolemY((float)(e.Y - predchoziMys.Y) / 40f);
                predchoziMys = e.Location;
                this.Invalidate();
            }
            else if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                RotovatKolemX(-(float)(e.Y - predchoziMys.Y) / 40f);
                predchoziMys = e.Location;
                this.Invalidate();
            }
        }

        void IsometricView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                this.meritko *= (float)Math.Pow(0.9, Math.Sign((double)(e.Delta)));
                this.Invalidate();
            }
        }

        private void IsometricView_Paint(object sender, PaintEventArgs e)
        {
            Vykreslit(e.Graphics);
        }
        #endregion

        private void IsometricView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                ResetovatPohled();
            }
        }

        public void ResetovatPohled()
        {
            meritko = 10f;
            Centrovat();
            Invalidate();
        }
    }
}
