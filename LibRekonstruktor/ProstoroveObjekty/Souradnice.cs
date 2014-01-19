using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibRekonstruktor.ProstoroveObjekty
{
    /// <summary>
    /// Reprezentuje zakladni tridu pro 3D souradnice
    /// </summary>
    public abstract class Souradnice
    {
        protected float x, y, z;

        protected Souradnice(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float X
        {
            get { return x; }
            //set { x = (float)Math.Round(value, 4); }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            //set { y = (float)Math.Round(value, 4); }
            set { y = value; }
        }

        public float Z
        {
            get { return z; }
            //set { z = (float)Math.Round(value, 4); }
            set { z = value; }
        }

        public void Nastav(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Zaokrouhli vsechny souradnice na dany pocet desetinych mist
        /// </summary>
        /// <param name="mist">Pocet desetinych platnych mist</param>
        public void ZaokrouhlitSouradnice(int mist)
        {
            x = (float)Math.Round(x, mist);
            y = (float)Math.Round(y, mist);
            z = (float)Math.Round(z, mist);
        }

        /// <summary>
        /// Urci zda je souradnice nulova
        /// </summary>
        public bool JeNulovy
        {
            get { return (Math.Round(z, 4) == 0) && (Math.Round(y, 4) == 0) && (Math.Round(x, 4) == 0); }
        }

        public override string ToString()
        {
            return x.ToString() + "; " + y.ToString() + "; " + z.ToString();
        }

        public override int GetHashCode()
        {
            uint xh, yh, zh;
            xh = (uint)x.GetHashCode();
            yh = (uint)y.GetHashCode();
            zh = (uint)z.GetHashCode();

            // veme z kazdeho cislo znamenkovy bit, 4 dolni bity exponentu a 5 hornich bitu
            // mantisy a posklada za sebe

            return (
                ((xh >> 31 << 31) | (xh << 5 >> 28 << 27) | (xh << 9 >> 27 << 22)) |
                ((yh >> 31 << 31) | (yh << 5 >> 28 << 27) | (yh << 9 >> 27 << 22)) >> 10 |
                ((zh >> 31 << 31) | (zh << 5 >> 28 << 27) | (zh << 9 >> 27 << 22)) >> 20)
                .GetHashCode();
        }
    }
}
