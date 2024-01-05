using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        private int[][] oyunAlani = new[]
        {
            new[] {0, 0, 0, 0},
            new[] {0, 1, 0, 0},
            new[] {0, 0, 0, 0},
            new[] {0, 0, 0, 2},
        };

        //0 - boş anlamına gelsin
        //1 - bomba anlamina gelsin
        //2 - kalp anlamina gelsin

        private int saniye = 30;
        private int bombaSayisi = 3;
        private int puan = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            Button btn = (Button)sender;

            int deger = DegerOku(btn);

            if (deger == 1)
            {
                btn.BackgroundImage = Properties.Resources.bomb;
                lblSonuc.Text = "KAYBETTİNİZ";
                lblSonuc.ForeColor = Color.Red;
                HepsiniGoster();
            }
            else if (deger == 2)
            {
                btn.BackgroundImage = Properties.Resources.kalp;
                lblSonuc.Text = "KAZANDINIZ";
                lblSonuc.ForeColor = Color.ForestGreen;
                puan+=saniye;
                lblPuan.Text = puan.ToString();
                HepsiniGoster();
            }
            else
            {
                btn.BackColor = Color.DimGray;
                puan++;
                lblPuan.Text = puan.ToString();
            }

            btn.Enabled = false;
        }

        int DegerOku(Button btn)
        {
            int num = Convert.ToInt32(btn.Tag);

            int sutun = num % 4;//modu kullanarak sutun bulunur
            int satir = num / 4;//4 e bolerek satir bulunur

            int deger = oyunAlani[satir][sutun];

            return deger;
        }

        void ButtonGoster(Button btn)
        {
            int deger = DegerOku(btn);

            if (deger == 1)
                btn.BackgroundImage = Properties.Resources.bomb;
            else if (deger == 2)
                btn.BackgroundImage = Properties.Resources.kalp;
            else
            {
                btn.BackColor = Color.DimGray;
            }

            btn.Enabled = false;
        }

        void ButtonSifirla(Button aaa)
        {
            aaa.BackgroundImage = null;
            aaa.BackColor = SystemColors.Control;
            aaa.Enabled = true;
        }

        void HepsiniGoster()
        {
            ButtonGoster(button1);
            ButtonGoster(button2);
            ButtonGoster(button3);
            ButtonGoster(button4);
            ButtonGoster(button5);
            ButtonGoster(button6);
            ButtonGoster(button7);
            ButtonGoster(button8);
            ButtonGoster(button9);
            ButtonGoster(button10);
            ButtonGoster(button11);
            ButtonGoster(button12);
            ButtonGoster(button13);
            ButtonGoster(button14);
            ButtonGoster(button15);
            ButtonGoster(button16);

            timer1.Enabled = false;
            rdKolay.Enabled = rdOrta.Enabled = rdZor.Enabled = true;

        }

        void OyunOlustur()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    oyunAlani[i][j] = 0;//tumunu sifrlar
                }
            }
            
            int bomba = bombaSayisi;

            Random rnd=new Random();
            int rasgele = rnd.Next(0, 15);
            int satir = rasgele / 4;
            int sutun = rasgele % 4;

            oyunAlani[satir][sutun] = 2;//kalp

            while (bomba > 0)
            {
                rasgele = rnd.Next(0, 15);
                satir = rasgele / 4;
                sutun = rasgele % 4;
                
                if (oyunAlani[satir][sutun] == 0)
                {
                    oyunAlani[satir][sutun] = 1;//bomba
                    bomba--;
                }
            }
        }

        void Baslat()
        {
            if (rdKolay.Checked)
                bombaSayisi = 3;
            else if (rdOrta.Checked)
                bombaSayisi = 6;
            else bombaSayisi = 10;
            rdKolay.Enabled = rdOrta.Enabled = rdZor.Enabled = false;

            OyunOlustur();

            ButtonSifirla(button1);
            ButtonSifirla(button2);
            ButtonSifirla(button3);
            ButtonSifirla(button4);
            ButtonSifirla(button5);
            ButtonSifirla(button6);
            ButtonSifirla(button7);
            ButtonSifirla(button8);
            ButtonSifirla(button9);
            ButtonSifirla(button10);
            ButtonSifirla(button11);
            ButtonSifirla(button12);
            ButtonSifirla(button13);
            ButtonSifirla(button14);
            ButtonSifirla(button15);
            ButtonSifirla(button16);
            puan = 0;
            lblPuan.Text = puan.ToString();
            saniye = 30;
            timer1.Enabled = true;
            lblSonuc.Text = "Oyun Başladı! Bol Şans!";
            lblSonuc.ForeColor = Color.DodgerBlue;
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            Baslat();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye--;
            TimeSpan ts = new TimeSpan(0, 0, 0, saniye);

            lblZaman.Text = ts.ToString("mm':'ss");

            if (saniye == 0)
            {
                HepsiniGoster();
                lblSonuc.Text = "ZAMAN BİTTİ";
                lblSonuc.ForeColor = Color.Red;
                timer1.Enabled = false;
            }
        }
    }
}
