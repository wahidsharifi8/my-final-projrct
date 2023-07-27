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

namespace WindowsFormsApplication6
{
    public partial class add_product_name : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hashmat yk\documents\visual studio 2012\Projects\WindowsFormsApplication6\WindowsFormsApplication6\inventory.mdf;Integrated Security=True");
        public add_product_name()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void add_product_name_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_dd();
            fill_dg();
        }
        public void fill_dd()
        {
            comboBox1.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["unit"].ToString());
            }
        }

        public void fill_dg()
        {
           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into product_name values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() +"')";
            cmd.ExecuteNonQuery();

            textBox1.Text = "";
            fill_dg();
            MessageBox.Show("Record inserted successfully");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            comboBox2.Items.Clear();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from units";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                comboBox2.Items.Add(dr2["unit"].ToString());
            }

            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product_name where id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["product_name"].ToString();
                comboBox2.SelectedItem = dr["units"].ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            MessageBox.Show(i.ToString());
           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update product_name set product_name='" + textBox2.Text + "',units='"+comboBox2.SelectedItem.ToString() +"'where id="+i+"";
            cmd.ExecuteNonQuery();
            panel2.Visible = false;
            fill_dg();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
