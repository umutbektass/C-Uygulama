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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");

        public void datagridviewayar(DataGridView data1)
        {
            data1.RowHeadersVisible = false;
            data1.BorderStyle = BorderStyle.None;
            data1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            data1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            data1.DefaultCellStyle.SelectionForeColor = Color.White;
            data1.EnableHeadersVisualStyles = false;
            data1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            data1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            data1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            data1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }
        private void label1_Click(object sender, EventArgs e)
        {
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(1) + this.Text.Substring(0, 1);

             label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            datagridviewayar(dataGridView1);
            // TODO: Bu kod satırı 'asansorDataSet3.bakimlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bakimlarTableAdapter.Fill(this.asansorDataSet3.bakimlar);
            label4.Text = Form1.Gidenbilgi.ToString();
           

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from asansor1 where asansor_no ='" + label4.Text + "'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                label5.Text = dr[1].ToString();
                dr.Close();
                SqlDataAdapter daa = new SqlDataAdapter("Select yapilan_işlem,ücret,tarih from bakimlar where asansor_no='"+label4.Text+"'", baglanti);
                DataTable tabloo = new DataTable();
                daa.Fill(tabloo);
                dataGridView1.DataSource = tabloo;
            
            }
            baglanti.Close();


        
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
