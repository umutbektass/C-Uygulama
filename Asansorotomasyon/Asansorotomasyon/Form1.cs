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
    public partial class Form1 : Form
    {
        public static string Gidenbilgi = "";
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Kullanicilar where kadi ='" + textBox1.Text + "' and sifre = '" + textBox2.Text + "'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) { 

                string a = dr[3].ToString();
            if (a == "1")
                {
                    Form1.ActiveForm.Visible = false;
                    Teknisyen form2ac = new Teknisyen();
                    form2ac.Show();
                }
              else  if (a == "2")
                {
                    Form1.ActiveForm.Visible = false;
                    Form3 form3ac = new Form3();
                    form3ac.Show();
                }
                else if (a == "3")
                {
                    Gidenbilgi = dr[4].ToString();
                    Form1.ActiveForm.Visible = false;
                    Form4 form4ac = new Form4();
                    form4ac.Show();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
            baglanti.Close();

        }
    }
}
