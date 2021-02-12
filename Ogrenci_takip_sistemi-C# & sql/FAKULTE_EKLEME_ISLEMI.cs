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
    public partial class FAKULTE_EKLEME_ISLEMI : Form
    {
        public FAKULTE_EKLEME_ISLEMI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
             OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb");
            bag.Open();

            string sql = "insert into FAKULTELER(FAK_KODU,FAK_ADI)";

            sql = sql + "values (" + textBox1.Text + ",'" + textBox2.Text + "')";
            OleDbCommand komut = new OleDbCommand(sql, bag);
            int islem = komut.ExecuteNonQuery();
            if (islem == 1)
            {
                MessageBox.Show("kayıt eklendi");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("kayıt hatası olabilir tekrar deneyin!");
                textBox1.Clear();
                textBox2.Clear();
            }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }
    }
}
