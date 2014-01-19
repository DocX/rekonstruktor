using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibRekonstruktor;
using System.IO;
using LibRekonstruktor.Ukladani;
using LibRekonstruktor.Filtry;

namespace RekonstruktorCLI
{
    class Program
    {
        static string souborNakresu, souborVystupu;

        static bool filtrovat;

        static void Main(string[] args)
        {
            try
            {
                if (!ParsovatParametry(args))
                    return;

                Vykres nakres = NacistVykres();
                
                Rekonstruktor rekonstruktor = new Rekonstruktor();
                if (filtrovat)
                    rekonstruktor.Filtr = new DimenzionalniFiltr(true);

                Rekonstrukce rekonstrukce = rekonstruktor.Rekonstruovat(nakres);

                UlozitDratenyModel(rekonstrukce.HranyTelesa);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Chyba: " + ex.Message);

                return;
            }
        }

        private static void UlozitDratenyModel(LibRekonstruktor.ProstoroveObjekty.Usecka[] hrany)
        {
            TextWriter vystup;
            if (souborVystupu == null)
            {
                vystup = Console.Out;
            }
            else
            {
                vystup = new StreamWriter(new FileStream(souborVystupu, FileMode.Create, FileAccess.Write, FileShare.Read));
            }

            TextUkladacDratenyModel ukladac = new TextUkladacDratenyModel(vystup);
            ukladac.ZapsatHranu(hrany);
            ukladac.Close();
        }

        private static Vykres NacistVykres()
        {
            TextNacitacPohledu nacitac = new TextNacitacPohledu(
                new StreamReader(
                new FileStream(souborNakresu, FileMode.Open, FileAccess.Read, FileShare.Read))
                );

            Vykres nakres = nacitac.NacistPohledy();
            nacitac.Close();

            return nakres;
        }

        static void Napoveda()
        {
            Console.WriteLine(Properties.Resources.HelpText);
        }

        static bool ParsovatParametry(string[] args)
        {
            if (args.Length == 0 || (args.Length >= 1 && args[0] == "/?"))
            {
                Napoveda();

                return false;
            }

            int argsZero = 0;

            if (args[0] == "/filter")
            {
                filtrovat = true;
                argsZero = 1;
            }

            if (args.Length >= 1 + argsZero)
            {
                // jen soubor vstupu
                souborNakresu = args[argsZero];
            }
            else
            {
                // spatne
                throw new Exception("Nespravne parametry. Pouzijte /? pro napovedu.");
            }

            if (args.Length >= 2 + argsZero)
            {
                // je i soubor vystupu
                souborVystupu = args[1 + argsZero];
            }
            else
            {
                souborVystupu = null;
            }

            return true;
        }
    }
}
