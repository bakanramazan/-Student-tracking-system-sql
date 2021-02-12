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
    public partial class FAKULTE_GUNCELLEME_ISLEMI : Form
    {
        public FAKULTE_GUNCELLEME_ISLEMI()
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
            try
            {
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string listele = "select * from FAKULTELER where FAK_KODU=@T1";
            OleDbCommand komut = new OleDbCommand(listele, bag);
            komut.Parameters.Add("@T1", textBox1.Text);
            OleDbDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                textBox1.Text=oku[0].ToString();
                textBox2.Text=oku[1].ToString();
               
            }
            MessageBox.Show("FAKÜLTE LİSTELENDİ");
            textBox1.Enabled = false;
            button2.Enabled = true;
            bag.Close();

        }
            
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbConnection bag = new OleDbConnection();
                bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
                bag.Open();

                string guncelle = "update FAKULTELER set FAK_ADI=@T2 WHERE  FAK_KODU=@T1 ";
                OleDbCommand oku = new OleDbCommand(guncelle, bag);
                oku.Parameters.Add("T2", textBox2.Text);
                 oku.Parameters.Add("T1", textBox1.Text);
                int islem = oku.ExecuteNonQuery();
                if (islem ==1)
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
            string NO = comboBox1.SelectedItem.ToString();
            textBox1.Text = NO;
            button1.Enabled = true;
        }

        private void FAKULTE_GUNCELLEME_ISLEMI_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag.Open();
            string listele = " select FAK_KODU from FAKULTELER ";
            OleDbCommand KOMUT = new OleDbCommand(listele, bag);
            OleDbDataReader oku = KOMUT.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            bag.Close();
        }
            
        }
    }

