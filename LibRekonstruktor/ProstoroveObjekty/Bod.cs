using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibRekonstruktor.ProstoroveObjekty
{
    /// <summary>
    /// Trida popisujici pozizni bod v 3D prostoru. Body se shoduji, pokud maji shodne slozky
    /// </summary>
    public class Bod : Souradnice
    {
        public Bod() : base(0, 0, 0) { }

        public Bod(Souradnice b) : base(b.X, b.Y, b.Z) { }

        public Bod(float x, float y, float z) : base(x, y, z) { }

        #region Porovnavani

        public static bool operator ==(Bod a, Bod b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;

            return (Math.Round(a.x - b.x, 4) == 0) && (Math.Round(a.y - b.y, 4) == 0) && (Math.Round(a.z - b.z, 4) == 0);
        }

        public static bool operator !=(Bod a, Bod b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Math.Round(x, 4).GetHashCode() ^ Math.Round(y, 4).GetHashCode() ^ Math.Round(z, 4).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ((obj as Bod) == this);
        }

        #endregion

        #region Operatory

        /// <summary>
        /// Rozdil 2 bodu jako vektor smeru mezi nimy
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public Vektor operator -(Bod v1, Bod v2)
        {
            return new Vektor(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        static public Bod operator +(Bod v1, Vektor v2)
        {
            return new Bod(v1.x + v2.X, v1.y + v2.Y, v1.z + v2.Z);
        }

        static public Bod operator -(Bod v1, Vektor v2)
        {
            return new Bod(v1.x - v2.X, v1.y - v2.Y, v1.z - v2.Z);
        }

        static public explicit operator Vektor(Bod b)
        {
            return new Vektor(b);
        }

        #endregion

    }
}
