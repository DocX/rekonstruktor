using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibRekonstruktor.ProstoroveObjekty
{
    /// <summary>
    /// Trida popisujici smerovy vektor v 3D prostoru. Vektory se shoduji pokud maji stejny smer.
    /// </summary>
    public class Vektor : Souradnice 
    {

        public Vektor() : base(0,0,0) { }

        public Vektor(float x, float y, float z) : base(x, y, z) { }

        public Vektor(Souradnice bod) : base(bod.X, bod.Y, bod.Z) { }

        /// <summary>
        /// Absolutni hodnota vektoru
        /// </summary>
        public float Delka
        {
            get { return (float)Math.Sqrt(x * x + y * y + z * z); }
        }

        /// <summary>
        /// Normalizuje vektor
        /// </summary>
        /// <returns></returns>
        public Vektor Jednotkovy()
        {
            return (1 / Delka) * this;
        }

        /// <summary>
        /// Vypocte skalarni soucin vektoru
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns>Vysledek skalarniho soucinu</returns>
        static public float SkalarniSoucin(Vektor u, Vektor v)
        {
            return u.x * v.x + u.y * v.y + u.z * v.z;
        }

        /// <summary>
        /// Vektorotovy soucin dvou vektoru
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        static public Vektor operator *(Vektor u, Vektor v)
        {
            Vektor s = new Vektor();
            s.x = /*(float)Math.Round(*/u.y * v.z - u.z * v.y/*,5)*/;
            s.y = /*(float)Math.Round(*/u.z * v.x - u.x * v.z/*,5)*/;
            s.z = /*(float)Math.Round(*/u.x * v.y - u.y * v.x/*,5)*/;
            return s;
        }

        /// <summary>
        /// Sklarni nasobek vektoru
        /// </summary>
        /// <param name="s"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        static public Vektor operator *(float s, Vektor v)
        {
            return new Vektor(v.x * s, v.y * s, v.z * s);
        }

        /// <summary>
        /// Secte 2 vektory
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public Vektor operator +(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Odecte 2 vektory
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public Vektor operator -(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        static public explicit operator Bod(Vektor b)
        {
            return new Bod(b);
        }


        #region Porovnavani

        /// <summary>
        /// Urci zda 2 vektory urcuji shodny smer
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public bool Rovnobezne(Vektor a, Vektor b)
        {
            //a.GetHashCode();
            return (a * b).JeNulovy;
        }
        
        public static bool operator ==(Vektor a, Vektor b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;

            return Rovnobezne(a,b);
        }

        public static bool operator !=(Vektor a, Vektor b)
        {
            return !(a == b);
        }

        /// <summary>
        /// normalizuje vektor a otocy ho tak aby byl vzdy ve stejnem poloprostoru
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            Vektor jednotkovy = this.Jednotkovy();
            if (x < 0)
            {
                jednotkovy = -1 * jednotkovy;
            }
            else if (x == 0)
            {
                if (y < 0)
                {
                    jednotkovy = -1 * jednotkovy;
                }
                else if (y == 0 && z < 0)
                {
                    jednotkovy = -1 * jednotkovy;
                }
            }

            return jednotkovy.BaseGetHashCode();

        }

        private int BaseGetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ((obj as Vektor) == this);
        }

        #endregion
    }

}
