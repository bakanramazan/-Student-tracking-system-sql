using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ÖĞRENCİ_TAKİP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void kAYITEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OGRENCI_KAYIT__IŞLEMLERI frm3 = new OGRENCI_KAYIT__IŞLEMLERI();
            frm3.MdiParent = this;
            frm3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kAYITGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OGR_GUNCELLEME_ISLEMI frm4 = new OGR_GUNCELLEME_ISLEMI();
            frm4.MdiParent = this;
            frm4.Show();
        }

        private void kAYITSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OGR_SILME_ISLEMI frm5 = new OGR_SILME_ISLEMI();
            frm5.MdiParent = this;
            frm5.Show();
        }

        private void sONDURUMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OGR_LISTELEME_ISLEMI frm6 = new OGR_LISTELEME_ISLEMI();
            frm6.MdiParent = this;
            frm6.Show();

        }

        private void nOTGİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NOT_GIRME_ISLEMI frm7 = new NOT_GIRME_ISLEMI();
            frm7.MdiParent = this;
            frm7.Show();
        }

        private void nOTDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NOT_GUNCELLEME_ISLEMI frm8 = new NOT_GUNCELLEME_ISLEMI();
            frm8.MdiParent = this;
            frm8.Show();
        }

       private void nOTSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NOT_SILME_ISLEMI frm9 = new NOT_SILME_ISLEMI();
            frm9.MdiParent = this;
            frm9.Show();
        }

       private void dURUMSURGULAToolStripMenuItem_Click(object sender, EventArgs e)
       {
           NOT_SORGULAMA_ISLEMI frm10 = new NOT_SORGULAMA_ISLEMI();
           frm10.MdiParent = this;
           frm10.Show();
       }

       private void sONDURUMToolStripMenuItem1_Click(object sender, EventArgs e)
       {
           NOT_SON_DURUM frm11 = new NOT_SON_DURUM();
           frm11.MdiParent = this;
           frm11.Show();
       }

       private void dERSEKLEToolStripMenuItem_Click(object sender, EventArgs e)
       {
           DERS_EKLEME_ISLEMI frm12 = new DERS_EKLEME_ISLEMI();
           frm12.MdiParent = this;
           frm12.Show();
       }

       private void dERSGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
       {
           DERS_GÜNCELLEME_ISLEMI frm13 = new DERS_GÜNCELLEME_ISLEMI();
           frm13.MdiParent = this;
           frm13.Show();
       }

       private void dERSSİLToolStripMenuItem_Click(object sender, EventArgs e)
       {
           DERS_SILME_ISLEMI frm14 = new DERS_SILME_ISLEMI();
           frm14.MdiParent = this;
           frm14.Show();

       }

       private void dERSSORGULAToolStripMenuItem_Click(object sender, EventArgs e)
       {
           DERS_SORGULAMA_ISLEMI frm15 = new DERS_SORGULAMA_ISLEMI();
           frm15.MdiParent = this;
           frm15.Show();
       }

       private void sONDURUMToolStripMenuItem2_Click(object sender, EventArgs e)
       {
           DERS_SON_DURUM frm16 = new DERS_SON_DURUM();
           frm16.MdiParent = this;
           frm16.Show();
       }

       private void bÖLÜMGİRToolStripMenuItem_Click(object sender, EventArgs e)
       {
           BOLUM_EKLEME_ISLEMI frm17 = new BOLUM_EKLEME_ISLEMI();
           frm17.MdiParent = this;
           frm17.Show();
       }

       private void bÖLÜMGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
       {
           BOLUM_GUNCELLEME_ISLEMI frm18 = new BOLUM_GUNCELLEME_ISLEMI();
           frm18.MdiParent = this;
           frm18.Show();
       }

       private void bÖLÜMSİLToolStripMenuItem_Click(object sender, EventArgs e)
       {
           BOLUM_SILME_ISLEMI frm19 = new BOLUM_SILME_ISLEMI();
           frm19.MdiParent = this;
           frm19.Show();
       }

       private void sONDURUMToolStripMenuItem3_Click(object sender, EventArgs e)
       {
           BOLUM_SON_DURUM frm20 = new BOLUM_SON_DURUM();
           frm20.MdiParent = this;
           frm20.Show();
       }

       private void fAKÜLTEEKLEToolStripMenuItem_Click(object sender, EventArgs e)
       {
           FAKULTE_EKLEME_ISLEMI frm21 = new FAKULTE_EKLEME_ISLEMI();
           frm21.MdiParent = this;
           frm21.Show();
       }

       private void fAKÜLTEGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
       {
           FAKULTE_GUNCELLEME_ISLEMI frm22 = new FAKULTE_GUNCELLEME_ISLEMI();
           frm22.MdiParent = this;
           frm22.Show();
       }

       private void fAKÜLTESİLToolStripMenuItem_Click(object sender, EventArgs e)
       {
           FAKULTE_SILME_ISLEMI frm23 = new FAKULTE_SILME_ISLEMI();
           frm23.MdiParent = this;
           frm23.Show();
       }

       private void sONDURUMToolStripMenuItem4_Click(object sender, EventArgs e)
       {
           FAKULTE_SON_DURUM frm24 = new FAKULTE_SON_DURUM();
           frm24.MdiParent = this;
           frm24.Show();
       }

       private void Form2_Load(object sender, EventArgs e)
       {

       }

     
 
    }
}
