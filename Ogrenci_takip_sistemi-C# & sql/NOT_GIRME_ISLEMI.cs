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
    public partial class NOT_GIRME_ISLEMI : Form
    {
        public NOT_GIRME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        int sonuc =0;
        public  double ortalama(int vize,int Quız1,int Quız2,int Quız3,int final)
        {
            if (Quız1>=60 && Quız2>=60 && Quız3>=60)
            {
                
                sonuc = vize * 40 / 100 + ((final+15) * 60 / 100);
                return sonuc;
            }
            else if (Quız1>=60 && Quız2>=60 && Quız3<60)
            {
                sonuc = vize * 40/100 + ((final + 10) * 60/100);
                return sonuc;
            }
            else if (Quız1>=60 && Quız2<60 && Quız3>=60)
            {
                sonuc = (vize * 40 / 100) +( (final + 10)*60 / 100);
                return sonuc;
            }
            else if (Quız1 < 60 && Quız2 >= 60 && Quız3 >= 60)
            {
                sonuc = (vize * 40 / 100) + ((final + 10) * 60 / 100);
                return sonuc;
            }
            else if (Quız1<60 && Quız2<60 && Quız3<60)
            {
                sonuc =( vize * 40 / 100 )+ (final  * 60 / 100);
                return sonuc;
            }
            else
            {
                sonuc = (vize * 40 / 100) + (final * 60 / 100);
                return sonuc;
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            


             OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
          bag.Open();

            int vıze=Convert.ToInt32(textBox4.Text);
             int qız1=Convert.ToInt32(textBox5.Text);
             int qız2=Convert.ToInt32(textBox6.Text);
             int qız3=Convert.ToInt32(textBox7.Text);
             int fınal=Convert.ToInt32(textBox8.Text);
            double ort=ortalama(vıze,qız1,qız2,qız3,fınal);
            textBox9.Text=ort.ToString();
        if (fınal>=60 && ort>=60)
         {
             textBox10.Text = "GEÇTİ";  
         }
         else
         {
             textBox10.Text = "KALDI";
         }
           
          
          string sql = "insert into NOTLAR (OGR_NO,DERS_KODU,DERS_ADI,VIZE,QUIZ1,QUIZ2,QUIZ3,FINAL,ORTALAMA,DURUM)";

         sql = sql + "values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','"+textBox8.Text+"','"+textBox9.Text+"','"+textBox10.Text+"')";
         
          OleDbCommand komut = new OleDbCommand(sql, bag);
          int islem = komut.ExecuteNonQuery();
          if (islem==1)
          {
              MessageBox.Show("kayıt eklendi");
              textBox1.Clear();
              textBox2.Clear();
              textBox3.Clear();
              textBox4.Clear();
              textBox5.Clear();
              textBox6.Clear();
              textBox7.Clear();
              textBox8.Clear();
              textBox9.Clear();
              textBox10.Clear();
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
              textBox8.Clear();
              textBox9.Clear();
              textBox10.Clear();
          }
       }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string NO = comboBox1.SelectedItem.ToString ();
           textBox1.Text = NO;
      

        }

       
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void NOT_GIRME_ISLEMI_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag.Open();
            string listele = " select OGR_NO from OGRENCILER ";
            OleDbCommand KOMUT = new OleDbCommand(listele, bag);
            OleDbDataReader oku = KOMUT.ExecuteReader();
            while (oku.Read())
            { 
                comboBox1.Items.Add ( oku[0].ToString());
            }
            bag.Close();
          



            OleDbConnection bag2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag2.Open();
            string listele2 = " select DERS_KODU from DERSLER ";
            OleDbCommand KOMUT2 = new OleDbCommand(listele2, bag2);
            OleDbDataReader oku2 = KOMUT2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2[0].ToString());


            }
           
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kod = comboBox2.SelectedItem.ToString();
            textBox2.Text = kod ;
         
            if (textBox2.Text != "")
            {
                OleDbConnection bag2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
                bag2.Open();
                string listele2 = " select * from DERSLER where DERS_KODU=@T1 ";
                OleDbCommand KOMUT2 = new OleDbCommand(listele2, bag2);
                KOMUT2.Parameters.Add("T1", textBox2.Text);
                OleDbDataReader oku2 = KOMUT2.ExecuteReader();
                while (oku2.Read())
                {
                    textBox3.Text = oku2[1].ToString();
                }
             
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection bag2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag2.Open();
            string listele2 = " select DERS_KODU from DERSLER ";
            OleDbCommand KOMUT2 = new OleDbCommand(listele2, bag2);
        
            OleDbDataReader oku2 = KOMUT2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2[0].ToString());
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                button3.BackColor = Color.RoyalBlue;

            }  
        }

      
    }
}
