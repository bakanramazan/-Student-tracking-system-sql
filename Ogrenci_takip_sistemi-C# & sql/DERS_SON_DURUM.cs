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
    public partial class DERS_SON_DURUM : Form
    {
        public DERS_SON_DURUM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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

            string sql = "select * from DERSLER";
            OleDbDataAdapter oku = new OleDbDataAdapter(sql, bag);
            DataTable dt = new DataTable();
            oku.Fill(dt);
            dataGridView1.DataSource = dt;

            MessageBox.Show("Kayıt Listelendi");
            bag.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
           
        }
    }
}
