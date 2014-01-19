using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;
using LibRekonstruktor.Algebra;

namespace LibRekonstruktor
{
    /// <summary>
    /// Reprezentuje sadu pohledů, které tvoří výkres tělesa.
    /// </summary>
    public class Vykres : IEnumerable<Pohled>
    {

        internal List<Pohled> pohledy;

        public Vykres()
        {
            pohledy = new List<Pohled>(3);
        }

        /// <summary>
        /// Prida instanci pohledu do nakresu. Pokud pohled se stejnou orientaci jiz existuje, vyhodi vyjimku.
        /// Timto se zaruci, ze kazde 2 pohledy nakresu budou tvorit nejaky 3D prostor.
        /// </summary>
        /// <exception cref="InvalidOperationException">Pokud pohled s pozadovanou orientaci jiz existuje</exception>
        /// <param name="pohled">Instance pohledu, ktera se prida do nakresu</param>
        /// <returns>Index vlozeneho pohledu</returns>
        public int VlozitPohled(Pohled pohled)
        {
            if (IndexPohledu(pohled) != -1)
                throw new InvalidOperationException("Vkladany pohled jiz existuje");

            pohledy.Add(pohled);
            return pohledy.Count - 1;
        }

        /// <summary>
        /// Vlozi novy pohled nebo prepise jiny, se stejnou orientaci
        /// </summary>
        /// <param name="pohled"></param>
        /// <returns></returns>
        public int VLozitNeboNahraditPohled(Pohled pohled)
        {
            int index;
            if ((index = IndexPohledu(pohled)) != -1)
            {
                pohledy[index] = pohled;
                return index;
            }

            pohledy.Add(pohled);
            return pohledy.Count - 1;
        }

        /// <summary>
        /// Pocet pohledu
        /// </summary>
        public int Pocet
        {
            get { return pohledy.Count; }
        }

        /// <summary>
        /// Najde pohled se stejnou orientaci a vrati jeho index. Pokud nenajde vrati -1.
        /// </summary>
        /// <param name="pohled">Pohled, jehoz orientace se bude hledat ve vykresu</param>
        /// <returns>Index pohledu, pokud existuje, -1 pokud neexistuje pohled se stejnou orientaci</returns>
        public int IndexPohledu(Pohled pohled)
        {
            for (int i = 0; i < pohledy.Count; i++)
            {
                if (Vektor.Rovnobezne(pohled.NormalaRovinyPohledu, pohledy[i].NormalaRovinyPohledu))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Pristup k pohledum vykresu pomoci typ pohledu.
        /// </summary>
        /// <param name="jmeno">Typ pohledu</param>
        /// <exception cref="ArgumentOutOfRangeException">Vyhodi vyjimku pokud je pozadovan typ Neznamy.</exception>
        /// <returns>Instanci pohledu nebo null, pokud pozadovany pohled neni soucasti vykresu</returns>
        public Pohled this[Pohled.PojmenovanePohledy jmeno]
        {
            get
            {
                if (jmeno == Pohled.PojmenovanePohledy.Neznamy)
                    throw new ArgumentOutOfRangeException();

                foreach (Pohled pohled in pohledy)
                {
                    if (pohled.Pojmenovany == jmeno)
                        return pohled;
                }

                return null;
            }
        }

        /// <summary>
        /// Prisutp k pohledu pres index.
        /// </summary>
        /// <param name="index">index pohledu</param>
        /// <returns>Pohled</returns>
        public Pohled this[int index]
        {
            get
            {
                return pohledy[index];
            }
        }




        #region IEnumerable<Pohled> Members

        public class VykresEnumerator : IEnumerator<Pohled>
        {
            private Vykres vykres;
            public VykresEnumerator(Vykres v)
            {
                if (v == null)
                    throw new ArgumentNullException();

                vykres = v;
                aktualniIndex = -1;
            }

            int aktualniIndex;


            #region IEnumerator<Pohled> Members

            public Pohled Current
            {
                get { throw new NotImplementedException(); }
            }

            #endregion

            #region IDisposable Members

            public void Dispose()
            {
                vykres = null;
            }

            #endregion

            #region IEnumerator Members

            object System.Collections.IEnumerator.Current
            {
                get { return vykres[aktualniIndex]; }
            }

            public bool MoveNext()
            {
                if (aktualniIndex == vykres.Pocet - 1)
                    return false;
                aktualniIndex++;
                return true;
            }

            public void Reset()
            {
                aktualniIndex = -1;
            }

            #endregion
        }

        public IEnumerator<Pohled> GetEnumerator()
        {
            return new VykresEnumerator(this);
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
