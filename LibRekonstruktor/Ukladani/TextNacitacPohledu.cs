using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LibRekonstruktor.ProstoroveObjekty;

namespace LibRekonstruktor.Ukladani
{
    /// <summary>
    /// Nacita pohledu ulozeny v textovem foramtu pomoci TextUkladacPohledu
    /// </summary>
    public class TextNacitacPohledu
    {
        TextReader reader;

        public TextNacitacPohledu(TextReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();

            this.reader = reader;
        }

        /// <summary>
        /// Uzavre vnitrni popisovac soubou
        /// </summary>
        public void Close()
        {
            this.reader.Close();
        }

        /// <summary>
        /// Nacte vsechny pohledy v souboru
        /// </summary>
        /// <exception cref="InvalidDataException">Spatny format soubor</exception>
        /// <returns>Pole pohledu</returns>
        public Vykres NacistPohledy()
        {
            Vykres vykres = new Vykres();

            Pohled pohled;
            while ((pohled = NacistPohled()) != null)
            {
                vykres.pohledy.Add(pohled);
            }

            return vykres;

        }

        /// <summary>
        /// Nacte nasledujici pohled
        /// </summary>
        /// <exception cref="InvalidDataException">Spatny format soubor</exception>
        /// <returns>Instanci pohledu nebo null, pokud dalsi neni</returns>
        public Pohled NacistPohled()
        {
            Pohled pohled = null;

            if (PreskocitPrazdno())
            {
                if ((char)reader.Peek() != '[')
                    throw new InvalidDataException("Ocekavano [");

                // precist [
                reader.Read();
            }
            else
                return null;


            Vektor vektorX, vektorY;
            NacistDvojicSouradnic3D(out vektorX, out vektorY);

            pohled = new Pohled(vektorX, vektorY);

            Bod a, b;
            while (!Nasleduje(']'))
            {
                NacistDvojiciSouradnic2D(out a, out b);
                pohled.Usecky.AddLast(new Usecka(a, b));
            }

            if (PosunoutNaPrvni(']'))
            {
                reader.Read();
            }
            else
            {
                throw new InvalidDataException("Ocekavano ]");
            }

            return pohled;
        }

        /// <summary>
        /// Posune ukazatel na prvni vyskyt znaku.
        /// </summary>
        /// <param name="znak"></param>
        /// <returns>True, kdyz nenarazi na konec</returns>
        private bool PosunoutNaPrvni(char znak)
        {
            int peek;
            while ((peek = reader.Peek()) != -1 && (char)peek != znak)
            {
                reader.Read();
            }
            return peek != -1;
        }

        /// <summary>
        /// Preskoci bile znaky
        /// </summary>
        /// <returns>TRUE kdyz nezkonci na konci</returns>
        private bool PreskocitPrazdno()
        {
            int peek;
            while ((peek = reader.Peek()) != -1 && Char.IsWhiteSpace((char)peek))
            {
                reader.Read();
            }
            return peek != -1;
        }

        /// <summary>
        /// Posune na dalsi nebily znak a porovna zda se shoduje
        /// </summary>
        /// <param name="znak"></param>
        /// <returns>TRUE kdyz je nasledujici znak shodny s parametrem a FALSE kdyz je konec nebo jiny znak</returns>
        bool Nasleduje(char znak)
        {
            return PreskocitPrazdno() && (char)reader.Peek() == znak;
        }


        private void NacistDvojiciSouradnic2D(out Bod a, out Bod b)
        {
            if (!Nasleduje('{'))
            {
                throw new InvalidDataException("Ocekavano {");
            }

            reader.Read();

            a = new Bod(PrecistCislo(), PrecistCislo(), 0);
            if (!Nasleduje(';'))
                throw new InvalidDataException("Ocekavano ;");
            reader.Read();
            b = new Bod(PrecistCislo(), PrecistCislo(), 0);
            if (Nasleduje('}'))
            {
                reader.Read();
                return;
            }
            else
            {
                throw new InvalidDataException("Ocekavano }");
            }
        }

        private void NacistDvojicSouradnic3D(out Vektor a, out Vektor b)
        {
            if (!Nasleduje('{'))
            {
                throw new InvalidDataException("Ocekavano {");
            }
            reader.Read();

            a = new Vektor(PrecistCislo(), PrecistCislo(), PrecistCislo());
            if (!Nasleduje(';'))
                throw new InvalidDataException("Ocekavano ;");
            reader.Read();
            b = new Vektor(PrecistCislo(), PrecistCislo(), PrecistCislo());
            if (Nasleduje('}'))
            {
                reader.Read();
                return;
            }
            else
            {
                throw new InvalidDataException("Ocekavano }");
            }
        }

        private float PrecistCislo()
        {
            int peek;

            // posunout na zacatek cisla
            while ((peek = reader.Peek()) != -1 && !(Char.IsDigit((char)peek) || (char)peek == '-'))
            {
                reader.Read();
            }
            // konec souboru
            if (peek == -1)
                throw new InvalidDataException("Ocekavano cislo");

            string cislo = "";
            while ((peek = reader.Peek()) != -1)
            {
                char znak = (char)peek;
                if (char.IsDigit(znak) || znak == 'E' || znak == 'e' || znak == '+' || znak == '-' || znak == '.')
                {
                    cislo += znak;
                    reader.Read();
                }
                else
                {
                    break;
                }
            }

            try
            {
                return float.Parse(cislo, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
                throw new InvalidDataException("Cislo neni ve spravnem formatu");
            }
            
        }


    }
}
