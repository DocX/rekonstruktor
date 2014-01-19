using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;
using LibRekonstruktor.Algebra;

namespace LibRekonstruktor.Filtry
{
    /// <summary>
    /// EXPERIMENTALNI!! Filtr hran, jejichz vrcholy nesousedi s takovymy hranami, aby tvorili 3D prostor.
    /// </summary>
    public class DimenzionalniFiltr : IFiltrHran
    {

        /// <summary>
        /// Vytvori instanci dimenzionalniho filtru hran s pozadovanou prisnosti
        /// </summary>
        /// <param name="prisnyMod">Pokud true, odstrani pouze hrany, jejichz oba vrcholy netvori 3D prostor. Normalne staci k odstraneni jeden ne3D vrchol.</param>
        public DimenzionalniFiltr(bool prisnyMod)
        {
            PrisnyMod = prisnyMod;
        }

        /// <summary>
        /// Odstrani pouze hrany,  jejichz oba vrcholy netvori 3D prostor. Normalne staci k odstraneni jeden ne3D vrchol.
        /// </summary>
        private bool PrisnyMod = false;

        public void FiltrovatPoSpojeni(HashSet<Usecka> hranyTelesa)
        {
                Dictionary<Bod, HranyVrcholu> vrcholy = NajitVrcholy(hranyTelesa);
                foreach (var vrchol in vrcholy)
                {
                    // dimenze je mensi jak 3, tedy vektory tvori rovinu
                    if ((!PrisnyMod  && vrchol.Value.dimenzeVrcholu < 3)
                        || (PrisnyMod && vrchol.Value.dimenzeRozsirenehoVrcholu < 3))
                    {
                        // odstranit vsechny hrany nalezici tomuto vrcholu
                        // ktere maji i druhy vrchol mensi dimenze nez 3
                        foreach (var hrana in vrchol.Value.hranyTvoriciVrchol)
                        {
                            if (PrisnyMod)
                            {
                                HranyVrcholu druhyVrchol;
                                if (vrchol.Key == hrana.A)
                                    druhyVrchol = vrcholy[hrana.B];
                                else
                                    druhyVrchol = vrcholy[hrana.A];

                                if (druhyVrchol.dimenzeRozsirenehoVrcholu < 3)
                                    hranyTelesa.Remove(hrana);
                            }
                            else
                            {
                                hranyTelesa.Remove(hrana);
                            }
                        }
                    }
                }

        }

        /// <summary>
        /// zapouzdruje hrany, kterou jsou soucasti vrcholu a dimenzi nimi tvoreneho prostoru
        /// </summary>
        class HranyVrcholu
        {
            public LinkedList<Usecka> hranyTvoriciVrchol;

            public LinkedList<Usecka> hranyProchazejiciVrcholem;

            /// <summary>
            /// dimenze prostoru tvoreneho vektory hran ktere jsou soucasti vrcholu
            /// </summary>
            public int dimenzeVrcholu;


            /// <summary>
            /// dimeneze prostoru rozsirena o vektory hran, ktere vrcholem prochazeji
            /// </summary>
            public int dimenzeRozsirenehoVrcholu;

            public HranyVrcholu()
            {
                hranyTvoriciVrchol = new LinkedList<Usecka>();
                hranyProchazejiciVrcholem = new LinkedList<Usecka>();
            }


            /// <summary>
            /// Spocita dimenzi prostoru tvoreneho hranamy vrcholu
            /// </summary>
            public void SpocitatDimenzi()
            {
                Matice baze = new Matice(3, hranyTvoriciVrchol.Count);
                int i = 0;
                foreach (var hrana in hranyTvoriciVrchol)
                {
                    baze.Naplnit(hrana.Smernice, i++);
                }
                baze.GaussovaEliminace();
                dimenzeVrcholu =  baze.NenulovychRadku();

                // dimenze rozsirena o hrany prochazejici vrcholem
                baze = new Matice(3, hranyTvoriciVrchol.Count + hranyProchazejiciVrcholem.Count);
                i = 0;
                foreach (var hrana in hranyTvoriciVrchol)
                {
                    baze.Naplnit(hrana.Smernice, i++);
                }
                foreach (var hrana in hranyProchazejiciVrcholem)
                {
                    baze.Naplnit(hrana.Smernice, i++);
                }
                baze.GaussovaEliminace();
                dimenzeRozsirenehoVrcholu = baze.NenulovychRadku();
            }

            public void PridatHranuVrcholu(Usecka u)
            {
                hranyTvoriciVrchol.AddLast(u);
            }
        }

        private Dictionary<Bod, HranyVrcholu> NajitVrcholy(IEnumerable<Usecka> hrany)
        {
            Dictionary<Bod, HranyVrcholu> vrcholyHran = new Dictionary<Bod, HranyVrcholu>();

            // najit vrcholy
            foreach (var hrana in hrany)
            {
                if (vrcholyHran.ContainsKey(hrana.A))
                {
                    vrcholyHran[hrana.A].PridatHranuVrcholu(hrana);
                }
                else
                {
                    HranyVrcholu novy = new HranyVrcholu();
                    novy.PridatHranuVrcholu(hrana);
                    vrcholyHran.Add(hrana.A, novy);
                }

                if (vrcholyHran.ContainsKey(hrana.B))
                {
                    vrcholyHran[hrana.B].PridatHranuVrcholu(hrana);
                }
                else
                {
                    HranyVrcholu novy = new HranyVrcholu();
                    novy.PridatHranuVrcholu(hrana);
                    vrcholyHran.Add(hrana.B, novy);
                }
            }

            // najit hrany prochazejici vrcholy
            foreach (var hrana in hrany )
            {
                foreach (var vrchol in vrcholyHran)
                {
                    // je to hrana vrcholu?
                    if (hrana.A == vrchol.Key || hrana.B == vrchol.Key)
                        continue;

                    // lezi vrchol na hrane?
                    if (hrana.LeziNaUsecce(vrchol.Key, 10e-4f))
                    {
                        vrchol.Value.hranyProchazejiciVrcholem.AddLast(hrana);
                    }
                }
            }

            foreach (var vrchol in vrcholyHran)
            {
                vrchol.Value.SpocitatDimenzi();
            }

            return vrcholyHran;
        }

        public void FiltrovatPredSpojenim(HashSet<Usecka> hranyTelesa)
        {
        }

    }
}
