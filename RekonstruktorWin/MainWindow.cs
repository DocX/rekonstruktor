using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibRekonstruktor.ProstoroveObjekty;
using LibRekonstruktor.Algebra;
using LibRekonstruktor;
using RekonstruktorWin.Controls;
using LibRekonstruktor.Ukladani;
using System.IO;

namespace RekonstruktorWin
{
    public partial class MainWindow : Form
    {
        Vykres nakres;

        Rekonstruktor rekonstruktor;

        public MainWindow()
        {
            InitializeComponent();

            drawerShora.Pohled = new Pohled(Pohled.PojmenovanePohledy.Shora);
            drawerZepredu.Pohled = new Pohled(Pohled.PojmenovanePohledy.Zepredu);
            drawerZprava.Pohled = new Pohled(Pohled.PojmenovanePohledy.Zprava);

            nakres = new Vykres();
            nakres.VlozitPohled(drawerShora.Pohled);
            nakres.VlozitPohled(drawerZepredu.Pohled);
            nakres.VlozitPohled(drawerZprava.Pohled);

            rekonstruktor = new Rekonstruktor();

            pohledDratenehoModelu.NastavitPohled(RekonstruktorWin.Components.IsometricView.Pohledy.SW);
        }

        private void drawer1_PosunZmenen(object sender, EventArgs e)
        {
            if (drawerZepredu.Posun.Width == drawerShora.Posun.Width)
                return;

            SizeF posun2 = drawerZepredu.Posun;
            posun2.Width = drawerShora.Posun.Width;
            drawerZepredu.Posun = posun2;
        }

        private void drawer2_PosunZmenen(object sender, EventArgs e)
        {
            if (drawerZepredu.Posun.Width != drawerShora.Posun.Width)
            {
                SizeF posun1 = drawerShora.Posun;
                posun1.Width = drawerZepredu.Posun.Width;
                drawerShora.Posun = posun1;
            }
            if (drawerZepredu.Posun.Height != drawerZprava.Posun.Height)
            {
                SizeF posun = drawerZprava.Posun;
                posun.Height = drawerZepredu.Posun.Height;
                drawerZprava.Posun = posun;
            }
        }

        private void drawer3_PosunZmenen(object sender, EventArgs e)
        {
            if (drawerZepredu.Posun.Height != drawerZprava.Posun.Height)
            {
                SizeF posun = drawerZepredu.Posun;
                posun.Height = drawerZprava.Posun.Height;
                drawerZepredu.Posun = posun;
            }
        }

        private void drawer1_MeritkoZmeneno(object sender, EventArgs e)
        {
            if (drawerShora.MeritkoZobrazeni != drawerZepredu.MeritkoZobrazeni)
                drawerZepredu.MeritkoZobrazeni = drawerShora.MeritkoZobrazeni;
            if (drawerShora.MeritkoZobrazeni != drawerZprava.MeritkoZobrazeni)
                drawerZprava.MeritkoZobrazeni = drawerShora.MeritkoZobrazeni;

        }

        private void drawer2_MeritkoZmeneno(object sender, EventArgs e)
        {
            if (drawerZepredu.MeritkoZobrazeni != drawerShora.MeritkoZobrazeni)
                drawerShora.MeritkoZobrazeni = drawerZepredu.MeritkoZobrazeni;
            if (drawerZepredu.MeritkoZobrazeni != drawerZprava.MeritkoZobrazeni)
                drawerZprava.MeritkoZobrazeni = drawerZepredu.MeritkoZobrazeni;
        }

        private void drawer3_MeritkoZmeneno(object sender, EventArgs e)
        {
            if (drawerZprava.MeritkoZobrazeni != drawerShora.MeritkoZobrazeni)
                drawerShora.MeritkoZobrazeni = drawerZprava.MeritkoZobrazeni;
            if (drawerZprava.MeritkoZobrazeni != drawerZepredu.MeritkoZobrazeni)
                drawerZepredu.MeritkoZobrazeni = drawerZprava.MeritkoZobrazeni;
 
        }

        private void drawers_UseckaPridana(object sender, RekonstruktorWin.Controls.Drawer.NewLineEventArgs e)
        {
            pridanaUsecka();
        }

        Rekonstrukce posledniRekonstrukce;

        void aktualizovatPromitnutiHran()
        {
            if (checkBoxProjection.Checked)
            {
                drawerShora.PomocneCary["zleva"] = drawerShora.Pohled.PromitnoutNaRovinuPohledu(drawerZprava.Pohled);
                drawerShora.PomocneCary["zepredu"] = drawerShora.Pohled.PromitnoutNaRovinuPohledu(drawerZepredu.Pohled);

                drawerZprava.PomocneCary["shora"] = drawerZprava.Pohled.PromitnoutNaRovinuPohledu(drawerShora.Pohled);
                drawerZprava.PomocneCary["zepredu"] = drawerZprava.Pohled.PromitnoutNaRovinuPohledu(drawerZepredu.Pohled);

                drawerZepredu.PomocneCary["zleva"] = drawerZepredu.Pohled.PromitnoutNaRovinuPohledu(drawerZprava.Pohled);
                drawerZepredu.PomocneCary["shora"] = drawerZepredu.Pohled.PromitnoutNaRovinuPohledu(drawerShora.Pohled);
            }

            drawerShora.ZobrazitPomocneCary = checkBoxProjection.Checked;
            drawerZepredu.ZobrazitPomocneCary = checkBoxProjection.Checked;
            drawerZprava.ZobrazitPomocneCary = checkBoxProjection.Checked;
        }
        
        private void pridanaUsecka()
        {

            if (!automatickyToolStripMenuItem.Checked)
                return; 

            rekonstruovat();
            // pokud jsou zapnuty pomocne cary, vykreslit
            aktualizovatPromitnutiHran();
        }

        private void rekonstruovat()
        {
            posledniRekonstrukce = rekonstruktor.Rekonstruovat(nakres);

            pohledDratenehoModelu.HlavniUsecky = posledniRekonstrukce.HranyTelesa;
            if (checkBoxVsechnyPrusecnice.Checked)
                pohledDratenehoModelu.PomocneUsecky = posledniRekonstrukce.PrunikyRovin;
            else
                pohledDratenehoModelu.PomocneUsecky = new Usecka[0];

            exportovat3DToolStripMenuItem.Enabled = true;
        }

        void vycistit()
        {
            drawerShora.Pohled = new Pohled(Pohled.PojmenovanePohledy.Shora);
            drawerZepredu.Pohled = new Pohled(Pohled.PojmenovanePohledy.Zepredu);
            drawerZprava.Pohled = new Pohled(Pohled.PojmenovanePohledy.Zprava);

            nakres = new Vykres();
            nakres.VlozitPohled(drawerShora.Pohled);
            nakres.VlozitPohled(drawerZepredu.Pohled);
            nakres.VlozitPohled(drawerZprava.Pohled);

            pridanaUsecka();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (posledniRekonstrukce.Empty)
                return;

            if (checkBoxVsechnyPrusecnice.Checked)
                pohledDratenehoModelu.PomocneUsecky = posledniRekonstrukce.PrunikyRovin;
            else
                pohledDratenehoModelu.PomocneUsecky = new Usecka[0];
        }

        private void drawer1_UseckaOdebrana(object sender, EventArgs e)
        {
            pridanaUsecka();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            drawerShora.PrichytavatKeMrizce = checkBoxStep.Checked;
            drawerZepredu.PrichytavatKeMrizce = checkBoxStep.Checked;
            drawerZprava.PrichytavatKeMrizce = checkBoxStep.Checked;
            
            drawerShora.ZobrazitMrizku = checkBoxGrid.Checked;
            drawerZepredu.ZobrazitMrizku = checkBoxGrid.Checked;
            drawerZprava.ZobrazitMrizku = checkBoxGrid.Checked;

            drawerShora.PrichytavatKUseckam = checkBoxSnap.Checked;
            drawerZepredu.PrichytavatKUseckam = checkBoxSnap.Checked;
            drawerZprava.PrichytavatKUseckam = checkBoxSnap.Checked;
        }

        private void drawerZleva_MouseMove(object sender, MouseEventArgs e)
        {
            StatusCoordinates.Text = (sender as Drawer).SouradniceKurzoru.ToString();
            Usecka podKurzorem = (sender as Drawer).UseckaPodKurzorem;
            if (podKurzorem != null)
            {
                StatusInfo.Text = "Čára " + podKurzorem.ToString();
            }
            else
            {
                drawerZleva_MouseEnter(sender, EventArgs.Empty);
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            drawerShora.ZobrazitKrizSouradnic = checkBoxCross.Checked;
            drawerZepredu.ZobrazitKrizSouradnic = checkBoxCross.Checked;
            drawerZprava.ZobrazitKrizSouradnic = checkBoxCross.Checked;
        }

        private void isometricView1_MouseEnter(object sender, EventArgs e)
        {
            if (!posledniRekonstrukce.Empty)
                StatusInfo.Text = "Počet hran: " + posledniRekonstrukce.HranyTelesa.Length.ToString() + "/" + posledniRekonstrukce.PrunikyRovin.Length.ToString();
        }

        private void drawerZleva_MouseEnter(object sender, EventArgs e)
        {
            Vektor normala = ((sender as Drawer).Pohled.NormalaRovinyPohledu);
            if (normala.Z == 1 && normala.X == 0 && normala.Y == 0)
                StatusInfo.Text = "Pohled shora";
            else if (normala.Z == 0 && normala.X == 0 && normala.Y == -1)
                StatusInfo.Text = "Pohled zepředu";
            else if (normala.Z == 0 && normala.X == -1 && normala.Y == 0)
                StatusInfo.Text = "Pohled zleva";
            else if (normala.Z == 0 && normala.X == 1 && normala.Y == 0)
                StatusInfo.Text = "Pohled zprava";
            else if (normala.Z == 0 && normala.X == 0 && normala.Y == 1)
                StatusInfo.Text = "Pohled zezadu";
            else if (normala.Z == -1 && normala.X == 0 && normala.Y == 0)
                StatusInfo.Text = "Pohled zdola";
            else
                StatusInfo.Text = "Pohled s normálou " + normala.ToString();
        }

        private void checkBox3DCross_CheckedChanged(object sender, EventArgs e)
        {
            pohledDratenehoModelu.ZobrazitKrizOs = checkBox3DCross.Checked;
        }

        private void drawerZepredu_MouseLeave(object sender, EventArgs e)
        {
            StatusInfo.Text = "Rekonstruktor by Lukáš Doležal";
        }

        private void checkBoxProjection_CheckedChanged(object sender, EventArgs e)
        {
            aktualizovatPromitnutiHran();
        }



        private void vyčistitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vycistit();
        }

        private void uložitJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NakresSaveDialog.ShowDialog() == DialogResult.OK)
            {

                TextUkladacPohledu ukladac = null;
                try
                {
                    ukladac = new TextUkladacPohledu(
                        new StreamWriter(NakresSaveDialog.FileName));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Soubor nelze otevřít",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ukladac.ZapsatPohled(nakres);
                    ukladac.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba při zápisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StatusInfo.Text = "nákres byl uložen do " + NakresSaveDialog.FileName;


            }
        }

        private void načístToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NakresOpenDialog.ShowDialog() == DialogResult.OK)
            {
                TextNacitacPohledu nacitac = null;
                try
                {
                    nacitac = new TextNacitacPohledu(
                        new StreamReader(NakresOpenDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Soubor nelze otevřít", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Vykres nactenyVykres;
                try
                {
                     nactenyVykres = nacitac.NacistPohledy();
                     nacitac.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba při čtení", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (nactenyVykres.Pocet > 3)
                {
                    if (MessageBox.Show("Načtený nákres má vice pohledů, než je možné zobrazit. Opravdu se má nákres načíst?", "Nepodporovaný nákres", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return;
                    }
                }

                nakres = nactenyVykres;

                drawerShora.Pohled = nactenyVykres[Pohled.PojmenovanePohledy.Shora];
                drawerZprava.Pohled = nactenyVykres[Pohled.PojmenovanePohledy.Zprava];
                drawerZepredu.Pohled = nactenyVykres[Pohled.PojmenovanePohledy.Zepredu];

                if(drawerShora.Pohled == null)
                {
                    MessageBox.Show("Pohled shora nebyl v nákresu nalezen");
                    drawerShora.Pohled = new Pohled(Pohled.PojmenovanePohledy.Shora);
                    nakres.VLozitNeboNahraditPohled(drawerShora.Pohled);
                }

                if (drawerZepredu.Pohled == null)
                {
                    MessageBox.Show("Pohled zepředu nebyl v nákresu nalezen");
                    drawerZepredu.Pohled = new Pohled(Pohled.PojmenovanePohledy.Zepredu);
                    nakres.VLozitNeboNahraditPohled(drawerZepredu.Pohled);
                }

                if (drawerZprava.Pohled == null)
                {
                    MessageBox.Show("Pohled zprava nebyl v nákresu nalezen");
                    drawerZprava.Pohled = new Pohled(Pohled.PojmenovanePohledy.Zprava);
                    nakres.VLozitNeboNahraditPohled(drawerZprava.Pohled);
                }

                rekonstruovat();

                StatusInfo.Text = "Byl načten nákres s " + nakres.Pocet.ToString() + " pohledy";

            }
        }

        private void exportovat3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (posledniRekonstrukce.Empty )
                return;

            if (ExportSaveDialog.ShowDialog() == DialogResult.OK)
            {
                TextUkladacDratenyModel ukladac = null;
                try
                {
                    ukladac = new TextUkladacDratenyModel(
                        new StreamWriter(NakresSaveDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Soubor nelze otevřít", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ukladac.ZapsatHranu(posledniRekonstrukce.HranyTelesa);
                    ukladac.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba při zápisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StatusInfo.Text = "Model byl exportován do " + ExportSaveDialog.FileName;

            }
        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        private void rekonstruovatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rekonstruovat();
        }

        private void filtrovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtrovatToolStripMenuItem.Checked = !filtrovatToolStripMenuItem.Checked;

            if (filtrovatToolStripMenuItem.Checked)
                rekonstruktor.Filtr = new LibRekonstruktor.Filtry.DimenzionalniFiltr(true);
            else
                rekonstruktor.Filtr = null;

            rekonstruovat();
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            drawerShora.ResetPohledu();
            drawerZprava.ResetPohledu();
            drawerZepredu.ResetPohledu();

            pohledDratenehoModelu.ResetovatPohled();
        }

        private void automatickyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatickyToolStripMenuItem.Checked = !automatickyToolStripMenuItem.Checked;
        }

    }
}
