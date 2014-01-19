using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor.ProstoroveObjekty;

namespace LibRekonstruktor.Algebra
{
    /// <summary>
    /// Typ výsledku řešení soustavy rovnic
    /// </summary>
    public enum ReseniSoustavy
    {
        /// <summary>
        /// Soustava rovnic nema zadne reseni
        /// </summary>
        NemaReseni,

        /// <summary>
        /// Soustava ma prave jedno reseni
        /// </summary>
        JednoznacneReseni,

        /// <summary>
        /// Soustava ma nekonecno reseni (hodnost matice je mensi jak pocet rovnic)
        /// </summary>
        NejednoznacneReseni
    }

    /// <summary>
    /// Reprezentuje aritmetickou matici, standartni operace s maticemi a reseni soustav pomoci Gaussovy eliminacni metody.
    /// </summary>
    public class Matice : IComparer<float[]>
    {
        private float[][] matice;

        private int m, n;

        /// <summary>
        /// Pocet radku matice
        /// </summary>
        public int Rows { get { return m; } }

        /// <summary>
        /// Pocet sloupcu matice
        /// </summary>
        public int Columns { get { return n; } }
        
        /// <summary>
        /// Slozky matice
        /// </summary>
        /// <param name="i">Index radku</param>
        /// <param name="j">Index sloupce</param>
        /// <returns>Hodnotu matice na pozici [i,j]</returns>
        public float this[int i, int j]
        {
            get { return matice[i][j]; }
            set { matice[i][j] = value; }
        }


        public Matice(int rows, int cols)
        {
            matice = new float[rows][];

            for (int i = 0; i < rows; i++)
            {
                matice[i] = new float[cols];
            }

            m = rows; n = cols;
        }

        public Matice(Souradnice s1, Souradnice s2, Souradnice p)
        {
            matice = new float[3][] {
                new float[3] { s1.X, s2.X, p.X},
                new float[3] { s1.Y, s2.Y, p.Y },
                new float[3] { s1.Z, s2.Z, p.Z }};
            n = m = 3;
        }

        public Matice(IEnumerable<Souradnice> sloupce)
            : this(3, sloupce.Count())
        {
            int j = 0;
            foreach (var vektor in sloupce)
            {
                matice[0][j] = vektor.X;
                matice[1][j] = vektor.Y;
                matice[2][j] = vektor.Z;
                j++;
            }
        }

        public void Naplnit(float[,] data)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matice[i][j] = data[i, j];
                }
            }
        }

        public void Naplnit(Souradnice s1, Souradnice s2, Souradnice p)
        {
            if (m != 3 || n != 3)
            {
                throw new InvalidOperationException("Matice neni rozmeru 3x3");
            }

            matice[0][0] = s1.X; matice[0][1] = s2.X; matice[0][2] = p.X;
            matice[1][0] = s1.Y; matice[1][1] = s2.Y; matice[1][2] = p.Y;
            matice[2][0] = s1.Z; matice[2][1] = s2.Z; matice[2][2] = p.Z;
        }

        public void Naplnit(Souradnice s1, Souradnice s2, Souradnice p1, Souradnice p2)
        {
            if (m != 3 || n != 4)
            {
                throw new InvalidOperationException("Matice neni rozmeru 3x4");
            }

            matice[0][0] = s1.X; matice[0][1] = s2.X; matice[0][2] = p1.X; matice[0][3] = p2.X;
            matice[1][0] = s1.Y; matice[1][1] = s2.Y; matice[1][2] = p1.Y; matice[1][3] = p2.Y;
            matice[2][0] = s1.Z; matice[2][1] = s2.Z; matice[2][2] = p1.Z; matice[2][3] = p2.Z;
        }

        public void Naplnit(IEnumerable<Souradnice> sloupce)
        {
            if (m != 3 || n != sloupce.Count())
                throw new InvalidOperationException("Matice neni rozmeru");

            int j = 0;
            foreach (var vektor in sloupce)
            {
                matice[0][j] = vektor.X;
                matice[1][j] = vektor.Y;
                matice[2][j] = vektor.Z;
                j++;
            }
        }

        /// <summary>
        /// Vlozi na urceny sloupec predany vektor
        /// </summary>
        /// <param name="v">Vektor sloupce</param>
        /// <param name="sloupec">Index sloupce</param>
        /// <exception cref="IndexOutOfRangeException">Pozadovany sloupec neni v matici</exception>
        public void Naplnit(Vektor v, int sloupec)
        {
            matice[0][sloupec] = v.X;
            matice[1][sloupec] = v.Y;
            matice[2][sloupec] = v.Z;
        }

        /// <summary>
        /// Pocet nenulovych radku. Po provedeni gauss. eliminice se hodnota rovna hodnosti matice.
        /// </summary>
        /// <returns></returns>
        public int NenulovychRadku()
        {
            int pocet = m;

            for (int i = 0; i < m; i++)
            {
                if (Pivot(i) == n)
                    pocet--;                
            }

            return pocet;
        }
 

        /// <summary>
        /// Seradi radky podle poctu nul
        /// </summary>
        /// <param name="odRadku">Seradi pouze radky od tohoto radku</param>
        public void Odstupnovat(int odRadku)
        {
            Array.Sort<float[]>(matice, odRadku, Rows-odRadku, this);
        }

        /// <summary>
        /// Zjisti sloupec pivota v radku (tj prvni nenulovy sloupec z leva)
        /// </summary>
        /// <param name="p">Radek ve kterem pocita nuly</param>
        /// <returns>Index sloupce pivota. Jeli rovno poctu sloupcu, pivot neexistuje</returns>
        public int Pivot(int p)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (matice[p][i] != 0)
                    return i;
            }
            return Columns;
        }

        /// <summary>
        /// Pouzije Gaussovu eliminacni metodu na prevedeni matice do odstupnovaneho tvaru
        /// </summary>
        public void GaussovaEliminace()
        {
            // Gaussova eliminace
            Odstupnovat(0);

            // pro kazdy sloupec 'j'
            for (int j = 0; j < Columns - 1; j++)
            {
                // kdyz ve sloupci 'j' neni radek s diagonalou, konec
                if (j >= Rows) break;

                // vem hodnotu na diagonale
                float nasobekEliminacniho = this[j, j];

                // a pro kazdy radek 'i' pod ni
                for (int i = j + 1; i < Rows; i++)
                {
                    // vem hodnotu v sloupci 'j'
                    float nasobekEliminovaneho = this[i, j];

                    // nema smysl eliminovat nulu
                    if (nasobekEliminovaneho == 0)
                        continue;

                    // a pro kazdy sloupec 'y' v radku 'i'
                    for (int y = 0; y < Columns; y++)
                    {
                        // odecti
                        this[i, y] = this[i, y] * nasobekEliminacniho - this[j, y] * nasobekEliminovaneho;
                        if ((this[i, y] > 0 && this[i, y] < 10e-5f) || (this[i, y] < 0 && this[i, y] > -10e-5f))
                            this[i, y] = 0;
                    }
                }

                // mozna by slo efektivneji - zjistit jake radky je potreba prehodit
                // ale urcite to jsou jen radky pod aktualnim
                this.Odstupnovat(j + 1);
            }
        }

        /// <summary>
        /// Pouzije Jordanovu upravu na ziskani reseni soustavy rovnic zadane maatici
        /// </summary>
        /// <param name="soustava">Nastavi na TRUE, pokud ma soustava reseni, FALSE pokud reseni soustavy neexistuje.</param>
        public void JordanovaUprava(out bool soustava)
        {
            // Jordanova uprava

            soustava = true;

            // pro vsechny radky odspodu
            for (
                int i = Rows - 1;
                i >= 0;
                i--)
            {
                // prvni nenulovy sloupec
                int j = Pivot(i);

                // nemozne reseni (pivot v sloupci pravych stran)
                if (soustava && (j == Columns - 1))
                {
                    soustava = false;
                    //return;
                }

                // prazdny radek
                if (j >= Columns)
                    continue;

                // hodnota prvniho nenuloveho sloupce
                float nasobekNormalizacniho = this[i, j];

                // "normalizovat" radek - dostat 1 v prvnim nenulovem sloupci - vydelit cely radek prvnim nenulovym sloupcem
                for (int q = j; q < Columns; q++)
                {
                    this[i, q] /= nasobekNormalizacniho;
                    if ((this[i, q] > 0 && this[i, q] < 10e-5f) || (this[i, q] < 0 && this[i, q] > -10e-5f))
                        this[i, q] = 0;
                }

                // pro kazdy radek nad timto
                for (int y = i - 1; y >= 0; y--)
                {
                    // vem hodnotu v normalizovanem sloupci
                    nasobekNormalizacniho = this[y, j];

                    // pro kazdy sloupec vpravo od normalizovaneho, vcetne
                    for (int q = j; q < Columns; q++)
                    {
                        // odecist nasobek hodnoty ve stejnem sloupci radku 'i'
                        this[y, q] -= this[i, q] * nasobekNormalizacniho;
                        if ((this[y, q] > 0 && this[y, q] < 10e-5f) || (this[y, q] < 0 && this[y, q] > -10e-5f))
                            this[y, q] = 0;
                    }
                }
            }
        }


        /// <summary>
        /// Vyresi soustavu rovnic matice pomoci Gauss-Jordanovi eliminacni metody
        /// </summary>
        public ReseniSoustavy VyresitSoustavu()
        {
            GaussovaEliminace();

            bool reseni;
            JordanovaUprava(out reseni);
            if (reseni == false)
                return ReseniSoustavy.NemaReseni;

            if (NenulovychRadku() < m)
                return ReseniSoustavy.NejednoznacneReseni;
            else
                return ReseniSoustavy.JednoznacneReseni;
        }


        int IComparer<float[]>.Compare(float[] a, float[] b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException("Radky musi byt stejne dlouhe");

            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i] == b[i]) && b[i] == 0)
                    continue;
                else if (b[i] == 0)
                    return -1;
                else if (a[i] == 0)
                    return 1;
                else
                    return 0;
            }

            return 0;
        }

        /// <summary>
        /// Nastavi na digaonalnich prvcich mnoziny hodnotu 1 a na ostanich 0.
        /// </summary>
        public void NastavIdentitu()
        {
            if (m != n)
                throw new InvalidOperationException("Identitu lze nastavit jen ctvercove matici");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    this[i, j] = (i == j) ? 1 : 0;
                }
            }
        }

        static public Matice operator *(Matice a, Matice b)
        {
            if (a.n != b.m)
                throw new ArithmeticException("Nelze vynasobit");

            Matice v = new Matice(a.m, b.n);

            for (int i = 0; i < v.m; i++)
            {
                for (int j = 0; j < v.n; j++)
                {
                    v[i, j] = 0;
                    for (int z = 0; z < a.n; z++)
                    {
                        v[i, j] += a[i, z] * b[z, j];
                    }
                }
            }

            return v;
        }

        static public Bod operator *(Matice a, Souradnice b)
        {
            if (a.n != 3 || a.m > 3)
                throw new ArithmeticException("Nelze vynasobit");

            Bod v = new Bod();

            v.X += b.X * a[0, 0] + b.Y * a[0, 1] + b.Z * a[0, 2];
            if (a.m >= 2)            
                v.Y += b.X * a[1, 0] + b.Y * a[1, 1] + b.Z * a[1, 2];
            if (a.m == 3)
                v.Z += b.X * a[2, 0] + b.Y * a[2, 1] + b.Z * a[2, 2];

            return v;
        }
    }
}
