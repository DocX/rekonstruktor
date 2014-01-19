using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibRekonstruktor.ProstoroveObjekty;
using LibRekonstruktor;

namespace RekonstruktorWin.Controls
{
    public partial class Drawer : UserControl
    {
        #region Inicializace

        public Drawer()
        {
            InitializeComponent();

            pohled = null;

            kurzor = PointF.Empty;
            zobrazitKurzor = true;

            meritko = 10;
            vycentrovatPohled();

            zobrazitMrizku = zobrazitOsy = true;
            roztecMrizky = new SizeF(2f, 2f);

            barvaMrizky = Color.FromKnownColor(KnownColor.ControlDark);
            barvaKurzoru = Color.FromKnownColor(KnownColor.ActiveCaptionText);

            zobrazitPomocneCary = false;

            pomocneCary = new Dictionary<string, IEnumerable<UseckaBase>>();

        }

        public Drawer(Pohled pohled)
            : this()
        {
            if (pohled == null)
                throw new ArgumentNullException();

            this.pohled = pohled;
        }

        #endregion

        #region Events

        #region Deklarace
        /// <summary>
        /// Trida pro argumenty udalosti pridani nove usecky do pohledu
        /// </summary>
        public class NewLineEventArgs : EventArgs
        {
            private Usecka usecka;
            private Pohled pohled;

            public NewLineEventArgs(Usecka newLine, Pohled view)
                : base()
            {
                if (newLine == null || view == null)
                    throw new ArgumentNullException();

                usecka = newLine;
                pohled = view;
            }

            /// <summary>
            /// Pohled ve kterem byla nova usecka vytvorena
            /// </summary>
            public Pohled View
            {
                get { return pohled; }
            }

            /// <summary>
            /// Odkaz na nove vytvorenou usecku (zmena se projevy i v pohledu)
            /// </summary>
            public Usecka NewLineReference
            {
                get { return usecka; }
            }
        }

        public event EventHandler PosunZmenen;

        public event EventHandler MeritkoZmeneno;

        public event EventHandler<NewLineEventArgs> UseckaPridana;

        public event EventHandler<EventArgs> UseckaOdebrana;

        #endregion

        protected virtual void OnPosunZmenen(EventArgs e)
        {
            if (PosunZmenen != null)
                PosunZmenen(this, e);
        }

        protected virtual void OnMeritkoZmeneno(EventArgs e)
        {
            if (MeritkoZmeneno != null)
                MeritkoZmeneno(this, e);
        }

        protected virtual void OnUseckaPridana(NewLineEventArgs e)
        {
            if (UseckaPridana != null)
                UseckaPridana(this, e);
        }

        protected virtual void OnUseckaOdebrana(EventArgs e)
        {
            if (UseckaOdebrana != null)
                UseckaOdebrana(this, e);
        }


        #endregion

        #region Vlastnosti

        bool prichytavatKeMrizce = true;
        public bool PrichytavatKeMrizce
        {
            get { return prichytavatKeMrizce; }
            set { prichytavatKeMrizce = value; }
        }

        bool prichytavatKUseckam = false;
        public bool PrichytavatKUseckam
        {
            get { return prichytavatKUseckam; }
            set { prichytavatKUseckam = value; }
        }

        /// <summary>
        /// Souradnice kurzoru v pohledu
        /// </summary>
        PointF kurzor;

        /// <summary>
        /// Souradnice kurzoru v rovine pohledu
        /// </summary>
        public Bod SouradniceKurzoru
        {
            get { return pohled.NaBodVProstoru(new Bod(kurzor.X, kurzor.Y, 0)); }
        }

        private Dictionary<string, IEnumerable<UseckaBase>> pomocneCary;

        /// <summary>
        /// Pristup k seznamu pomocnych usecek
        /// </summary>
        public Dictionary<string, IEnumerable<UseckaBase>> PomocneCary
        {
            get { return pomocneCary; }
        }


        /// <summary>
        /// Aktualne zobrazovany vyrez v pohledu (v jednotkach pohledu)
        /// </summary>
        public RectangleF ZobrazenaOblast
        {
            get
            {
                RectangleF r = new RectangleF();
                r.Size = new SizeF(ClientSize.Width / meritko, -ClientSize.Height / meritko);
                r.Location = new PointF(posun.Width, posun.Height);
                return r;
            }
        }
        private Pohled pohled;

        /// <summary>
        /// Instance zobrazovaneho pohledu
        /// </summary>
        public Pohled Pohled
        {
            get { return this.pohled; }
            set
            {
                this.pohled = value;
                this.Invalidate();
            }

        }


        private SizeF posun;

        /// <summary>
        /// Posun pocatku souradneho systemu
        /// </summary>
        public SizeF Posun
        {
            get { return this.posun; }
            set { this.posun = value; this.Invalidate(); OnPosunZmenen(EventArgs.Empty); }
        }


        private float meritko;

        /// <summary>
        /// Meritko pixelu/jednotku pohledu
        /// </summary>
        public float MeritkoZobrazeni
        {
            get
            {
                return this.meritko;
            }
            set
            {
                if (value <= 0)
                    throw new Exception();

                this.meritko = value;
                this.Invalidate();
                OnMeritkoZmeneno(EventArgs.Empty);
            }
        }


        private SizeF roztecMrizky;

        /// <summary>
        /// Roztec mrizky v jednotlivych smerech (v jednotkach pohledu)
        /// </summary>
        public SizeF RoztecMrizky
        {
            get { return this.roztecMrizky; }
            set { this.roztecMrizky = value; Invalidate(); }
        }


        private bool zobrazitKurzor;

        private bool zobrazitMrizku;

        /// <summary>
        /// Zda se ma zobrazovat mrizka souradneho systemu
        /// </summary>
        public Boolean ZobrazitMrizku
        {
            get { return zobrazitMrizku; }
            set { zobrazitMrizku = value; Invalidate(); }
        }

        private bool zobrazitSouradnyKriz;

        /// <summary>
        /// Zda se ma kriz pocatku souradneho systemu
        /// </summary>
        public Boolean ZobrazitKrizSouradnic
        {
            get { return zobrazitSouradnyKriz; }
            set { zobrazitSouradnyKriz = value; Invalidate(); }
        }

        private bool zobrazitOsy;
        public Boolean ZobrazitOsy
        {
            get { return zobrazitOsy; }
            set { zobrazitOsy = value; Invalidate(); }
        }


        private Color barvaKurzoru;
        public Color BarvaKursoru
        {
            get { return barvaKurzoru; }
            set { barvaKurzoru = value; Invalidate(); }
        }

        private Color barvaMrizky;
        public Color BarvaMrizky
        {
            get { return barvaMrizky; }
            set { barvaMrizky = value; Invalidate(); }
        }

        bool zobrazitPomocneCary;
        /// <summary>
        /// Promitnout usecky z pripojenych pohledu a zobrazit pomocne primky
        /// </summary>
        public bool ZobrazitPomocneCary
        {
            get { return zobrazitPomocneCary; }
            set { zobrazitPomocneCary = value; Invalidate(); }
        }

        public Usecka UseckaPodKurzorem
        {
            get { return useckaPodKurzorem; }
        }

        #endregion

        #region Geometrie a transformace

        private void vycentrovatPohled()
        {
            posun = new SizeF(-ClientSize.Width / (2 * meritko), ClientSize.Height / (2 * meritko));
        }

        public void ResetPohledu()
        {
            MeritkoZobrazeni = 10;
            vycentrovatPohled();
            OnPosunZmenen(EventArgs.Empty);

            Invalidate();
        }

        /// <summary>
        /// Prepocita souradnice bodu v pohledu na bod na platne
        /// </summary>
        /// <param name="x">X-souradnice bodu v pohledu</param>
        /// <param name="y">Y-souradnice bodu v pohledu</param>
        /// <returns>Bod na platne</returns>
        private PointF SouradnicePlatna(float x, float y)
        {
            return new PointF(
                (x - posun.Width) * meritko,
                (posun.Height - y) * meritko
                );
        }

        /// <summary>
        /// Prepocita souradnici z vykreslovane plochy na souradnice v pohledu
        /// </summary>
        /// <param name="x">X-souradnice bodu na platne</param>
        /// <param name="y">Y-souradnice bodu na platne</param>
        /// <returns>Bod v pohledu</returns>
        private PointF SouradnicePohledu(float x, float y)
        {
            return new PointF(
                (x / meritko) + posun.Width,
                -(y / meritko) + posun.Height
                );
        }

        private PointF SouradnicePlatna(Bod bod)
        {
            return SouradnicePlatna((float)bod.X, (float)bod.Y);
        }

        private PointF PoziceKurzoru(float x, float y)
        {
            PointF s = SouradnicePohledu(x, y);

            if (prichytavatKUseckam)
            {
                Bod bodS = new Bod(s.X, s.Y, 0);
                foreach (var usecka in this.pohled.Usecky)
                {
                    if ((usecka.A - bodS).Delka < 1.5f)
                    {
                        s.X = usecka.A.X;
                        s.Y = usecka.A.Y;
                        return s;
                    }
                    if ((usecka.B - bodS).Delka < 1.5f)
                    {
                        s.X = usecka.B.X;
                        s.Y = usecka.B.Y;
                        return s;
                    }
                }
            }

            // prichytit k mrizce
            if (prichytavatKeMrizce)
            {
                s.X = (float)Math.Round(s.X / roztecMrizky.Width) * roztecMrizky.Width;
                s.Y = (float)Math.Round(s.Y / roztecMrizky.Height) * roztecMrizky.Height;
            }
            return s;
        }

        private Usecka zjistitUseckuPodKurzorem(PointF kurzor)
        {
            if (pohled == null)
                return null;

            Bod kurzorBod = new Bod(kurzor.X, kurzor.Y, 0);
            float tolerance = (float)Math.Sqrt(roztecMrizky.Height * roztecMrizky.Height + roztecMrizky.Width * roztecMrizky.Width) / 3;

            foreach (Usecka usecka in pohled.Usecky)
            {
                if (usecka.LeziNaUsecce(kurzorBod, tolerance))
                    return usecka;
            }

            return null;

        }

        #endregion

        #region Vykresleni

        /// <summary>
        /// Vykresli plochu draweru
        /// </summary>
        /// <param name="g"></param>
        void Vykreslit(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            g.Clear(this.BackColor);

            // kopie zobrazovane oblasti
            RectangleF oblast = this.ZobrazenaOblast;

            #region vykresleni mrizky
            if (zobrazitMrizku)
            {
                Pen mrizkaPen = new Pen(barvaMrizky, 1f);

                // vertikalni
                for (
                    float i = (float)Math.Ceiling((double)oblast.Left / roztecMrizky.Width) * roztecMrizky.Width;
                    i <= oblast.Right;
                    i += roztecMrizky.Width)
                {
                    g.DrawLine(
                        mrizkaPen,
                        SouradnicePlatna(i, oblast.Top),
                        SouradnicePlatna(i, oblast.Bottom));

                }
                // horizontalni
                for (
                    float i = (float)Math.Ceiling((double)oblast.Bottom / roztecMrizky.Height) * roztecMrizky.Height;
                    i <= oblast.Top;
                    i += roztecMrizky.Height)
                {
                    g.DrawLine(
                        mrizkaPen,
                        SouradnicePlatna(oblast.Left, i),
                        SouradnicePlatna(oblast.Right, i));
                }

            }
            #endregion

            #region Vykresleni os
            if (zobrazitOsy)
            {
                Pen osaPen = new Pen(barvaMrizky, 2f);

                // horizontalni
                if (oblast.Bottom <= 0 && 0 <= oblast.Top)
                    g.DrawLine(
                        osaPen,
                        SouradnicePlatna(oblast.Left, 0),
                        SouradnicePlatna(oblast.Right, 0));

                // vertikalni
                if (oblast.Left <= 0 && 0 <= oblast.Right)
                    g.DrawLine(
                        osaPen,
                        SouradnicePlatna(0, oblast.Top),
                        SouradnicePlatna(0, oblast.Bottom));

            }
            #endregion

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            #region Vykresleni krizeni systemu souradnic

            if (pohled != null && zobrazitSouradnyKriz)
            {
                SizeF oldPosun = posun;
                float oldMeritko = meritko;
                float velikost = 20;
                if (!(oblast.Bottom < 0 && 0 < oblast.Top && oblast.Left < 0 && 0 < oblast.Right))
                {
                    posun.Height = ClientSize.Height - 30;
                    posun.Width = -30;
                    meritko = 1f;
                }
                else
                {
                    velikost = 20 / meritko;
                }

                VykreslitUsecku(g, new Pen(Color.Red, 2f), pohled.PromitnoutNaRovinuPohledu(new Usecka(0, 0, 0, velikost, 0, 0)));
                VykreslitUsecku(g, new Pen(Color.Green, 2f), pohled.PromitnoutNaRovinuPohledu(new Usecka(0, 0, 0, 0, velikost, 0)));
                VykreslitUsecku(g, new Pen(Color.Blue, 2f), pohled.PromitnoutNaRovinuPohledu(new Usecka(0, 0, 0, 0, 0, velikost)));

                posun = oldPosun; meritko = oldMeritko;
            }


            #endregion

            #region vykreslit pomocne primky, definovane ostatnimi pohledy
            if (zobrazitPomocneCary)
            {
                Pen pen = new Pen(barvaKurzoru, 1f);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                foreach (var sadaCar in pomocneCary)
                {
                    foreach (var cara in sadaCar.Value)
                    {
                        if (cara is Usecka)
                        {
                            VykreslitUsecku(g, pen, cara);
                        }
                        else if (cara is Primka)
                        {
                            VykreslitPrimku(g, pen, oblast, cara);
                        }
                    }
                }
            }
            #endregion

            #region vykreslit usecky pohledu
            Pen useckyPen = new Pen(this.ForeColor, 2f);
            Pen useckaKurPen = new Pen(barvaKurzoru, 2.5f);
            if (this.pohled != null)
            {
                foreach (Usecka usecka in pohled.Usecky)
                {
                    VykreslitUsecku(g,(usecka ==useckaPodKurzorem) ? useckaKurPen : useckyPen, usecka);
                }
            }
            #endregion

            #region vykresleni tvorene usecky
            if (kreslenaUsecka != null)
            {
                VykreslitUsecku(g, useckaKurPen, kreslenaUsecka);
            }
            #endregion

            #region vykresleni kurzoru
            if (zobrazitKurzor && isActive)
            {
                PointF kursorPlatno = SouradnicePlatna(kurzor.X, kurzor.Y);
                g.FillEllipse(new SolidBrush(barvaKurzoru),
                    kursorPlatno.X - 2.5f, kursorPlatno.Y - 2.5f,
                    5f, 5f);
            }
            #endregion

        }

        /// <summary>
        /// Vykresli primku zobrazenou pres celou oblast, urcenou useckou
        /// </summary>
        /// <param name="g">Vykreslovaci platno</param>
        /// <param name="pen">Pero</param>
        /// <param name="oblast">Oblast pres kterou se primka protne</param>
        /// <param name="primka">Usecka urcujici primku</param>
        void VykreslitPrimku(Graphics g, Pen pen, RectangleF oblast, UseckaBase primka)
        {
            PointF A, B;
            if (primka.Smernice.X != 0)
            {
                A = SouradnicePlatna(oblast.Left, primka.A.Y + ((primka.A.X - oblast.Left) / primka.Smernice.X) * primka.Smernice.Y);
                B = SouradnicePlatna(oblast.Right, primka.A.Y + ((primka.A.X - oblast.Right) / primka.Smernice.X) * primka.Smernice.Y);
            }
            else
            {
                A = SouradnicePlatna(primka.A.X + ((primka.A.Y - oblast.Top) / primka.Smernice.Y) * primka.Smernice.X, oblast.Top);
                B = SouradnicePlatna(primka.A.X + ((primka.A.Y - oblast.Bottom) / primka.Smernice.Y) * primka.Smernice.X, oblast.Bottom);
            }

            g.DrawLine(pen, A, B);
        }

        void VykreslitUsecku(Graphics g, Pen pen, UseckaBase u)
        {
            g.DrawLine(
                pen,
                SouradnicePlatna(u.A),
                SouradnicePlatna(u.B));
        }

        #endregion

        #region Obsluha vnejsich udalosti

        /// <summary>
        /// Zda je drawer aktivni a ma se zobrazovat kurzor mysi
        /// </summary>
        bool isActive;

        Point predchoziMys;

        /// <summary>
        /// Kopie prave kreslene usecky
        /// </summary>
        Usecka kreslenaUsecka;

        /// <summary>
        /// Reference na usecku, ktera je aktualne pod kurzorem
        /// </summary>
        Usecka useckaPodKurzorem;

        private void Drawer_Paint(object sender, PaintEventArgs e)
        {
            Vykreslit(e.Graphics);
        }

        void Drawer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                PointF byloPodMysi = SouradnicePohledu(e.X, e.Y);
                this.meritko *= (float)Math.Pow(0.9, Math.Sign((double)(e.Delta)));
                PointF podMysi = SouradnicePohledu(e.X, e.Y);
                posun.Height += byloPodMysi.Y - podMysi.Y;
                posun.Width += byloPodMysi.X - podMysi.X;

                OnPosunZmenen(EventArgs.Empty);
                OnMeritkoZmeneno(EventArgs.Empty);

                kurzor = PoziceKurzoru(e.X, e.Y);
                this.Invalidate();
            }
        }

        private void Drawer_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
            {
                predchoziMys = e.Location;
                Cursor = Cursors.SizeAll;
            }

            if (pohled != null && e.Button == MouseButtons.Left)
            {
                PointF bodPohledu = PoziceKurzoru(e.X, e.Y);
                if (kreslenaUsecka == null)
                {
                    kreslenaUsecka = new Usecka();
                    kreslenaUsecka.A.Nastav(bodPohledu.X, bodPohledu.Y, 0);
                }
                else
                {
                    kreslenaUsecka.B.Nastav(bodPohledu.X, bodPohledu.Y, 0);
                    if (!kreslenaUsecka.Smernice.JeNulovy)
                    {
                        pohled.Usecky.AddLast(kreslenaUsecka);
                        OnUseckaPridana(new NewLineEventArgs(kreslenaUsecka, pohled));
                    }
                    kreslenaUsecka = null;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (kreslenaUsecka == null && useckaPodKurzorem != null)
                {
                    // zobrazit menu usecky
                    menuLineName.Text = String.Format("[{0}; {1}] - [{2}; {3}]", useckaPodKurzorem.A.X.ToString("F2"), useckaPodKurzorem.A.Y.ToString("F2"), useckaPodKurzorem.B.X.ToString("F2"), useckaPodKurzorem.B.Y.ToString("F2"));
                    contextMenuLine.Show(this, e.Location);
                }
                else if (kreslenaUsecka != null)
                {
                    kreslenaUsecka = null;
                }
            }

        }

        private void Drawer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Focus();
            isActive = true;

            if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
            {
                this.posun.Height -= (float)(predchoziMys.Y - e.Y) / meritko;
                this.posun.Width += (float)(predchoziMys.X - e.X) / meritko;
                predchoziMys = e.Location;
                this.Invalidate();
                OnPosunZmenen(EventArgs.Empty);
            }
            else
                if (zobrazitKurzor)
                {
                    kurzor = PoziceKurzoru(e.X, e.Y);
                    this.Invalidate();
                }

            if (kreslenaUsecka != null)
            {
                PointF bodPohledu = PoziceKurzoru(e.X, e.Y);
                kreslenaUsecka.B.Nastav(bodPohledu.X, bodPohledu.Y, 0);
                this.Invalidate();
            }

            useckaPodKurzorem = zjistitUseckuPodKurzorem(SouradnicePohledu(e.X, e.Y));
        }

        private void menuLineOdebrat_Click(object sender, EventArgs e)
        {
            if (useckaPodKurzorem != null)
            {
                pohled.Usecky.Remove(useckaPodKurzorem);
                OnUseckaOdebrana(EventArgs.Empty);
                Invalidate();
            }
        }

        private void Drawer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                ResetPohledu();
            }
        }

        private void Drawer_MouseLeave(object sender, EventArgs e)
        {
            isActive = false;
            kurzor = PoziceKurzoru(ClientSize.Width / 2, ClientSize.Height / 2);
            Invalidate();
        }

        #endregion

        private void Drawer_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Cross;
        }
    }
}