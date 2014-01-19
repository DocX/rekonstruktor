using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.Algebra;

namespace LibRekonstruktor.ProstoroveObjekty
{

    /// <summary>
    /// Reprezentuje "ohranicenou" rovinu, ktera vznika vytahnutim hrany z pohledu. Je to tedy rovina na ktere musela lezet hrana v prostoru,
    /// aby se promitla do zminene hrany v pohledu.
    /// </summary>
    public class Rovina
    {
        /// <summary>
        /// Vektor roviny urceny podle sklonu hrany v pohledu
        /// </summary>
        Vektor u;

        /// <summary>
        /// Vektro kolmy na rovinu pohledu
        /// </summary>
        Vektor v;

        /// <summary>
        /// Bod na rovine ktery lezi v pocatku hrany z pohledu
        /// </summary>
        Bod p;

        /// <summary>
        /// Interval vektoru u, ktery vymezuje oblast roviny
        /// </summary>
        internal float umin, umax;

        /// <summary>
        /// Vytvori novou instanci roviny urcenou 2 useckami a bodem
        /// </summary>
        /// <param name="p">Bod lezici na rovine</param>
        /// <param name="u">Smerovy vektor jedne usecky</param>
        /// <param name="v">Smerovy vektor druhe usecky</param>
        public Rovina(Bod p, Vektor u, Vektor v, float umin, float umax)
        {
            if ((u * v).JeNulovy)
                throw new ArgumentException("Nulovy vektor neurcuje rovinu");
            
            this.u = u;
            this.v = v;

            this.p = p;

            this.umin = umin;
            this.umax = umax;
        }

        public Rovina(Bod p, Vektor u, Vektor v) : this(p, u, v, float.NegativeInfinity, float.PositiveInfinity) { }

        /// <summary>
        /// Vektor normaly roviny
        /// </summary>
        Vektor NormalaRoviny
        {
            get { return v * u; }
        }

        /// <summary>
        /// Najde usecku, ktera je prunikem dvou ohranicenych rovin
        /// </summary>
        /// <param name="r1">Rovina 1</param>
        /// <param name="r2">Rovina 2</param>
        /// <param name="prusecnice">Navratova promena usecky pruniku</param>
        /// <returns>True, kdyz je prusecnice nalezena, False jinak</returns>
        static public bool NajitPrusecnici(Rovina r1, Rovina r2, out Usecka prusecnice)
        {
            const float zanedbatelnaOdchylka = 10e-5f;

            Vektor r1n = r1.NormalaRoviny;
            Vektor r2n = r2.NormalaRoviny;

            // smernice pripadne prusecnice
            Vektor prusecSmer = r1n * r2n;

            prusecnice = null;

            // absolutni hodnoty souradnic smernice
            // potreba pro urceni rovnobeznosti a nejvetsi souradnice
            Vektor a = new Vektor();
            a.X = Math.Abs(prusecSmer.X);
            a.Y = Math.Abs(prusecSmer.Y);
            a.Z = Math.Abs(prusecSmer.Z);

            // nejsou rovnobezne
            if ((a.X + a.Y + a.Z) < zanedbatelnaOdchylka)
                return false;

            // vypocitat spolecny bod obou rovin
            Bod prusecBod = new Bod();
            float d1, d2;
            d1 = -Vektor.SkalarniSoucin(r1n, new Vektor(r1.p));  
            d2 = -Vektor.SkalarniSoucin(r2n, new Vektor(r2.p));
            
            // zjistit nejvetsi souradnici smernice
            int nejSouradnice = 3;
            if (a.X > a.Y)
            {
                if (a.X > a.Z)
                    nejSouradnice = 1;
            }
            else
            {
                if (a.Y > a.Z)
                    nejSouradnice = 2;
            }

            switch (nejSouradnice)
            { 
                case 1:                 
                    prusecBod.X = 0;
                    prusecBod.Y = (d2 * r1n.Z - d1 * r2n.Z) / prusecSmer.X;
                    prusecBod.Z = (d1 * r2n.Y - d2 * r1n.Y) / prusecSmer.X;
                    break;
                case 2:                    
                    prusecBod.X = (d1 * r2n.Z - d2 * r1n.Z) / prusecSmer.Y;
                    prusecBod.Y = 0;
                    prusecBod.Z = (d2 * r1n.X - d1 * r2n.X) / prusecSmer.Y;
                    break;
                case 3:                  
                    prusecBod.X = (d2 * r1n.Y - d1 * r2n.Y) / prusecSmer.Z;
                    prusecBod.Y = (d1 * r2n.X - d2 * r1n.X) / prusecSmer.Z;
                    prusecBod.Z = 0;
                    break;
            }

            // primka na ktere lezi usecka pruniku
            Usecka p = new Usecka(prusecBod, prusecBod + prusecSmer);

            return NajitPrunikRovinPodlePrusecnice(p, r1, r2, out prusecnice) || NajitPrunikRovinPodlePrusecnice(p, r2, r1, out prusecnice);
        }

        /// <summary>
        /// Najde usecku, ktera lezi v prusecnici dvou rovin a je omezena ohranicenim rovin.
        /// Pokud roviny nemaji spolecnou cast, vrati false. 
        /// </summary>
        /// <param name="p">Usecka prusecnice</param>
        /// <param name="rovina1">Rovina pruniku</param>
        /// <param name="rovina2">Rovina pruniku</param>
        /// <param name="prunik">Vystupni parametr usecky, ktera tvori prunik</param>
        /// <returns>TRUE, pokud se roviny v prusecnici prekryvaji a byla nalezena usecka pruniku, jinak FALSE.</returns>
        static private bool NajitPrunikRovinPodlePrusecnice(Usecka p, Rovina rovina1, Rovina rovina2, out Usecka prunik)
        {
            // souradnice pruseciku obou hran s primkou pruniku
            float min, max;
            min = p.SouradnicePrusecikuPrimek(rovina1.HranaMin);
            max = p.SouradnicePrusecikuPrimek(rovina1.HranaMax);

            prunik = null;

            // pokd prunik ohraniceni vubec existuje
            if (!float.IsNaN(min) && !float.IsNaN(max))
            {
                Bod A = p.A + (min * p.Smernice);
                Bod B = p.A + (max * p.Smernice);
                if (NajitPrunikUseckySRozmezimRoviny(rovina2, ref A, ref B))
                {
                    // prunik nalezen, muzem vratit
                    prunik = new Usecka(A, B);
                    return true;
                }
                else
                {
                    // prunik nenalezen
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Vyjadri krajni body usecky pomoci souradnic v rovine. Pote se pokusi najit jeji vyrez v hranicich roviny.
        /// </summary>
        /// <param name="r">Rovina podle ktere se hleda vyrez usecky</param>
        /// <param name="A">Prvni krajni bod usecky</param>
        /// <param name="B">Druhy krajni bod usecky</param>
        /// <returns>True kdyz je usecka alespon z casti soucasti roviny, False jinak</returns>
        static private bool NajitPrunikUseckySRozmezimRoviny(Rovina r, ref Bod A, ref Bod B)
        {
            // vyjadrit souradnice pruseciku hran roviny 1 v rovine 2 ( je jasne ze vuci svoji rovine budou v poradku )
            Matice m = new Matice(3, 4);
            m.Naplnit(r.u, r.v, A - r.p, B - r.p);

            // pruseciky exituji, zjistit zda spadaji do pozadovaneho intervalu
            if (m.VyresitSoustavu() != ReseniSoustavy.NemaReseni)
            {
                // souradnice pruseciku hran min a max vuci bazi roviny
                float Au, Av, Bu, Bv;
                Au = m[0, 2];
                Bu = m[0, 3];

                Av = m[1, 2];
                Bv = m[1, 3];

                // seradit
                if (Au > Bu)
                {
                    float tu = Au, tv = Av;
                    Au = Bu;
                    Bu = tu;
                    Av = Bv;
                    Bv = tv;
                }

                // posunout pokud přečuhuje usecka vymezena hranamy roviny 1 v rovine 2

                // pomer "o kolik se zmeni v kdyz se u zmeni o 1"
                float pomer = (Av - Bv) / (Au - Bu);

                // ruzne pripady
                if (Au <= r.umax)
                {
                    // mensi krajni bod je mensi jak vetsi krajni bod intervalu

                    // kdyz druhy vycuhuje za interval
                    if (Bu > r.umax)
                    {
                        // posunout umax na r2.umax
                        Bv += (r.umax - Bu) * pomer;
                        Bu = r.umax;
                    }
                }

                if (r.umin <= Bu)
                {
                    // druhy krajni bod je za prvnim bodem intervalu

                    // kdyz prvni vyzuhu "pred" interval
                    if (Au < r.umin)
                    {
                        // posunout
                        Av += (r.umin - Au) * pomer;
                        Au = r.umin;
                    }
                }

                // jestlize predchozi upravy upravili krajni body tak, aby byly v intervalu
                // vratit upravene souradnice
                if (r.umin <= Au && Au <= r.umax && r.umin <= Bu && Bu <= r.umax)
                //if ((Math.Abs(r.umin - Au) < 10e-5 || Math.Abs(r.umax - Au) < 10e-5)
                 //   && (Math.Abs(r.umax - Bu) < 10e-5 || Math.Abs(r.umin - Bu) < 10e-5))
                {
                    A = r.p + Au * r.u + Av * r.v;
                    A.ZaokrouhlitSouradnice(5);
                    B = r.p + Bu * r.u + Bv * r.v;
                    B.ZaokrouhlitSouradnice(5);
                    return true;
                }
                else
                {
                    // jinak nejsou ani z casti soucasti roviny 2
                    A = null;
                    B = null;
                    return false;
                }
            }
            return false;
        }


        /// <summary>
        /// Usecka lezici na primce hrany urcene levym krajem intervalu u
        /// </summary>
        public Usecka HranaMin
        {
            get
            {
                if (!float.IsInfinity(umin))
                {
                   return (new Usecka(
                        new Bod(p + (umin * u)),
                        new Bod(p + (umin * u) + v)));
                }
                return null;
            }
        }

         /// <summary>
        /// Usecka lezici na primce hrany urcene pravym krajem intervalu u
        /// </summary>
        public Usecka HranaMax
        {
            get
            {
                if (!float.IsInfinity(umax))
                {
                    return (new Usecka(
                         new Bod(p + (umax * u)),
                         new Bod(p + (umax * u) + v)));
                }
                return null;
            }
        }       
    }
}
