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
    public partial class NOT_GUNCELLEME_ISLEMI : Form
    {
        public NOT_GUNCELLEME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string sql = "select *  from NOTLAR WHERE OGR_NO=@T1 ";
            OleDbCommand komut = new OleDbCommand(sql, bag);
            komut.Parameters.Add("@T1", textBox1.Text);
            OleDbDataReader oku = komut.ExecuteReader();

            if (oku.Read() == true)
            {
                textBox1.Text = oku[0].ToString();
                textBox2.Text = oku[1].ToString();
                textBox3.Text = oku[2].ToString();
                textBox4.Text = oku[3].ToString();
                textBox5.Text = oku[4].ToString();
                textBox6.Text = oku[5].ToString();
                textBox7.Text = oku[6].ToString();
                textBox8.Text = oku[7].ToString();
                textBox9.Text = oku[8].ToString();
                textBox10.Text =oku[9].ToString();

            }
            MessageBox.Show("Kayıt Listelendi");
            textBox1.Enabled = true;
            textBox2.Enabled = true;
             bag.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string guncelle = "update NOTLAR set DERS_ADI=@t3,VIZE=@t4,QUIZ1=@t5,QUIZ2=@t6,QUIZ3=@t7,FINAL=@t8 where OGR_NO=@T1";
            OleDbCommand oku = new OleDbCommand(guncelle,bag);
            oku.Parameters.Add("T3",textBox3.Text);
            oku.Parameters.Add("t4",textBox4.Text);
            oku.Parameters.Add("t5",textBox5.Text);
            oku.Parameters.Add("t6",textBox6.Text);
            oku.Parameters.Add("T7",textBox7.Text);
            oku.Parameters.Add("t8",textBox8.Text);
            oku.Parameters.Add("t1",textBox1.Text);

           int islem= oku.ExecuteNonQuery();
            if (islem==1)
	{
		  MessageBox.Show("kayıt güncellendi");
	}
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
 bag.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string NO = comboBox1.SelectedItem.ToString();
            textBox1.Text = NO;
            textBox1.Enabled = true;
        }

        private void NOT_GUNCELLEME_ISLEMI_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox10.Enabled = false;
            textBox9.Enabled = false;
            button2.Enabled = false;
          
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
         int sonuc =0;
         public double ortalama(int vize, int Quız1, int Quız2, int Quız3, int final)
         {
             if (Quız1 >= 60 && Quız2 >= 60 && Quız3 >= 60)
             {

                 sonuc = vize * 40 / 100 + ((final + 15) * 60 / 100);
                 return sonuc;
             }
             else if (Quız1 >= 60 && Quız2 >= 60 && Quız3 < 60)
             {
                 sonuc = vize * 40 / 100 + ((final + 10) * 60 / 100);
                 return sonuc;
             }
             else if (Quız1 >= 60 && Quız2 < 60 && Quız3 >= 60)
             {
                 sonuc = (vize * 40 / 100) + ((final + 10) * 60 / 100);
                 return sonuc;
             }
             else if (Quız1 < 60 && Quız2 >= 60 && Quız3 >= 60)
             {
                 sonuc = (vize * 40 / 100) + ((final + 10) * 60 / 100);
                 return sonuc;
             }
             else if (Quız1 < 60 && Quız2 < 60 && Quız3 < 60)
             {
                 sonuc = (vize * 40 / 100) + (final * 60 / 100);
                 return sonuc;
             }
             else
             {
                 sonuc = (vize * 40 / 100) + (final * 60 / 100);
                 return sonuc;
             }
             if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
             {
                 button3.BackColor = Color.Red;

             }  
         }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
             int vıze = Convert.ToInt32(textBox4.Text);
            int qız1 = Convert.ToInt32(textBox5.Text);
            int qız2 = Convert.ToInt32(textBox6.Text);
            int qız3 = Convert.ToInt32(textBox7.Text);
            int fınal = Convert.ToInt32(textBox8.Text);
            textBox9.Text = ortalama(vıze, qız1, qız2, qız3, fınal).ToString();


            if (Convert .ToDouble( textBox9.Text) >=60 && fınal>=60)
            {
                textBox10.Text = "GEÇTİNİZ";
            }
            else
            {
                textBox10.Text = "KALDINIZ";  
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

      
    }
}
