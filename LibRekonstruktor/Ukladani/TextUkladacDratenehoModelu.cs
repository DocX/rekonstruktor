using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LibRekonstruktor.ProstoroveObjekty;

namespace LibRekonstruktor.Ukladani
{
    /// <summary>
    /// Uklada sadu hran drateneho modelu ve 3D prostoru v textovem formatu
    /// </summary>
    public class TextUkladacDratenyModel : TextUkladac
    {

        public TextUkladacDratenyModel(TextWriter stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Zapise sadu hran
        /// </summary>
        /// <param name="hrany"></param>
        public void ZapsatHranu(IEnumerable<Usecka> hrany)
        {
            foreach (var hrana in hrany )
            {
                ZapsatHranu(hrana);
            }
        }

        /// <summary>
        /// Zapise jednu hranu
        /// </summary>
        /// <param name="hrana"></param>
        public void ZapsatHranu(Usecka hrana)
        {
            ZapsatUsecka3D(hrana);
        }


    }
}
