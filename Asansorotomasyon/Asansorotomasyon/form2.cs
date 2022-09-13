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
    public partial class Teknisyen : Form
    {

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
       
        public Teknisyen()
        {
            InitializeComponent();
      
        }
        public void datagrid(DataGridView datagridview)
        {
            dataGridView1.RowHeadersVisible = false;
        }
        public void datagrid2(DataGridView datagridview)
        {
            dataGridView2.RowHeadersVisible = false;
        }
        public void verisil( int i)
        {
            string sil = "Delete From asansor1 Where asansor_no = @asansor_no";
            komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@asansor_no", i);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
     
        void adresgetir()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From asansor1", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        void bakimgetir()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From bakimlar", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string ekl1="INSERT INTO asansor1(asansor_no,adres,bina_ad,model,kapasite_kg,kurulus_tarihi,aciklama) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+dateTimePicker1.Text+"','"+textBox7.Text+"')";
            komut = new SqlCommand(ekl1, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            adresgetir();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";


        }

        private void form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'asansorDataSet2.bakimlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bakimlarTableAdapter.Fill(this.asansorDataSet2.bakimlar);
            adresgetir();
            bakimgetir();
            datagrid(dataGridView1);
            datagrid2(dataGridView1);



        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
          



        }

        private void button2_Click(object sender, EventArgs e)
        {
          foreach(DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                adresgetir();

            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bakimgetir();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ekl2 = "INSERT INTO bakimlar(asansor_no,adres,yapilan_işlem,ücret,tarih) VALUES ('" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Text + "')";
            komut = new SqlCommand(ekl2, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            adresgetir();
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            bakimgetir();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string silbakim = "DELETE FROM bakimlar WHERE asansor_no=@asansor_no";
            komut = new SqlCommand(silbakim, baglanti);
            komut.Parameters.AddWithValue("@asansor_no", dataGridView2.CurrentRow.Cells[0].Value.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            bakimgetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            




        }

        private void button4_Click(object sender, EventArgs e)
        {
            string guncelle = "UPDATE asansor1 SET asansor_no ='" + textBox1.Text + "',adres='" + textBox2.Text + "',bina_ad='" + textBox3.Text + "',model='" + textBox4.Text + "',kapasite_kg='" + textBox5.Text + "',kurulus_tarihi='" + dateTimePicker1.Text + "',aciklama='" + textBox7.Text + "' WHERE asansor_no='" + textBox1.Text + "'";
            komut = new SqlCommand(guncelle, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            adresgetir();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string gunc2 = "INSERT INTO bakimlar(asansor_no,adres,yapilan_işlem,ücret,tarih) VALUES ('" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value + "')";
            komut = new SqlCommand(gunc2, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            bakimgetir();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();

            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();




        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

        }

        private void dataGridView2_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int a = e.RowIndex;
            textBox6.Text = dataGridView2.Rows[a].Cells[0].Value.ToString();
            textBox8.Text = dataGridView2.Rows[a].Cells[1].Value.ToString();

            textBox9.Text = dataGridView2.Rows[a].Cells[2].Value.ToString();
            textBox10.Text = dataGridView2.Rows[a].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView2.Rows[a].Cells[4].Value.ToString();



        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
