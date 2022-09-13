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
    public partial class Form3 : Form
    {
        SqlConnection baglanti =new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
      
        

        public Form3()
        {
            InitializeComponent();
        }
        SqlCommand komut;
        SqlDataAdapter da;
        void personelgetir()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From personeller", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            Form5 form5ac = new Form5();
            form5ac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personelgetir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                baglanti.Open();
                komut = new SqlCommand("delete from personeller where personel_no ='"+dataGridView1.SelectedRows[i].Cells["personel_no"].Value.ToString() +"'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                personelgetir();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6ac = new Form6();
            form6ac.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7ac = new Form7();
            form7ac.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullaniciekle= "INSERT INTO Kullanicilar(kadi,sifre,dep_id,asansor_no) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"')";
            SqlCommand komut = new SqlCommand(kullaniciekle, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklenmiştir.");
        }
    }
}
