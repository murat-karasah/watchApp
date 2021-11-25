using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watchApp
{
    public partial class Form1 : Form
    {
        public int dakika = 0, saniye=0,saat=0,sayac=0, NumberOfClick = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblSifirla();
            timer1.Start();
            btnPause.Enabled = true;
            btnSifirla.Enabled = true;  
            btnStart.Enabled = false;
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                    timer1.Stop();
                    btnPause.Text = "Devam";
                    break;
                case 2:
                    timer1.Start();
                    btnPause.Text = "Durdur";
                    NumberOfClick = 0;
                    break;
                default:
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            lblSaniye.Text = String.Format("{0:00}", saniye);
            if (saniye>59)
            {
                lblSaniye.Text = String.Format("{0:00}", saniye);
                saniye = 0;
                dakika++;
                lblDakika.Text = String.Format("{0:00}", dakika);
            }
            else if (dakika>59)
                {
                    dakika = 0;
                    saat++;
                    lblSaat.Text = String.Format("{0:00}", saat);
                }
            else if (saat>23)
            {
                timer1.Stop();
            }
        }
        private void Sıfırla_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            saniye=0;
            dakika=0;
            saat=0;
            lblSifirla();
            btnPause.Enabled = false;
            btnSifirla.Enabled = false;
            btnStart.Enabled = true;
        }
        private void lblSifirla()
        {
            btnPause.Text = "Durdur";
            NumberOfClick = 0;
            lblSaniye.Text = String.Format("{0:00}", saniye);
            lblDakika.Text = String.Format("{0:00}", dakika);
            lblSaat.Text = String.Format("{0:00}", saat);
        }
    }
}
