using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;

namespace LibRekonstruktor.Filtry
{

    /// <summary>
    /// EXPERIMENTALNI!! Filtr hran, ktery odstrani hrany, jejich vrcholy jsou soucasti mene jak 2 rovin.
    /// </summary>
    public class NormalovyFiltr : IFiltrHran
    {

        public void FiltrovatPoSpojeni(HashSet<Usecka> hranyTelesa)
        {
            Dictionary<Bod, LinkedList<Usecka>> vrcholy = NajitVrcholy(hranyTelesa);

            Dictionary<Usecka, NormalyHrany> normalyHran = new Dictionary<Usecka, NormalyHrany>();

            foreach (var vrchol in vrcholy)
            {
                // pro vsechny dvojice hran ve vrcholu spocitat normalu roviny jimy tvorenou
                LinkedListNode<Usecka> hrana1 = vrchol.Value.First;
                while (hrana1 != null)
                {
                    if (!normalyHran.ContainsKey(hrana1.Value))
                    {
                        normalyHran[hrana1.Value] = new NormalyHrany();
                    }

                    LinkedListNode<Usecka> hrana2 = hrana1.Next;
                    while (hrana2 != null)
                    {
                        Vektor normala = (hrana1.Value.Smernice * hrana2.Value.Smernice).Jednotkovy();



                        if (!normalyHran.ContainsKey(hrana2.Value))
                        {
                            normalyHran[hrana2.Value ] = new NormalyHrany();
                        }

                        if (vrchol.Key == hrana1.Value.A)
                            normalyHran[hrana1.Value].normalyA.Add(normala);
                        else
                            normalyHran[hrana1.Value].normalyB.Add(normala);

                        if (vrchol.Key == hrana2.Value.A)
                            normalyHran[hrana2.Value].normalyA.Add(normala);
                        else
                            normalyHran[hrana2.Value].normalyB.Add(normala);

                        hrana2 = hrana2.Next;
                    }
                    hrana1 = hrana1.Next;
                }
   
            }

            // prunik normal jednotlivich vrcholu u vsech hran
            foreach (var hrana in normalyHran)
            {
                // jeli prunik vetsi jak 1 normala, m
                if (hrana.Value.VelikostPruniku() < 2)
                {
                    hranyTelesa.Remove(hrana.Key);
                }
            }

        }

        class NormalyHrany
        {
            public NormalyHrany()
            {
                normalyA = new HashSet<Vektor>();
                normalyB = new HashSet<Vektor>();
            }

            public HashSet<Vektor> normalyA, normalyB;

            public int VelikostPruniku()
            {
                HashSet<Vektor> prunik = new HashSet<Vektor>();
                prunik.UnionWith(normalyA);
                prunik.UnionWith(normalyB);
                return prunik.Count;
            }
        }

        private Dictionary<Bod, LinkedList<Usecka>> NajitVrcholy(IEnumerable<Usecka> hrany)
        {
            Dictionary<Bod, LinkedList<Usecka>> vrcholyHran = new Dictionary<Bod, LinkedList<Usecka>>();

            // najit vrcholy
            foreach (var hrana in hrany)
            {
                PridatHranuDoVrcholu(vrcholyHran, hrana.A, hrana);
                PridatHranuDoVrcholu(vrcholyHran, hrana.B, hrana);
            }

            return vrcholyHran;
        }

        private void PridatHranuDoVrcholu(Dictionary<Bod, LinkedList<Usecka>> vrcholy, Bod bodHrany, Usecka hrana)
        {
            if (vrcholy.ContainsKey(bodHrany))
            {
                vrcholy[bodHrany].AddLast(hrana);
            }
            else
            {
                LinkedList<Usecka> nova = new LinkedList<Usecka>();
                nova.AddLast(hrana);
                vrcholy.Add(bodHrany, nova);
            }
        }


        public void FiltrovatPredSpojenim(HashSet<Usecka> hranyTelesa)
        {
            
        }

    }
}
