using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ÖĞRENCİ_TAKİP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
       }
         
        private void button1_Click(object sender, EventArgs e)
        {
            
            string ogrno="007";
            string sifre="12";

            string ogr_no =Convert.ToString(textBox1.Text);
            string sif=Convert.ToString(textBox2.Text);
            if (textBox1.Text=="" || textBox2.Text=="" ||textBox1.Text=="" && textBox2.Text=="")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
            }
            else if (ogr_no!=ogrno||sif!=sifre ||ogr_no!=ogrno && sif!=sifre)
            {
                MessageBox.Show("Öğrenci numarasını veya sifreyi yanlış girdiniz.Lütfen tekrar girin!");
            }
            else
            {
                Form2 frm = new Form2();
                frm.Show();
                

            }
            Form1 frm1 = new Form1();
            frm1.Close();

       }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
