using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Asansorotomasyon
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        private void Form7_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from urunler ", baglanti);
            SqlDataReader ra = komut.ExecuteReader();
            while (ra.Read())
            {
                comboBox1.Items.Add(ra["ürünler"]);

            }




            baglanti.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from urunler where ürünler like'" + comboBox1.Text + "'", baglanti);
            SqlDataReader ra1 = komut1.ExecuteReader();
            while (ra1.Read())
            {
                int a = Convert.ToInt32(ra1["fiyat"]);

                int adet = Convert.ToInt32(comboBox2.Text);
                textBox1.Text = (adet * a).ToString();

            }


            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ekl1 = "INSERT INTO giderler(malzeme,adet,ücret) VALUES ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "')";
            SqlCommand komut = new SqlCommand(ekl1, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Siparişiniz eklenmiştir.");
            this.Close();
        }
    }
}
