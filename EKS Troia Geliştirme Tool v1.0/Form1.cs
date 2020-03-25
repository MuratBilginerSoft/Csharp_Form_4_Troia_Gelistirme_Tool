using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EKS_Troia_Geliştirme_Tool_v1._0
{
    public partial class Form1 : Form
    {

        #region Tanımlamalar

        int[] SatırSayisi = new int[5000];
        int[] SatirSayisi2 = new int[5000];
        string[] K3 = new string[5000];
        string[] K4 = new string[5000];

        #endregion

        #region Değişkenler



        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radialMenuItem6_Click(object sender, EventArgs e)
        {
            RichİAS.Clear();
        }

        private void radialMenuItem7_Click(object sender, EventArgs e)
        {
            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                RichİAS.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void radialMenuItem2_Click(object sender, EventArgs e)
        {
            RichAlp.Clear();
        }

        private void radialMenuItem3_Click(object sender, EventArgs e)
        {
            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                RichAlp.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicSimge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RadialMenuAlp_ItemClick(object sender, EventArgs e)
        {
            int i2 = 0;
            int Sayaç = 0;
            string Cümle = "";

            Array.Resize(ref SatırSayisi, 5000);
            Array.Resize(ref K3, 5000);
            Array.Resize(ref SatirSayisi2, 5000);
            Array.Resize(ref K4, 5000);


            string[] K1 = RichİAS.Text.Split('\n');
            string[] K2 = RichAlp.Text.Split('\n');

            RichAlp.Clear();

            for (int i3 = 0; i3 < K2.Length; i3++)
            {
                string[] Kelime = K2[i3].Split(' ');


                Cümle = "";
                foreach (string item in Kelime)
                {
                    if (item.Trim() != "")
                    {
                        Cümle += item.Trim() + " ";
                    }
                }

                RichAlp.Text += Cümle + "\n";
            }

            RichİAS.Clear();

            for (int i4 = 0; i4 < K1.Length; i4++)
            {
                string[] Kelime = K1[i4].Split(' ');


                Cümle = "";
                foreach (string item in Kelime)
                {
                    if (item.Trim() != "")
                    {
                        Cümle += item.Trim() + " ";
                    }
                }

                RichİAS.Text += Cümle + "\n";
            }

            K1 = RichİAS.Text.Split('\n');
            K2 = RichAlp.Text.Split('\n');


            for (int i1 = 0; i1 < K2.Length; i1++) // Alp teki tek satır kodu İAS daki tüm satırlarla karşılaştırma.
            {
                for (i2 = 0; i2 < K1.Length; i2++)
                {
                    if (K2[i1].Trim() == K1[i2].Trim())
                    {
                        break;
                    }
                }

                if (i2 == K1.Length)
                {
                    SatırSayisi[Sayaç] = i1;
                    K3[Sayaç] = K2[i1];
                    RichAlp.Find(K2[i1], i1, RichAlp.TextLength, RichTextBoxFinds.None);
                    RichAlp.SelectionBackColor = Color.Yellow;
                    Sayaç++;
                }
            }

            Array.Resize(ref SatırSayisi, Sayaç);
            Array.Resize(ref K3, Sayaç);

            //LblAlp.Text = (Sayaç + 1) + " Tane Farklı Kod Bulundu";
            //LblAlp.BackColor = Color.Red;

            //RichFarklıKodlarAlp.Text = SatırSayisi[0] + 1 + "  " + K3[0];

            //for (int k1 = 1; k1 < K3.Length; k1++)
            //{
            //    RichFarklıKodlarAlp.Text += "\n" + SatırSayisi[k1] + 1 + "  " + K3[k1];
            //}

            Sayaç = 0;

            for (int i1 = 0; i1 < K1.Length; i1++) // İAS daki tek satır kodu Alp deki tüm satırlarla karşılaştırma.
            {
                for (i2 = 0; i2 < K2.Length; i2++)
                {
                    if (K1[i1].Trim() == K2[i2].Trim())
                    {
                        break;
                    }
                }

                if (i2 == K2.Length)
                {
                    SatirSayisi2[Sayaç] = i1;
                    K4[Sayaç] = K1[i1];
                    RichİAS.Find(K1[i1], i1, RichİAS.TextLength, RichTextBoxFinds.None);
                    RichİAS.SelectionBackColor = Color.LightBlue;
                    Sayaç++;
                }
            }

            Array.Resize(ref SatirSayisi2, Sayaç);
            Array.Resize(ref K4, Sayaç);

            //LblİAS.Text = (Sayaç + 1) + " Tane Farklı Kod Bulundu";
            //LblİAS.BackColor = Color.Red;

            //RichFarkliKodlarİAS.Text = SatirSayisi2[0] + 1 + "  " + K4[0];

            //for (int k1 = 1; k1 < K4.Length; k1++)
            //{
            //    RichFarkliKodlarİAS.Text += "\n" + SatirSayisi2[k1] + 1 + "  " + K4[k1];
            //}
        }
    }
}
