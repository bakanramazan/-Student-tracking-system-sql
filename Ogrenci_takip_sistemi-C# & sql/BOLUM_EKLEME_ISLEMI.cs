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
    public partial class BOLUM_EKLEME_ISLEMI : Form
    {
        public BOLUM_EKLEME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag.Open();

            string sql = "insert into BOLUMLER (BOLUM_KODU,BOLUM_ADI)";
          
            
                sql = sql + "values (" + textBox1.Text + ",'" + textBox2.Text + "')";
           
            OleDbCommand komut = new OleDbCommand(sql, bag);
            int islem = komut.ExecuteNonQuery();
            if (islem == 1)
            {
                MessageBox.Show("kayıt eklendi");
                textBox1.Clear();
                textBox2.Clear();
              
            }
            else if(islem==0)
            {
                MessageBox.Show("kayıt hatası olabilir tekrar deneyin!");
                textBox1.Clear();
                textBox2.Clear();
               
            }
        }
    }
}
