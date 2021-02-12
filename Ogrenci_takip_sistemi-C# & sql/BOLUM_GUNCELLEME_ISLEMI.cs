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
    public partial class BOLUM_GUNCELLEME_ISLEMI : Form
    {
        public BOLUM_GUNCELLEME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string sql = "select *  from BOLUMLER where BOLUM_KODU=@T1";
            OleDbCommand komut = new OleDbCommand(sql, bag);
            komut.Parameters.Add("@T1", textBox1.Text);
            OleDbDataReader oku = komut.ExecuteReader();

            if (oku.Read() == true)
            {
               listBox1.Items.Add(oku[0].ToString());
               listBox2.Items.Add(oku[1].ToString());
               textBox2.Text=oku[1].ToString();
             }
            MessageBox.Show("Kayıt Listelendi");
            button2.Enabled = true;
            bag.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();

            string guncelle = "update BOLUMLER set BOLUM_ADI=@T2 where BOLUM_KODU=@T1";
            OleDbCommand oku = new OleDbCommand(guncelle,bag);
            oku.Parameters.Add("t2",textBox2.Text);
            oku.Parameters.Add("t1",textBox1.Text);

           int islem= oku.ExecuteNonQuery();
            if (islem==1)
	{
		  MessageBox.Show("kayıt güncellendi");
	}
            bag.Close();
    }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int  secilen = listBox1.SelectedIndex;
            listBox2.SelectedIndex = secilen;
            textBox1.Text = listBox1.Text; ;
            textBox2.Text = listBox2.Text;
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string NO = comboBox1.SelectedItem.ToString();
            textBox1.Text = NO;
            button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
           
        }

        private void BOLUM_GUNCELLEME_ISLEMI_Load(object sender, EventArgs e)

        {
            textBox1.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag.Open();
            string listele = " select BOLUM_KODU from BOLUMLER ";
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
