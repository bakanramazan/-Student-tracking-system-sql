using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ÖĞRENCİ_TAKİP
{
    public partial class DERS_GÜNCELLEME_ISLEMI : Form
    {
        public DERS_GÜNCELLEME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;

            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string listele = "select * from DERSLER where DERS_KODU=@T1";
            OleDbCommand komut = new OleDbCommand(listele, bag);
            komut.Parameters.Add("@T1", textBox1.Text);
            OleDbDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                textBox1.Text=oku[0].ToString();
                textBox2.Text=oku[1].ToString();
                textBox3.Text=oku[2].ToString();
            }
            MessageBox.Show("DERS LİSTELENDİ");
           bag.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string guncelle = "update DERSLER set DERS_ADI=@T2,DERS_KREDISI=@T3 WHERE  DERS_KODU=@T1 ";
            OleDbCommand oku = new OleDbCommand(guncelle, bag);
            oku.Parameters.Add("T2",textBox2.Text);
            oku.Parameters.Add("T3", textBox3.Text);
            oku.Parameters.Add("T1",textBox1.Text);
             int islem = oku.ExecuteNonQuery();
            if (islem == 1)
            {
                MessageBox.Show("kayıt güncellendi");
            }

            textBox1.Enabled = true;
            bag.Close();
            }
            catch (Exception HATA)
            {

                MessageBox.Show(HATA.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kod = comboBox1.SelectedItem.ToString();
            textBox1.Text = kod;
        }

        private void DERS_GÜNCELLEME_ISLEMI_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            OleDbConnection bag2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag2.Open();
            string listele2 = " select DERS_KODU from DERSLER ";
            OleDbCommand KOMUT2 = new OleDbCommand(listele2, bag2);
            OleDbDataReader oku2 = KOMUT2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox1.Items.Add(oku2[0].ToString());


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection bag2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag2.Open();
            string listele2 = " select DERS_ADI from DERSLER  where DERS_KODU=@T1";
            OleDbCommand KOMUT2 = new OleDbCommand(listele2, bag2);
            KOMUT2.Parameters.Add("T1", textBox2.Text);
            OleDbDataReader oku2 = KOMUT2.ExecuteReader();
            while (oku2.Read())
            {
                textBox3.Text = oku2[0].ToString();


            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
