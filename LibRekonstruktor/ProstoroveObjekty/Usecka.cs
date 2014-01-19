using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;

namespace LibRekonstruktor.ProstoroveObjekty
{
    /// <summary>
    /// Usecka v 3D prostoru ohranicena 2 body
    /// </summary>
    public class Usecka : UseckaBase
    {
        #region Inicializace 

        public Usecka() : base() { }

        public Usecka(Bod a, Bod b) : base(a,b) { }

        public Usecka(Bod a, Vektor smernice) : base(a, a + smernice) { }

        public Usecka(float aX, float aY, float aZ, float bX, float bY, float bZ)
            : base(aX, aY, aZ, bX, bY, bZ) { }

        #endregion

        #region Metody specificke pro usecku

        /// <summary>
        /// Zjisti zda je urceny bod soucasti usecky (tj skutecne mezi body A a B)
        /// </summary>
        /// <param name="b">Zkoumany bod</param>
        /// <param name="tolerance">Maximalni odchylka</param>
        /// <returns>True jestlize prochazi bodem</returns>
        public bool LeziNaUsecce(Bod b, float tolerance)
        {
            Vektor s = Smernice;
            float delkaSmernice = s.Delka;

            float t =
                Vektor.SkalarniSoucin((b - p1), s) /
                (delkaSmernice * delkaSmernice);

            float vzdalenost = (b - (p1 + (t * s))).Delka;

            return 
                vzdalenost < tolerance &&
                t >= 0 - (tolerance / delkaSmernice) &&
                t <= 1 + (tolerance / delkaSmernice);
        }



        /// <summary>
        /// Vyjadri krajni body predane usecky souradnicemi teto usecky.
        /// </summary>
        /// <param name="usecka">Usecka, jejiz krajni body se vyjadri.</param>
        /// <param name="a">Navratovy parametr souradnice bodu A.</param>
        /// <param name="b">Navratovy parametr souradnice bodu B.</param>
        /// <returns>True, kdyz lze souradnice vyjadrit, False kdyz ne.</returns>
        private bool SouradniceKrajnichBodu(Usecka usecka, ref float a, ref float b)
        {
            Vektor aS = Smernice;

            // porovnat smer
            if (!Vektor.Rovnobezne(aS, usecka.Smernice))
                return false;

            // lezi na shodne primce
            if (!PrimkaProchaziBodem(usecka.p1))
                return false;

            // vyjadrit krajni body b vuci smernici a (staci pocitat s jednou souradnici, ostatni by meli sedet, protoze je stejny smer)
            if (aS.X != 0)
            {
                a = (usecka.p1 - p1).X / aS.X;
                b = (usecka.p2 - p1).X / aS.X;
            }
            else if (aS.Y != 0)
            {
                a = (usecka.p1 - p1).Y / aS.Y;
                b = (usecka.p2 - p1).Y / aS.Y;
            }
            else
            {
                a = (usecka.p1 - p1).Z / aS.Z;
                b = (usecka.p2 - p1).Z / aS.Z;
            }

            return true;
        }

        /// <summary>
        /// Nalezne prunik dvou usecek.
        /// </summary>
        /// <param name="a">Usecka 1</param>
        /// <param name="b">Usecka 2</param>
        /// <returns>Usecka pruniku nebo null pokud prunik neexistuje</returns>
        static public Usecka Prunik(Usecka a, Usecka b)
        {
            float b1, b2;
            b1 = b2 = float.NaN;
            if (!a.SouradniceKrajnichBodu(b, ref b1, ref b2))
                return null;

            if (b1 > b2)
            {
                float t = b2;
                b2 = b1;
                b1 = t;
            }

            // spocitat prunik
            float i1 = Math.Max(b1, 0);
            float i2 = Math.Min(b2, 1);

            if (i1 > i2)
            {
                // prunik neni
                return null;
            }
            else
            {
                return new Usecka(a.p1 + i1 * a.Smernice, a.p1 + i2 * a.Smernice);
            }
        }

        /// <summary>
        /// Pokusi se najit spojitou usecku slouceni obou predanych
        /// </summary>
        /// <param name="a">Usecka 1</param>
        /// <param name="b">Usecka 2</param>
        /// <returns>Useka sjednoceni nebo null, pokud neexistuje spojite sjednoceni</returns>
        static public Usecka Sjednoceni(Usecka a, Usecka b)
        {
            float b1, b2;
            b1 = b2 = float.NaN;
            if (!a.SouradniceKrajnichBodu(b, ref b1, ref b2))
                return null; 
            
            if (b1 > b2)
            {
                float t = b2;
                b2 = b1;
                b1 = t;
            }

            // jestlize jsou spojite, je prunik
            if (Math.Max(0, b1) <= Math.Min(b2, 1))
            {
                float u1 = Math.Min(0, b1);
                float u2 = Math.Max(1, b2);

                return new Usecka(a.p1 + u1 * a.Smernice, a.p1 + u2 * a.Smernice);
            }
            else
                // prunik neni, nejsou spojite
                return null;

        }

#endregion

        #region Implementace objektovych vlastnosti

        public static bool operator ==(Usecka  a, Usecka  b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;

            return (a.p1 == b.p1 && a.p2 == b.p2) || (a.p1 == b.p2 && a.p2 == b.p1);
        }

        public static bool operator !=(Usecka a, Usecka b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return p1.GetHashCode() ^ p2.GetHashCode();
        }

        public override string ToString()
        {
            return p1.ToString() + " - " + p2.ToString();
        }


        public override bool Equals(object other)
        {
            return (other as Usecka) == this;
        }

        public static explicit operator Primka(Usecka p)
        {
            return new Primka(p.p1, p.p2);
        }

        #endregion
    }

}
