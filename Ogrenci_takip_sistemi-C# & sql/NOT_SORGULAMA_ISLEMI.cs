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
    public partial class NOT_SORGULAMA_ISLEMI : Form
    {
        public NOT_SORGULAMA_ISLEMI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
            
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            listBox10.Items.Clear();
            
            
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE =" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();
            if (comboBox2.Text =="")
            {
                string liste = "select * from NOTLAR where  @T2>=@T1";
                OleDbCommand komut = new OleDbCommand(liste, bag);
                komut.Parameters.Add("T2", comboBox1.Text);
                komut.Parameters.Add("T1", textBox1.Text);

                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    listBox1.Items.Add(oku[0].ToString());
                    listBox2.Items.Add(oku[1].ToString());
                    listBox3.Items.Add(oku[2].ToString());
                    listBox4.Items.Add(oku[3].ToString());
                    listBox5.Items.Add(oku[4].ToString());
                    listBox6.Items.Add(oku[5].ToString());
                    listBox7.Items.Add(oku[6].ToString());
                    listBox8.Items.Add(oku[7].ToString());
                    listBox9.Items.Add(oku[8].ToString());
                    listBox10.Items.Add(oku[9].ToString());


                }
                MessageBox.Show("KAYIT LİSTELENİYO");  
            }
            else
            {
                string liste = "select * from NOTLAR where DURUM= @T2";
                OleDbCommand komut = new OleDbCommand(liste, bag);
                komut.Parameters.Add("T2", comboBox2.Text);
                 OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    listBox1.Items.Add(oku[0].ToString());
                    listBox2.Items.Add(oku[1].ToString());
                    listBox3.Items.Add(oku[2].ToString());
                    listBox4.Items.Add(oku[3].ToString());
                    listBox5.Items.Add(oku[4].ToString());
                    listBox6.Items.Add(oku[5].ToString());
                    listBox7.Items.Add(oku[6].ToString());
                    listBox8.Items.Add(oku[7].ToString());
                    listBox9.Items.Add(oku[8].ToString());
                    listBox10.Items.Add(oku[9].ToString());


                }
                MessageBox.Show("KAYIT LİSTELENİYO");
            }
          
           
        }

        private void NOT_SORGULAMA_ISLEMI_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            if (comboBox1.Text=="DURUM")
            {
                textBox1.Enabled = false;
                comboBox2.Enabled = true;  
                 comboBox2.Items.Add("GEÇTİ".ToString());
                comboBox2.Items.Add("KALDI");

            }
            
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

    }
}
