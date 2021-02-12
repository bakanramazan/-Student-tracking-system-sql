﻿using System;
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
    public partial class NOT_SILME_ISLEMI : Form
    {
        public NOT_SILME_ISLEMI()
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
            string listele = "select * from NOTLAR";
            OleDbDataAdapter komut = new OleDbDataAdapter(listele,bag);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            dataGridView1.DataSource = dt;

            MessageBox.Show("VERİ LİSTELENDİ");
            bag.Close();
        }

       public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = e.RowIndex;
            dataGridView1.Rows[sec].Cells[0].Value.ToString();
            dataGridView1.Rows[sec].Cells[1].Value.ToString();
            dataGridView1.Rows[sec].Cells[2].Value.ToString();
            dataGridView1.Rows[sec].Cells[3].Value.ToString();
            dataGridView1.Rows[sec].Cells[4].Value.ToString();
            dataGridView1.Rows[sec].Cells[5].Value.ToString();
            dataGridView1.Rows[sec].Cells[6].Value.ToString();
            dataGridView1.Rows[sec].Cells[7].Value.ToString();
            dataGridView1.Rows[sec].Cells[8].Value.ToString();
            dataGridView1.Rows[sec].Cells[9].Value.ToString();
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
            komut.CommandText = " DELETE FROM NOTLAR WHERE OGR_NO=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
            komut.ExecuteNonQuery();
            MessageBox.Show("NOT SİLİNDİ");
            string listele = "select * from NOTLAR";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
