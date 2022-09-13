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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
       SqlConnection con= new SqlConnection(@"Data Source=DESKTOP-QTFQRMV;Initial Catalog=asansor;Integrated Security=True");
        SqlDataAdapter da;
        private void Ara_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT ücret,tarih  FROM bakimlar Where tarih BETWEEN @tar1 and @tar2";
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            adp.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Text);
            adp.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Text);
            adp.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
