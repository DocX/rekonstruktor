using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;
using LibRekonstruktor.Algebra;

namespace LibRekonstruktor
{

    /// <summary>
    /// Pohled zastresuje rovinu pohledu v prostoru a abstrahuje usecky zobrazene na pohledu
    /// pomoci souradnic pohledu. Rovina pohledu vzdy prochází počátkem
    /// </summary>
    public class Pohled
    {

        public enum PojmenovanePohledy
        {
            Zepredu,
            Zezadu,
            Zleva,
            Zprava,
            Zdola,
            Shora,
            Neznamy
        }

        private LinkedList<Usecka> usecky;

        /// <summary>
        /// Vektory souradneho systemu tohoto pohledu. Vsechny usecky pohledu maji X a Y jako koeficient pro kombinaci s temito vektory.
        /// Resp. tyto vektory jsou smerovymy vektory roviny pohledu.
        /// </summary>
        private Vektor vektorX, vektorY;

        Vektor normala;

        private Pohled()
        {
            this.usecky = new LinkedList<Usecka>();
        }

        public Pohled(Vektor bazeX, Vektor bazeY) : this()
        {
            if (bazeX == null || bazeY == null)
                throw new ArgumentNullException();

            if (bazeX.JeNulovy || bazeY.JeNulovy)
                throw new ArgumentException("Bazovy vektor nesmi byt nulovy");

            vektorX = bazeX;
            vektorY = bazeY;

            normala = vektorX * vektorY;
        }

        public Pohled(PojmenovanePohledy pohled) : this()
        {
            vektorX = new Vektor();
            vektorY = new Vektor();

            switch (pohled)
            {
                case PojmenovanePohledy.Zepredu:
                    vektorX.Nastav(1, 0, 0);
                    vektorY.Nastav(0, 0, 1);
                    break;
                case PojmenovanePohledy.Zezadu:
                    vektorX.Nastav(-1, 0, 0);
                    vektorY.Nastav(0, 0, 1);
                    break;
                case PojmenovanePohledy.Zleva:
                    vektorX.Nastav(0, -1, 0);
                    vektorY.Nastav(0, 0, 1);
                    break;
                case PojmenovanePohledy.Zprava:
                    vektorX.Nastav(0, 1, 0);
                    vektorY.Nastav(0, 0, 1);
                    break;
                case PojmenovanePohledy.Zdola:
                    vektorX.Nastav(1,0, 0);
                    vektorY.Nastav(0, -1,0);
                    break;
                case PojmenovanePohledy.Shora:
                    vektorX.Nastav(1, 0, 0);
                    vektorY.Nastav(0, 1, 0);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public PojmenovanePohledy Pojmenovany
        {
            get
            {
                if (vektorX.X == 1 && vektorX.Y == 0 && vektorX.Z == 0)
                {
                    if (vektorY.X == 0 && vektorY.Y == 0 && vektorY.Z == 1)
                        return PojmenovanePohledy.Zepredu;
                    if (vektorY.X == 0 && vektorY.Y == 1 && vektorY.Z == 0)
                        return PojmenovanePohledy.Shora;
                    if (vektorY.X == 0 && vektorY.Y == -1 && vektorY.Z == 0)
                        return PojmenovanePohledy.Zdola;
                }
                else if ((vektorY.X == 0 && vektorY.Y == 0 && vektorY.Z == 1))
                {
                    if (vektorX.X == -1 && vektorX.Y == 0 && vektorX.Z == 0)
                        return PojmenovanePohledy.Zezadu;
                    if (vektorX.X == 0 && vektorX.Y == 1 && vektorX.Z == 0)
                        return PojmenovanePohledy.Zprava;
                    if (vektorX.X == 0 && vektorX.Y == -1 && vektorX.Z == 0)
                        return PojmenovanePohledy.Zleva;
                }
                return PojmenovanePohledy.Neznamy;
            }
        }

        public Vektor NormalaRovinyPohledu
        {
            get
            {
                if (object.ReferenceEquals(normala,null))
                    normala = vektorX * vektorY;
                return normala;
            }
        }

        public Vektor BazeX
        {
            get { return new Vektor(vektorX); }
            set { if (value.JeNulovy) throw new ArgumentException(); vektorX = new Vektor(value); normala = vektorX * vektorY; }
        }

        public Vektor BazeY
        {
            get { return new Vektor(vektorY); }
            set { if (value.JeNulovy) throw new ArgumentException(); vektorY = new Vektor(value); normala = vektorX * vektorY; }
        }
       

        /// <summary>
        /// Seznam usecek (zobrazenych hran telesa) v pohledu
        /// </summary>
        public LinkedList<Usecka> Usecky
        {
            get { return this.usecky; }
        }

        /// <summary>
        /// Vytvori pole rovin, ktere jsou urcney useckami v pohledu, na kterych musi lezet nejaka hrana modelu
        /// </summary>
        public Rovina[] ZiskatUrcujiciRoviny()
        {
            
            Rovina[] roviny = new Rovina[this.usecky.Count];

            int i = 0;

            foreach (Usecka u in this.usecky)
            {
                roviny[i++] = UseckaNaUrcujiciRovinu(u);
            }

            return roviny;
        }


        protected Rovina UseckaNaUrcujiciRovinu(Usecka u)
        {
            Vektor v;
            v = u.Smernice;

            // transformace vektoru do bazove roviny v prostoru
            v = (v.X * vektorX) + (v.Y * vektorY);

            Rovina rovina;
            // vektor usecky v prostoru a vektor kolmy na rovinu pohledu urcuji spolu s bodem rovinu
            // na ktere musi lezet hrana, ktera se zobrazila do teto usecky.
            // Navic musi lezet presne ve vsech bodech p*v, kde p z <0,1>
            rovina = new Rovina((Bod)(u.A.X * vektorX + u.A.Y * vektorY), v, NormalaRovinyPohledu);
            rovina.umin = 0;
            rovina.umax = 1;

            return rovina;
        }

        public Bod PromitnoutNaRovinuPohledu(Bod b)
        {
            Bod obraz = new Bod();

            // toto opravdu neni matice zobrazeni, ale pro kanoncicke pohledy to funguje
            obraz.X = b.X * vektorX.X + b.Y * vektorX.Y + b.Z * vektorX.Z;
            obraz.Y = b.X * vektorY.X + b.Y * vektorY.Y + b.Z * vektorY.Z;

            return obraz;
        }

        /// <summary>
        /// Prevede bod pohledu na bod v prostoru na rovine pohledu
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public Bod NaBodVProstoru(Bod b)
        {
            return (Bod)(b.X * vektorX + b.Y * vektorY);
        }

        public Usecka PromitnoutNaRovinuPohledu(Usecka u)
        {
            Usecka promitnuta = new Usecka();
            promitnuta.A = PromitnoutNaRovinuPohledu(u.A);
            promitnuta.B = PromitnoutNaRovinuPohledu(u.B);
            return promitnuta;
        }

        /// <summary>
        /// Promitne primky, vytahnute z kraju usecek predaneho pohledu do prostoru, na tento pohled
        /// </summary>
        /// <param name="pohled">Pohled k promitnuti na rovinu tohoto pohledu</param>
        /// <returns>Promitle usecky v tomto pohledu</returns>
        public Primka[] PromitnoutNaRovinuPohledu(Pohled pohled)
        {
            // shodne primky staci jednou
            HashSet<Primka> primky = new HashSet<Primka>();

            foreach (var usecka in pohled.usecky)
            {
                Usecka hranaA = new Usecka(pohled.NaBodVProstoru(usecka.A), pohled.NormalaRovinyPohledu);
                Usecka hranaB = new Usecka(pohled.NaBodVProstoru(usecka.B), pohled.NormalaRovinyPohledu);
                

                primky.Add((Primka)PromitnoutNaRovinuPohledu(hranaA));
                primky.Add((Primka)PromitnoutNaRovinuPohledu(hranaB));
            }

            return primky.ToArray();
        }

    }
}
