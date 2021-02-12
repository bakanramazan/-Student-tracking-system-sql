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
    public partial class DERS_SORGULAMA_ISLEMI : Form
    {
        public DERS_SORGULAMA_ISLEMI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex==1)
            {
                textBox1.Enabled = true;
                
                OleDbConnection bag = new OleDbConnection();
                bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE =" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
                bag.Open();
                string liste = "select * from DERSLER where DERS_KREDISI=@T1";
                OleDbCommand komut = new OleDbCommand(liste, bag);
                komut.Parameters.Add("T1", textBox1.Text);
                OleDbDataReader oku = komut.ExecuteReader();
              
                while (oku.Read())
                {

                 listBox1.Items.Add(oku[0].ToString());
                 listBox1.Items.Add(oku[1].ToString());
                 listBox1.Items.Add(oku[2].ToString());
                }
                
                
            }
                
              else 
	         {
                 comboBox2.Items.Clear();
               
                 comboBox2.Enabled = true;
                OleDbConnection bag = new OleDbConnection();
                bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE =" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
                bag.Open();
                string liste = "select * from DERSLER where DERS_KODU";
                OleDbCommand komut = new OleDbCommand(liste, bag);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                   comboBox2.Items.Add(oku[0].ToString());
                }	 
	}
                
           
        }

        private void DERS_SORGULAMA_ISLEMI_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.Items.Add("DERS KODUNA GÖRE".ToString());
            comboBox1.Items.Add("DERS KREDISINE GÖRE".ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                OleDbConnection bag = new OleDbConnection();
                bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE =" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
                bag.Open();
                string liste = "select * from DERSLER where DERS_KODU= @T1";
                OleDbCommand komut = new OleDbCommand(liste, bag);
                komut.Parameters.Add("T1",textBox1.Text);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    listBox1.Items.Add(oku[0].ToString());
                    listBox2.Items.Add(oku[1].ToString());
                    listBox3.Items.Add(oku[2].ToString());
                }
                MessageBox.Show("KAYIT LİSTELENDİ");
                comboBox2.Items.Clear();
                textBox1.Clear();
   
             }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string NO = comboBox2.SelectedItem.ToString();
            textBox1.Text = NO;
           
        }
    }
}
