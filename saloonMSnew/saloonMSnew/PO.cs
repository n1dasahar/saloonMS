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

namespace saloonMSnew
{
    public partial class PO : Form
    {
        connection conn = new connection();
        Form1 f1 = new Form1();
        
        public PO()
        {
            InitializeComponent();
            
        }

        private void PO_Load(object sender, EventArgs e)
        {
            {
                int c = 0;
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select count(poid)from po_tbl", conn.sqlConnection1);
                SqlDataReader dr = smd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                }
                textBox1.Text = "00" + c.ToString();
                conn.sqlConnection1.Close();
            }
            {
                this.textBox2.Text =System.DateTime.Today.Date.ToString();
            }
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select vid from vendor_tbl2", conn.sqlConnection1);
                SqlDataReader dr = smd.ExecuteReader();
                while(dr.Read())
                {
                    comboBox1.Items.Add(dr["vid"]).ToString();

                }
                conn.sqlConnection1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("insert into po_tbl(poid,podate,vid,amount,product)values(@poid,@podate,@vid,@amount,@product)", conn.sqlConnection1);
                smd.Parameters.AddWithValue("@poid", textBox1.Text);
                smd.Parameters.AddWithValue("@podate", textBox2.Text);
                smd.Parameters.AddWithValue("@vid", comboBox1.Text);
                smd.Parameters.AddWithValue("@amount", textBox3.Text);
                smd.Parameters.AddWithValue("@product", textBox4.Text);
                
                smd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();

            }
            {
                GRN grn = new GRN();
                grn.Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
