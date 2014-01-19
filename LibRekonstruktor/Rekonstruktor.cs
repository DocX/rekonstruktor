using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.Algebra;
using LibRekonstruktor.ProstoroveObjekty;
using LibRekonstruktor.Filtry;

namespace LibRekonstruktor
{
    /// <summary>
    /// Vysledek rekonstrukce
    /// </summary>
    public struct Rekonstrukce
    {
        internal Usecka[] hranyTelesa;
        internal Usecka[] prunikyRovin;

        public Usecka[] HranyTelesa
        {
            get { return hranyTelesa; }
        }

        public Usecka[] PrunikyRovin
        {
            get { return prunikyRovin; }
        }

        public bool Empty
        {
            get { return hranyTelesa == null || prunikyRovin == null;  }
        }
    }

    /// <summary>
    /// Hlavni trida Rekostruktoru implementujici algoritmus rekonstrukc.
    /// </summary>
    public class Rekonstruktor
    {

        public Rekonstruktor() : this(null)
        {
        }

        public Rekonstruktor(IFiltrHran filtr)
        {
            this.filtr = filtr;
        }

        IFiltrHran filtr;

        public IFiltrHran Filtr { set { filtr = value; } get { return filtr;  } }


        /// <summary>
        /// Implementace rekonstrukcniho algoritmu, rekonstruuje pohledy na hrany drateneho
        /// modelu
        /// </summary>
        /// <param name="nakres">Objekt vykresu obsahujici pohledy</param>
        /// <returns>Vysledek rekonsturkce</returns>
        public Rekonstrukce Rekonstruovat(Vykres vykres)
        {
            Rekonstrukce vysledek;

			/*
			 * 1) Ziskat z kazdeho nakresu plochy vytažene z jeho usecek
			 */

            // roviny vytahle z usecek jednotlivych pohledu
            // zde staci linked-list jelikoz od toho nepotrebuji nic vic nez
            // rychle zapisovatelne a prochazetelne uloziste
            LinkedList<Rovina[]> rovinyPohledu = new LinkedList<Rovina[]>();

			// ziskat ze vsech pohledu roviny vytazene z usecek
            foreach (var item in vykres.pohledy)
            {
                rovinyPohledu.AddLast(item.ZiskatUrcujiciRoviny());
            }


			/*
			 * 2) Pro kazdou dvojici ploch z ruznych pohledu ziskat jejich průnik
			 */
            
            // prvekem linked listu je sada průniku mnozin ploch jedne dvojice pohledu
            // sada pruniku je ulozena jako hashset, protoze se tim automaticky zbavim
            // duplicitnich usecek (viz metoda Usecka.GetHashCode())
            LinkedList<HashSet<Usecka>> prunikyDvojicRovin = new LinkedList<HashSet<Usecka>>();

            {
                HashSet<Usecka> vsechnyPruniky = new HashSet<Usecka>();
                LinkedListNode<Rovina[]> prvni = rovinyPohledu.First;
                while (prvni != null)
                {
                    LinkedListNode<Rovina[]> druhy = prvni.Next;
                    while (druhy != null)
                    {
                        HashSet<Usecka> pruniky = NajitPrunikyRovin(prvni.Value, druhy.Value);
                        prunikyDvojicRovin.AddLast(pruniky);
                        vsechnyPruniky.UnionWith(pruniky);
                        druhy = druhy.Next;
                    }
                    prvni = prvni.Next;
                }

                vysledek.prunikyRovin = vsechnyPruniky.ToArray();
            }

			/*
			 * 2) Pro kazde 2 mnoziny pruniku pochazejici z pruniku ruznych dvojic pohledů
			 *    najit pruniky
			 */

			// opet HashSet, ktery automaticky ignoruje duplicitni usecky
            HashSet<Usecka> hranyTelesa = new HashSet<Usecka>();

            {
                LinkedListNode<HashSet<Usecka>> prvni = prunikyDvojicRovin.First;
                while (prvni != null)
                {
                    LinkedListNode<HashSet<Usecka>> druhy = prvni.Next;
                    while (druhy != null)
                    {
                        hranyTelesa.UnionWith(VybratPrunikyHran (prvni.Value, druhy.Value));
                        druhy = druhy.Next;
                    }
                    prvni = prvni.Next;
                }
            }

            // odfiltrovat hrany
            if (filtr != null)
                filtr.FiltrovatPredSpojenim(hranyTelesa);

            
            // Slit casti usecek do sebe (pro lepsi vystup)
            SpojitUsecky(hranyTelesa);


            // odfiltrovat hrany
            if (filtr != null)
                filtr.FiltrovatPoSpojeni(hranyTelesa);


			// vratit vysledek
            vysledek.hranyTelesa = hranyTelesa.ToArray();

            return vysledek;

        }

        private HashSet<Usecka> VybratPrunikyHran(IEnumerable<Usecka> sada1, IEnumerable<Usecka> sada2)
        {
			// najde takove dvojice hran z kartezskeho soucinu obou sad, takove ze se prekryvaji
			// a vybere z nich prave cast ktera se prekryva.
			
            HashSet<Usecka> vybrane = new HashSet<Usecka>();

            foreach (var hrana in sada1)
            {
                foreach (var zkoumana in sada2)
                {
                    Usecka prunik;
                    if ((prunik = Usecka.Prunik(hrana, zkoumana)) != null && !prunik.Smernice.JeNulovy)
                    {
                        // lze pridat prunik, je totiz soucasti 2 ruznych pruniku ruznych pohledů
                        vybrane.Add(prunik);
                    }
                }
            }

            return vybrane;
        }

        private HashSet<Usecka> NajitPrunikyRovin(IEnumerable<Rovina> r1, IEnumerable<Rovina> r2)
        {
			// pro kazdou dvojici z kart. soucinu obou sad rovin najde prusecnici techto rovin
        
            HashSet<Usecka> pruniky = new HashSet<Usecka>();

            foreach (Rovina urcujiciRovina in r1)
            {
                foreach (var rovina in r2)
                {
                    Usecka u;
                    if (Rovina.NajitPrusecnici(urcujiciRovina, rovina, out u))
                    {
                        pruniky.Add(u);
                    }
                }
            }

            return pruniky;
        }

        /// <summary>
        /// Destruktivni (puvodni usecky nejsou zachovany) sjedoceni usecek, ktere maji spolecne casti.
        /// </summary>
        /// <param name="usecky">Kolekce usecek ke sjednoceni</param>
        private void SpojitUsecky(ICollection<Usecka> usecky)
        {
            bool spojeno;
            do
            {
                spojeno = false;
                foreach (var hrana1 in usecky)
                {
                    foreach (var hrana2 in usecky)
                    {
                        if (hrana1 == hrana2)
                            continue;

                        Usecka u = Usecka.Sjednoceni(hrana1, hrana2);
                        if (u != null)
                        {
                            // odebrat spojene a nahradit
                            usecky.Remove(hrana1);
                            usecky.Remove(hrana2);
                            usecky.Add(u);
                            spojeno = true;
                            break;
                        }

                    }
                    if (spojeno)
                        break;
                }
            } while (spojeno);
        }



    }
}
