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
    public partial class Invoic : Form
    {
        connection conn = new connection();
        public Invoic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("insert into invoice(invoiceid,vid,amountpayable)values(@invoiceid,@vid,@amountpayable)", conn.sqlConnection1);
                smd.Parameters.AddWithValue("@invoiceid", textBox1.Text);
                smd.Parameters.AddWithValue("@vid", comboBox1.Text);
                smd.Parameters.AddWithValue("@amountpayable", textBox2.Text);
                


                smd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();

            }
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Invoic_Load(object sender, EventArgs e)
        {
            {
                int c = 0;
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select count(invoiceid)from invoice", conn.sqlConnection1);
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
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select vid from vendor_tbl2", conn.sqlConnection1);
                SqlDataReader dr = smd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["vid"]).ToString();

                }
                conn.sqlConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
