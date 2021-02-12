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
    public partial class FAKULTE_SILME_ISLEMI : Form
    {
        public FAKULTE_SILME_ISLEMI()
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
            OleDbConnection bag = new OleDbConnection();
            bag.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\OGRENCİ_TAKİP.accdb";
            bag.Open();
            string listele = "select * from FAKULTELER";
            OleDbDataAdapter komut = new OleDbDataAdapter(listele,bag);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            dataGridView1.DataSource = dt;

            MessageBox.Show("VERİ LİSTELENDİ");
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
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = " DELETE FROM FAKULTELER WHERE FAK_KODU=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
            komut.ExecuteNonQuery();
            MessageBox.Show("FAKÜLTE SİLİNDİ");
            string listele = "select * from FAKULTELER";
            OleDbDataAdapter komut2 = new OleDbDataAdapter(listele, bag);
            DataTable dt = new DataTable();
            komut2.Fill(dt);
            dataGridView1.DataSource = dt;

            bag.Close();
            }
            catch (Exception HATA)
            {

                MessageBox.Show(HATA.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SEC = e.RowIndex;
            dataGridView1.Rows[SEC].Cells[0].Value.ToString();
            dataGridView1.Rows[SEC].Cells[1].Value.ToString();

        }

    
    }
}
