using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibRekonstruktor.ProstoroveObjekty
{
    /// <summary>
    /// Rozsireni usecky na primku. Primky se shoduji pokud maji shodny smer smernice a jeden bod.
    /// </summary>
    public class Primka : UseckaBase
    {
        public Primka(Bod a, Bod b)
        {
            if ((a - b).JeNulovy)
                throw new ArgumentException("Primka nemuze mit nulovy smer");
            p1 = a;
            p2 = b;
        }

        public Primka(Bod a, Vektor smernice) : this(a, (Bod)(a + smernice)) { }

        public Primka(float aX, float aY, float aZ, float bX, float bY, float bZ)
            : this(new Bod(aX, aY, aZ), new Bod(bX, bY, bZ)) { }


        #region Implementace objektovych vlastnosti

        /// <summary>
        /// Primky se rovnaji, pokud se prolinaji
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True pokud se primky shoduji</returns>
        public static bool operator ==(Primka a, Primka b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;

            return Vektor.Rovnobezne(a.Smernice, b.Smernice) && a.PrimkaProchaziBodem(b.p1);
        }

        public static bool operator !=(Primka a, Primka b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            // tezko urcit jednotny pocatecni bod pro vsechny stejne primky
            // alespon vratit hash smernice, kdyz se ta neschoduje, urcite se neshoduji primky

            return Smernice.GetHashCode();
        }

        public override string ToString()
        {
            return p1.ToString() + " -> " + Smernice.ToString();
        }


        public override bool Equals(object other)
        {
            return (other as Primka) == this;
        }

        public static explicit operator Usecka(Primka p)
        {
            return new Usecka(p.p1, p.p2);
        }

        #endregion

    }

}
