using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibRekonstruktor.Filtry
{
    /// <summary>
    /// Rozhrani trid poskytujici funkce pro filtrovani hran
    /// </summary>
    public interface IFiltrHran
    {
        /// <summary>
        /// Funkce ktere se preda odkaz na mnozinu usecek, jeste pred tim nez se spoji prekryvajici se useky.
        /// </summary>
        /// <param name="hranyTelesa">Odkaz na mnozinu nespojenych usecek</param>
        void FiltrovatPredSpojenim(HashSet<LibRekonstruktor.ProstoroveObjekty.Usecka> hranyTelesa);

        /// <summary>
        /// Funkce, ktere se preda odkaz na mnozinu usecek, po tom co se spiji prekryvajici se useky.
        /// </summary>
        /// <param name="hranyTelesa">Odkaz na mnozinu spojenych usecek</param>
        void FiltrovatPoSpojeni(HashSet<LibRekonstruktor.ProstoroveObjekty.Usecka> hranyTelesa);
    }
}
