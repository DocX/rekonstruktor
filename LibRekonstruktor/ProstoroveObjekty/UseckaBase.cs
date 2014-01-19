using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.Algebra;

namespace LibRekonstruktor.ProstoroveObjekty
{
    /// <summary>
    /// Ubsahuje spolecna data a metody pro usecku a primku
    /// </summary>
    abstract public class UseckaBase
    {
        #region Vnitrni reprezentace

        protected Bod p1, p2;

        protected UseckaBase()
        {
            p1 = new Bod();
            p2 = new Bod();
        }

        protected UseckaBase(Bod a, Bod b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException();

            p1 = a;
            p2 = b;
        }

        protected UseckaBase(float aX, float aY, float aZ, float bX, float bY, float bZ)
            : this(new Bod(aX, aY, aZ), new Bod(bX, bY, bZ))
        { }


        /// <summary>
        /// Pocatek usecky
        /// </summary>
        public Bod A
        {
            get { return p1; }
            set
            {
                if (value == null)
                    throw new NullReferenceException();
                p1 = value;
            }
        }

        /// <summary>
        /// Konec usecky (lze vyjadrit jako B = A + smer)
        /// </summary>
        public Bod B
        {
            get { return p2; }
            set
            {
                if (value == null)
                    throw new NullReferenceException();
                p2 = value;
            }
        }

        /// <summary>
        /// Smernicovy vektor usecky jako rozdil od A do B. Zmena dopocita B k pevnemu A.
        /// </summary>
        public Vektor Smernice
        {
            get { return p2 - p1; }
            set
            {
                if (value == null)
                    throw new NullReferenceException();
                p2 = p1 + value;
            }
        }

        #endregion


        #region Spolecne metody

        /// <summary>
        /// Vypocte prusecik s primkou urcenou predanou useckou. Vrati souradnici vuci vektoru teto usecky.
        /// </summary>
        /// <param name="p">Primka se kterou se hleda prusecik</param>
        /// <returns>Souradnice pruseciku vuci smernici teto usecky. NaN jestlize prusecik neexistuje</returns>
        public float SouradnicePrusecikuPrimek(UseckaBase p)
        {
            Matice soustava =
                new Matice(this.Smernice, -1 * p.Smernice, p.A - this.A);

            if (soustava.VyresitSoustavu() != ReseniSoustavy.NemaReseni && soustava[0, 0] == 1)
                return soustava[0, 2];

            return float.NaN;
        }

        /// <summary>
        /// Urci zda se bod nachazi na primce vytycene useckou
        /// </summary>
        /// <param name="b">Hledany bod</param>
        /// <returns>True kdyz lezi, False nikoli</returns>
        public bool PrimkaProchaziBodem(Bod b)
        {
            return VzdalenostOdPrimky(b) < 10e-4;
        }

        /// <summary>
        /// Urci vzdalenost bodu od primky
        /// </summary>
        /// <param name="b">Hledany bod</param>
        /// <param name="primka">Primka</param>
        /// <returns>Vzdalenost bodu od primky</returns>
        public float VzdalenostOdPrimky(Bod b)
        {

            return ((b - p1) * (b - p2)).Delka / Smernice.Delka;
        }

        #endregion
    }
}
