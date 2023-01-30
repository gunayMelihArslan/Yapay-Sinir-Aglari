using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Office.Interop.Excel;

namespace ann
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Int32 testEgitim;
        public static int te;
        public string girisDosyasiYolu, cikisDosyasiYolu;
        public static Int32 girisAdedi, veriSetiAdedi, gizliKatmanNoronAdedi, epokAdedi, egitimOrani, testOrani, egitimdeKullanilacakVeriSetiAdedi, testteKullanilacakVeriSetiAdedi;
        public double egitimHizi;
        public static double[,] girisDegerleri = new double[veriSetiAdedi, girisAdedi];
        public static double[] cikisDegerleri = new double[veriSetiAdedi];
        public double[,] girisGizliNoronArasiAgirlikDegeri = new double[girisAdedi, gizliKatmanNoronAdedi];
        public double[,] gizliNoronlaraGelenDegerler = new double[gizliKatmanNoronAdedi, testEgitim];
        public double[,] gizliNoronDegerleri = new double[gizliKatmanNoronAdedi, testEgitim];
        public double[] gizliNoronCikisArasiAgirlikDegerleri = new double[gizliKatmanNoronAdedi];
        public double[] hesaplananCikisDegerleri = new double[veriSetiAdedi];
        public double[,] gizliNoronAgirlikCarpimDegerleri = new double[gizliKatmanNoronAdedi, testEgitim];
        public double[] gizliNoronCikisHataTerimleri = new double[veriSetiAdedi];
        public double[,] girisNoronHataTerimleri = new double[veriSetiAdedi, gizliKatmanNoronAdedi];
        public Int32[] secilenVeriSetleri = new Int32[testEgitim];
        public double[,] cikisNoronArasiDiskriminant = new double[testEgitim, gizliKatmanNoronAdedi];
        public double[,,] girisNoronArasiDiskriminant = new double[testEgitim, gizliKatmanNoronAdedi, girisAdedi];
        public Int32[] testteKullanilacakVeriSetleri = new Int32[testEgitim];
        public double[] egri=new double[testEgitim];
        private void egitimOraniNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            girilenDegiskenleriOkuma();
            testOrani = (100 - egitimOrani);
            testOraniLabel.Text = ("Test Oranı %" + testOrani);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog girisDosyasi = new OpenFileDialog();
            girisDosyasi.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";
            girisDosyasi.FilterIndex = 1;
            girisDosyasi.ShowDialog();
            girisDosyasiYolu = girisDosyasi.FileName;
            textBox1.Text = girisDosyasiYolu;
        }
        public void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog cikisDosyasi = new OpenFileDialog();
            cikisDosyasi.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";
            cikisDosyasi.FilterIndex = 1;
            cikisDosyasi.ShowDialog();
            cikisDosyasiYolu = cikisDosyasi.FileName;
            textBox2.Text = cikisDosyasiYolu;
        }
        public void girisDosyasiOkuma()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelGirisDosyasi = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb;
                Worksheet ws;
                wb = excelGirisDosyasi.Workbooks.Open(girisDosyasiYolu);
                ws = wb.Worksheets[1];
                int k = 2;
                while (veriSetiAdedi < k)
                {
                    if (Convert.ToString(ws.Cells[k, 1].Value) != null)
                    {
                        veriSetiAdedi++;
                    }
                    else if (Convert.ToString(ws.Cells[k, 1].Value) == null)
                    {
                        break;
                    }
                    k++;
                }
                k = 1;
                while (girisAdedi < k)
                {
                    if (Convert.ToString(ws.Cells[1, k].Value) != null)
                    {
                        girisAdedi++;
                    }
                    else if (Convert.ToString(ws.Cells[1, k].Value) == null)
                    {
                        break;
                    }
                    k++;
                }
                girisDegerleri = new double[veriSetiAdedi, girisAdedi];
                Int32 m = 2, n;
                for (int i = 0; i < veriSetiAdedi; i++)
                {
                    n = 1;
                    for (int j = 0; j < girisAdedi; j++)
                    {
                        girisDegerleri[i, j] = Convert.ToDouble(ws.Cells[m, n].Value.ToString());
                        n++;
                    }
                    m++;
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Giriş Dosyası belirtilen konumunda bulunamadı", "GİRİŞ DOSYASI KONNUM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cikisDosyasiOkuma()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelcikisDosyasi = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb;
                Worksheet ws;
                wb = excelcikisDosyasi.Workbooks.Open(cikisDosyasiYolu);
                ws = wb.Worksheets[1];
                int j = 2;
                Array.Resize(ref cikisDegerleri, veriSetiAdedi);
                for (int i = 0; i <= (veriSetiAdedi - 2); i++)
                {
                    cikisDegerleri[i] = Convert.ToDouble((ws.Cells[j, 1].Value).ToString());
                    j++;
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Çıkış Dosyası belirtilen konumda bulunamadı", "ÇIKIŞ DOSYASI KONNUM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void girilenDegiskenleriOkuma()
        {
            try
            {
                gizliKatmanNoronAdedi = Convert.ToInt32(gizliKatmanNoronAdediTextBox.Text);
                epokAdedi = Convert.ToInt32(epokAdediTextBox.Text);
                egitimOrani = Convert.ToInt32(egitimOraniNumericUpDown.Value);
                egitimHizi = Convert.ToDouble(egitimHiziTextBox.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Değerler Doğru Şekilde Girilmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void girislerGizliNoronlarArasıAgirlikDegerleriUretme()
        {
            Random ggknaad = new Random();
            for (int i = 0; i < girisAdedi; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                {
                    girisGizliNoronArasiAgirlikDegeri[i, j] = Convert.ToDouble(ggknaad.Next(-5,5));
                }
            }
        }
        public void testVeEgitimdeKullanlicakVeriSetiAdediniHesaplama()
        {
            girisDosyasiOkuma();
            cikisDosyasiOkuma();
            girilenDegiskenleriOkuma();
            double araDeger = Convert.ToDouble((testOrani * veriSetiAdedi) / 100);
            testteKullanilacakVeriSetiAdedi = Convert.ToInt32(araDeger);
            egitimdeKullanilacakVeriSetiAdedi = Convert.ToInt32(veriSetiAdedi-testteKullanilacakVeriSetiAdedi);
            label1.Text=("Eğitimde " + Convert.ToString(egitimdeKullanilacakVeriSetiAdedi) + " adet veri kullanıldı.");
            label2.Text=("Testte " + Convert.ToString(testteKullanilacakVeriSetiAdedi) + " adet veri kullanıldı.");
        }
        public void egitimdeKullanlicakVeriSetleriniSecme()
        {
            int denenecekDeger;
            secilenVeriSetleri = new Int32[egitimdeKullanilacakVeriSetiAdedi];
            Random randomVeriSeti = new Random();
            for (int i = 0; i < egitimdeKullanilacakVeriSetiAdedi; i++)
            {
                denenecekDeger = randomVeriSeti.Next(0, veriSetiAdedi);
                bool kontrol1 = Array.Exists(secilenVeriSetleri, x => x == denenecekDeger);
                if (kontrol1 == false)
                {
                    secilenVeriSetleri[i]= denenecekDeger;
                }
                else if(kontrol1 == true)
                {
                    i--;
                }
            }
        }
        public void agirlikDegerleriyleGirisleriCarpma()
        {
            double carpim;
            for(int m = 0; m < testEgitim; m++)
            {
                for (int i = 0; i < gizliKatmanNoronAdedi; i++)
                {
                    for (int j = 0; j < girisAdedi; j++)
                    {
                        carpim = Convert.ToDouble(girisDegerleri[secilenVeriSetleri[m], j] * girisGizliNoronArasiAgirlikDegeri[j, i]);
                        gizliNoronlaraGelenDegerler[i, m] = carpim + gizliNoronlaraGelenDegerler[i, m];
                    }
                }
            }
        }
        public void gizliNoronlardakiDegerleriSigmoiddenGecirme()
        {
            for (int j = 0; j < testEgitim; j++)
            {
                for (int i = 0; i < gizliKatmanNoronAdedi; i++)
                {
                    gizliNoronDegerleri[i, j] = Convert.ToDouble(1 / (1 + (Math.Exp((-1) * Convert.ToDouble(gizliNoronlaraGelenDegerler[i, j])))));
                    if (gizliNoronDegerleri[i, j] >= 1 && gizliNoronlaraGelenDegerler[i, j] > 0)
                    {
                        gizliNoronDegerleri[i, j] = 1;
                    }
                    else if (Convert.ToDouble(gizliNoronDegerleri[i, j]) >= 0.5 && gizliNoronlaraGelenDegerler[i, j] < 0)
                    {
                        gizliNoronDegerleri[i, j] = Convert.ToDouble(0.5);
                    }
                    else if (gizliNoronDegerleri[i, j] <= 0)
                    {
                        gizliNoronDegerleri[i, j] = 0;
                    }
                }
            }
        }
        public void gizliKatmanCikisArasiAgirlikUretme()
        {
            Random gkcaad = new Random();
            for (int i = 0; i < gizliKatmanNoronAdedi; i++)
            {
                gizliNoronCikisArasiAgirlikDegerleri[i] = Convert.ToDouble(gkcaad.Next(-5, 5));
            }
        }
        public void gizliKatmanlardakiDegerlerleAgirliklariCarpma()
        {
            for (int j = 0; j < testEgitim; j++) 
            {
                for (int i = 0; i < gizliKatmanNoronAdedi; i++)
                {
                    gizliNoronAgirlikCarpimDegerleri[i,j] = Convert.ToDouble(gizliNoronCikisArasiAgirlikDegerleri[i] * gizliNoronDegerleri[i, j]);
                }
            }
        }
        public void cikisDegeriHesaplama()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                {
                    hesaplananCikisDegerleri[i] = gizliNoronAgirlikCarpimDegerleri[j, i] + hesaplananCikisDegerleri[i];
                }
            }
        }
        public void gizliNoronCikisHataTerimleriHesaplama()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                gizliNoronCikisHataTerimleri[i] = Convert.ToDouble(hesaplananCikisDegerleri[i] * (1 - hesaplananCikisDegerleri[i]) * (cikisDegerleri[secilenVeriSetleri[i]] - hesaplananCikisDegerleri[i]));
            }
        }
        public void cikisNoronArasiDiskriminantHesaplama()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                {
                    cikisNoronArasiDiskriminant[i, j] = Convert.ToDouble(gizliNoronCikisHataTerimleri[i] * egitimHizi * gizliNoronDegerleri[j, i]);
                }
            }
        }
        public void gizliNoronCikisArasiYeniAgirliklariBulma()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                {
                        gizliNoronCikisArasiAgirlikDegerleri[j] = gizliNoronCikisArasiAgirlikDegerleri[j] + cikisNoronArasiDiskriminant[i, j];
                        if (gizliNoronCikisArasiAgirlikDegerleri[j] <= -5)
                        {
                            gizliNoronCikisArasiAgirlikDegerleri[j] = -5;
                        }
                        else if (gizliNoronCikisArasiAgirlikDegerleri[j] >= 5)
                        {
                            gizliNoronCikisArasiAgirlikDegerleri[j] = 5;
                        }
                }
            }
        }
        public void girisNoronHataTerimleriHesaplama()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                {
                    for (int k = 0; k < girisAdedi; k++)
                    {
                        girisNoronHataTerimleri[i, j] = Convert.ToDouble(girisGizliNoronArasiAgirlikDegeri[k, j] * gizliNoronCikisHataTerimleri[i] * gizliNoronDegerleri[j, i] * (1 - gizliNoronDegerleri[j, i]));
                    }
                }
            }
        }
        public void noronGirisArasiDiskriminantHesaplama()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; i++)
                {
                    for (int k = 0; k < girisAdedi; k++)
                    {
                        girisNoronArasiDiskriminant[i, j, k] = Convert.ToDouble(egitimHizi * girisNoronHataTerimleri[i, j] * girisDegerleri[secilenVeriSetleri[k], girisAdedi]);
                    }
                }
            }
        }
        public void girisGizliNoronArasiYeniAgirliklariBulma()
        {
            for (int i = 0; i < testEgitim; i++)
            {
                for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                {
                    for (int k = 0; k < girisAdedi; k++)
                    {
                        girisGizliNoronArasiAgirlikDegeri[k, j] = girisNoronArasiDiskriminant[i, j, k] + girisGizliNoronArasiAgirlikDegeri[k, j];
                        if (girisGizliNoronArasiAgirlikDegeri[k, j] <= -5)
                        {
                            girisGizliNoronArasiAgirlikDegeri[k, j] = -5;
                        }
                        else if (girisGizliNoronArasiAgirlikDegeri[k, j] >= 5)
                        {
                            girisGizliNoronArasiAgirlikDegeri[k, j] = 5;
                        }
                    }
                }
            }
        }
        public void dizileriBoyutlandırma()
        { 
            gizliNoronlaraGelenDegerler = new double[gizliKatmanNoronAdedi, testEgitim];
            gizliNoronDegerleri = new double[gizliKatmanNoronAdedi, testEgitim];
            hesaplananCikisDegerleri = new double[testEgitim];//
            gizliNoronAgirlikCarpimDegerleri = new double[gizliKatmanNoronAdedi, testEgitim];
            gizliNoronCikisHataTerimleri = new double[testEgitim];//
            girisNoronHataTerimleri = new double[testEgitim, gizliKatmanNoronAdedi];//
            cikisNoronArasiDiskriminant = new double[testEgitim, gizliKatmanNoronAdedi];
            girisNoronArasiDiskriminant = new double[testEgitim, gizliKatmanNoronAdedi, girisAdedi];
            testteKullanilacakVeriSetleri = new Int32[testteKullanilacakVeriSetiAdedi];
            egri = new double[veriSetiAdedi];
        }
        public void dizileriSifirlama()
        {
            Array.Clear(gizliNoronlaraGelenDegerler, 0, gizliNoronlaraGelenDegerler.Length);
            Array.Clear(gizliNoronDegerleri, 0, gizliNoronDegerleri.Length);
            Array.Clear(hesaplananCikisDegerleri, 0, hesaplananCikisDegerleri.Length);
            Array.Clear(gizliNoronAgirlikCarpimDegerleri, 0, gizliNoronAgirlikCarpimDegerleri.Length);
            Array.Clear(gizliNoronCikisHataTerimleri, 0, gizliNoronCikisHataTerimleri.Length);
            Array.Clear(girisNoronHataTerimleri, 0, girisNoronHataTerimleri.Length);
            Array.Clear(cikisNoronArasiDiskriminant, 0, cikisNoronArasiDiskriminant.Length);
            Array.Clear(girisNoronArasiDiskriminant, 0, girisNoronArasiDiskriminant.Length);
        }
        public void egitimDongusu()
        {
            testVeEgitimdeKullanlicakVeriSetiAdediniHesaplama();
            testEgitim = egitimdeKullanilacakVeriSetiAdedi;
            gizliNoronCikisArasiAgirlikDegerleri = new double[gizliKatmanNoronAdedi];
            girisGizliNoronArasiAgirlikDegeri = new double[girisAdedi, gizliKatmanNoronAdedi];
            dizileriBoyutlandırma();
            girislerGizliNoronlarArasıAgirlikDegerleriUretme();
            gizliKatmanCikisArasiAgirlikUretme();
            egitimdeKullanlicakVeriSetleriniSecme();
            for (int epok = 0; epok < epokAdedi; epok++)
            {
                dizileriSifirlama();
                agirlikDegerleriyleGirisleriCarpma();
                gizliNoronlardakiDegerleriSigmoiddenGecirme();
                gizliKatmanlardakiDegerlerleAgirliklariCarpma();
                cikisDegeriHesaplama();
                gizliNoronCikisHataTerimleriHesaplama();
                cikisNoronArasiDiskriminantHesaplama();
                gizliNoronCikisArasiYeniAgirliklariBulma();
                girisNoronHataTerimleriHesaplama();
                girisGizliNoronArasiYeniAgirliklariBulma();
            }
        }
        public void testteKullanilacakVeriSetleriniBulma()
        {
            int j = 0;
            while (j < testteKullanilacakVeriSetiAdedi)
            {
                for (int i = 0; i < veriSetiAdedi; i++)
                {
                    bool kontrol = Array.Exists(secilenVeriSetleri, x => x == i);
                    if (kontrol == false )
                    {
                        testteKullanilacakVeriSetleri[j] = i;
                        j++;
                    }
                }
            }
            secilenVeriSetleri = new Int32[testteKullanilacakVeriSetiAdedi];
            for(int k = 0; k < testteKullanilacakVeriSetiAdedi; k++)
            {
                secilenVeriSetleri[k] = testteKullanilacakVeriSetleri[k];
            }
        }
        public void testDongusu()
        {
            testEgitim = testteKullanilacakVeriSetiAdedi;
            dizileriBoyutlandırma();
            testteKullanilacakVeriSetleriniBulma();
            dizileriSifirlama();
            agirlikDegerleriyleGirisleriCarpma();
            gizliNoronlardakiDegerleriSigmoiddenGecirme();
            gizliKatmanlardakiDegerlerleAgirliklariCarpma();
            cikisDegeriHesaplama();
        }
        public void mse()
        {
            double cikisToplam = 0, hedefToplam = 0, cikisToplamOrt, hedefToplamOrt, karelerinToplamıX = 0, karelerinToplamıY = 0, karelerinToplamıXY = 0, sxx = 0, syy = 0, sxy = 0, a, b;
            for(int i = 0; i < testteKullanilacakVeriSetiAdedi; i++)
            {
                hedefToplam = hedefToplam + cikisDegerleri[secilenVeriSetleri[i]];
                cikisToplam = cikisToplam + hesaplananCikisDegerleri[i];
            }
            hedefToplamOrt = Convert.ToDouble(hedefToplam / testteKullanilacakVeriSetiAdedi);
            cikisToplamOrt = Convert.ToDouble(cikisToplam / testteKullanilacakVeriSetiAdedi);
            for(int j = 0; j < testteKullanilacakVeriSetiAdedi; j++)
            {
                karelerinToplamıX = Convert.ToDouble(cikisDegerleri[j] * cikisDegerleri[j]) + karelerinToplamıX;
                karelerinToplamıY = Convert.ToDouble(hesaplananCikisDegerleri[j] * hesaplananCikisDegerleri[j]) + karelerinToplamıY;
                karelerinToplamıXY = Convert.ToDouble(cikisDegerleri[j] * hesaplananCikisDegerleri[j]) + karelerinToplamıXY;
            }
            sxx = karelerinToplamıX - Convert.ToDouble(testteKullanilacakVeriSetiAdedi * hedefToplamOrt * hedefToplamOrt);
            syy = karelerinToplamıY - Convert.ToDouble(testteKullanilacakVeriSetiAdedi * cikisToplamOrt * cikisToplamOrt);
            sxy = karelerinToplamıXY - Convert.ToDouble(testteKullanilacakVeriSetiAdedi * hedefToplamOrt * cikisToplamOrt);
            b = Convert.ToDouble(sxy / sxx);
            a = cikisToplamOrt - Convert.ToDouble(b * hedefToplamOrt);
            for (int j = 0; j < veriSetiAdedi; j++)
            {
                egri[j] = Convert.ToDouble(b * j) + a;
            }
            progressBar1.Value = progressBar1.Maximum;
            label3.Text = "Eğitim Tamamlandı";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || gizliKatmanNoronAdediTextBox.Text == string.Empty || epokAdediTextBox.Text == string.Empty || egitimHiziTextBox.Text == string.Empty || egitimOraniNumericUpDown.Value == 0)
            {
                MessageBox.Show("Eksik Değer Girdiniz!" + Environment.NewLine + "Lütfen Girdiğiniz Değerleri Kontrol Ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                egitimDongusu();
                testDongusu();
                mse();
                for (int i = 0; i < girisAdedi; i++)
                {
                    for (int j = 0; j < gizliKatmanNoronAdedi; j++)
                    {
                        listBox1.Items.Add(girisGizliNoronArasiAgirlikDegeri[i, j]);
                        listBox2.Items.Add(gizliNoronCikisArasiAgirlikDegerleri[j]);
                    }
                }
                for (int i = 0; i < testEgitim; i++)
                {
                    chart1.Series[0].Points.AddXY(hesaplananCikisDegerleri[i], cikisDegerleri[testteKullanilacakVeriSetleri[i]]);
                }
                for (int j = 0; j < veriSetiAdedi; j++)
                {
                    chart1.Series[1].Points.AddXY(j, egri[j]);
                }
            }
            chart1.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            chart1.BringToFront();
            chart1.Dock = DockStyle.Fill;
        }
        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            chart1.Dock = DockStyle.None;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Enabled = false;
            listBox1.Items.Add("Giriş Gizli Katman Nöron Arası Ağırlık Değerleri");
            listBox2.Items.Add("Gizli Katman Nöron Çıkış Arası Ağırlık Değerleri");
        }
        private void gizliKatmanNoronAdediTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void epokAdediTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void egitimHiziTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }
    }
}