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
    public partial class OGR_GUNCELLEME_ISLEMI : Form
    {
        public OGR_GUNCELLEME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox8.Enabled = true;
            
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();
            
            string sql = "select    OGR_NO,TC_NO,ADI,SOYADI,DOG_TARIHI,TELEFON,ADRES,CINSIYET from OGRENCILER where OGR_NO=@T1";
             OleDbCommand komut = new OleDbCommand(sql,bag);
            komut.Parameters.Add("@T1",textBox1.Text);
            OleDbDataReader oku = komut.ExecuteReader();

          
          
            if (oku.Read()==true)
            {
                textBox1.Text=  oku[0].ToString() ;
                textBox2.Text = oku[1].ToString();
                textBox3.Text = oku[2].ToString();
                textBox4.Text = oku[3].ToString();
                textBox5.Text = oku[4].ToString();
                textBox6.Text = oku[5].ToString();
                textBox7.Text = oku[6].ToString();
                textBox8.Text = oku[7].ToString();
               
            } 
          
            
     MessageBox.Show("Kayıt Listelendi");
          
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox8.Enabled = false;
     bag.Close();
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string sql = "update OGRENCILER set ADI=@T1,SOYADI=@T2,TELEFON=@T3,ADRES=@T4 WHERE OGR_NO=@T5 ";
            OleDbCommand komut = new OleDbCommand(sql,bag);
            komut.Parameters.Add("T1", textBox3.Text);
            komut.Parameters.Add("T2",textBox4.Text);
            komut.Parameters.Add("T3", textBox6.Text);
            komut.Parameters.Add("T4", textBox7.Text);
            komut.Parameters.Add("T5", textBox1.Text);
           int islem= komut.ExecuteNonQuery();
            if (islem==1)
            {
                  MessageBox.Show("KAYIT DEĞİŞTİRİLDİ");
            }
          
           
           
            textBox8.Enabled = true;
            bag.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            DateTime tarih = dateTimePicker1.Value;
            textBox5.Text = tarih.ToShortDateString();
            textBox5.Enabled = true;
        }

        private void OGR_GUNCELLEME_ISLEMI_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag.Open();
            string listele = " select OGR_NO from OGRENCILER ";
            OleDbCommand KOMUT = new OleDbCommand(listele, bag);
            OleDbDataReader oku = KOMUT.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            bag.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string NO = comboBox1.SelectedItem.ToString();
            textBox1.Text = NO;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
