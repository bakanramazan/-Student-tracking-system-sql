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
    public partial class OGRENCI_KAYIT__IŞLEMLERI : Form
    {
        public OGRENCI_KAYIT__IŞLEMLERI()
        {
            InitializeComponent();
        }

      private void OGRENCI_KAYIT__IŞLEMLERI_Load(object sender, EventArgs e)
        {
            textBox5.Enabled = false; 

        }

      private void button2_click (object sender, EventArgs e)
      {
          this.Close();
      }

      
      private  void button1_Click(object sender, EventArgs e)
      {
          try
          {
              if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && textBox5.Text!="" &&( radioButton1.Checked ||radioButton2.Checked))
              {
                  
             
              OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
              bag.Open();

              
              string sql = "insert into OGRENCILER (OGR_NO,TC_NO,ADI,SOYADI,DOG_TARIHI,TELEFON,ADRES,CINSIYET)";
              if (radioButton1.Checked )
              {
                  sql = sql + "values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + radioButton1.Text + "')";
              }
              if (radioButton2.Checked)
              {
                  sql = sql + "values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + radioButton2.Text + "')";
              }
              OleDbCommand komut = new OleDbCommand(sql, bag);
              int islem = komut.ExecuteNonQuery();
              if (islem == 1)
              {
                  MessageBox.Show("kayıt eklendi");
                  textBox1.Clear();
                  textBox2.Clear();
                  textBox3.Clear();
                  textBox4.Clear();
                  textBox5.Clear();
                  textBox6.Clear();
                  textBox7.Clear();
              } 
              
              else
              {
                  MessageBox.Show("kayıt hatası olabilir tekrar deneyin!");
                  textBox1.Clear();
                  textBox2.Clear();
                  textBox3.Clear();
                  textBox4.Clear();
                  textBox5.Clear();
                  textBox6.Clear();
                  textBox7.Clear();
              }
              
             }
              else
              {
                  MessageBox.Show("Ad,Soyad,Dog_Tarihi,TC_no ve Cinsiyet alanları boş geçilemez!!!!");
              }
          }
          catch (Exception hata)
          {

              MessageBox.Show(hata.Message);
          }
     

      }

      private void textBox1_TextChanged(object sender, EventArgs e)
      {

         

      }

      private void textBox2_TextChanged(object sender, EventArgs e)
      {
     
      }

      private void textBox5_TextChanged(object sender, EventArgs e)
      {
          
      }

      private void textBox6_TextChanged(object sender, EventArgs e)
      {
           int tcuzn = textBox6.Text.Length;
           if (tcuzn > 11 && tcuzn < 11)
           {

               MessageBox.Show("Telefon numarası 11 haneden fazla olamaz!!!!!!!!1");
           }
          
      }

      private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
      {
          textBox5.Enabled = true;
          DateTime tarih = dateTimePicker1.Value;
          textBox5.Text = tarih.ToShortDateString();
      }
     
    }
}
