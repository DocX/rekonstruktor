using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LibRekonstruktor.Ukladani
{
    /// <summary>
    /// Uklazi objekt nakresu v jednoduchem textovem formatu
    /// </summary>
    public class TextUkladacPohledu : TextUkladac
    {
        public TextUkladacPohledu(TextWriter stream) : base (stream)
        {
        }

        public void ZapsatPohled(Vykres nakres)
        {
            foreach (var pohled in nakres.pohledy)
            {
                ZapsatPohled(pohled);
            }
        }

        public void ZapsatPohled(Pohled pohled)
        {
            writer.Write("[");
            // vektory roviny pohledu
            ZapsatUsecka3D(pohled.BazeX, pohled.BazeY);

            writer.WriteLine();

            // usecky
            foreach (var usecka in pohled.Usecky)
            {
                ZapsatUsecka2D(usecka);
                writer.WriteLine();
            }
            writer.Write("]");
            writer.WriteLine(); 
        }


    }
}
