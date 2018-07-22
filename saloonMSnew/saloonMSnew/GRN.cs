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
    public partial class GRN : Form
    {
        connection conn = new connection();
        public GRN()
        {
            InitializeComponent();
        }

        private void GRN_Load(object sender, EventArgs e)
        {
            {
                {
                    int c = 0;
                    conn.sqlConnection1.Open();
                    SqlCommand smd = new SqlCommand("select count(grnid)from grn_tbl", conn.sqlConnection1);
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
                    this.textBox2.Text = System.DateTime.Today.Date.ToString();
                }
                {
                    conn.sqlConnection1.Open();
                    SqlCommand smd = new SqlCommand("select poid from po_tbl", conn.sqlConnection1);
                    SqlDataReader dr = smd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["poid"]).ToString();

                    }
                    conn.sqlConnection1.Close();
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                {
                    conn.sqlConnection1.Open();
                    SqlCommand smd = new SqlCommand("select* from po_tbl where poid='" + comboBox1.Text + "'", conn.sqlConnection1);
                    SqlDataReader dr = smd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox3.Text = dr["vid"].ToString();
                       
                    }
                    conn.sqlConnection1.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("insert into grn_tbl(grnid,grndate,poid,vid)values(@grnid,@grndate,@poid,@vid)", conn.sqlConnection1);
                smd.Parameters.AddWithValue("@grnid", textBox1.Text);
                smd.Parameters.AddWithValue("@grndate", textBox2.Text);
                smd.Parameters.AddWithValue("@poid", comboBox1.Text);
                smd.Parameters.AddWithValue("@vid", textBox3.Text);
                

                smd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();

            }
            {
                Invoic inv = new Invoic();
                inv.Show();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
