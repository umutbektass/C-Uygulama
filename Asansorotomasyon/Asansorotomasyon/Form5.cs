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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
    

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string ekl1 = "INSERT INTO personeller(adsoyad,maas,departman) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            SqlCommand komut = new SqlCommand(ekl1, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklenmiştir.");
            this.Close();

            }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
       
    }

