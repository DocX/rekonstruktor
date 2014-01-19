using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;
using System.IO;
using System.Globalization;

namespace LibRekonstruktor.Ukladani
{
    /// <summary>
    /// Zajistuje zakladni funkce pro vsechny ukladace textoveho formatu
    /// </summary>
    public abstract class TextUkladac
    {
        protected TextWriter writer;

        protected TextUkladac(TextWriter stream)
        {
            if (stream == null)
                throw new ArgumentNullException();

            this.writer = stream;
        }

        /// <summary>
        /// Uzavre vnitrni popisovac soubou
        /// </summary>
        public void Close()
        {
            this.writer.Close();
        }

        /// <summary>
        /// Zapise souradnice krajnich bodu usecky ve formatu "{A.X,A.Y,A.Z;B.X,B.Y,B.Z}".
        /// </summary>
        /// <param name="usecka"></param>
        protected void ZapsatUsecka3D(Usecka usecka)
        {
            ZapsatUsecka3D(usecka.A, usecka.B);
        }

        /// <summary>
        /// Zapise souradnice krajnich bodu usecky ve formatu "{A.X,A.Y,A.Z;B.X,B.Y,B.Z}".
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void ZapsatUsecka3D(Souradnice a, Souradnice b)
        {
            writer.Write("{");
            ZapsatSouradniceXYZ(a);
            writer.Write(";");
            ZapsatSouradniceXYZ(b);
            writer.Write("}");
        }

        /// <summary>
        /// Zapise souradnice 
        /// </summary>
        /// <param name="s"></param>
        private void ZapsatSouradniceXYZ(Souradnice s)
        {
            ZapsatCislo(s.X);
            writer.Write(",");
            ZapsatCislo(s.Y);
            writer.Write(",");
            ZapsatCislo(s.Z);
        }

        /// <summary>
        /// Zapise cislo ve tvaru mantisy s exponentem a ve standartnim formatu
        /// </summary>
        /// <param name="p"></param>
        private void ZapsatCislo(float p)
        {
            writer.Write(p.ToString("E", CultureInfo.InvariantCulture.NumberFormat));
        }


        /// <summary>
        /// Zapise souradnice krajnich bodu usecky ve formatu "{A.X,A.Y;B.X,B.Y}".
        /// </summary>
        /// <param name="usecka"></param>
        protected void ZapsatUsecka2D(Usecka usecka)
        {
            writer.Write("{");
            ZapsatSouradniceXY(usecka.A);
            writer.Write(";");
            ZapsatSouradniceXY(usecka.B);
            writer.Write("}");
        }

        /// <summary>
        /// Zapise souradnice X a Y z predane struktury
        /// </summary>
        /// <param name="s"></param>
        private void ZapsatSouradniceXY(Souradnice s)
        {
            ZapsatCislo(s.X);
            writer.Write(",");
            ZapsatCislo(s.Y);
        }

    }
}
