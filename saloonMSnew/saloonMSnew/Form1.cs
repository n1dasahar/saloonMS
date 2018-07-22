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
    public partial class Form1 : Form
    {
        connection conn = new connection();
        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;

            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button4.Visible = false;
            groupBox1.Visible = true;
            {
                int c = 0;
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select count(cid)from costomer_tbl1", conn.sqlConnection1);
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
                string[] services = { "Facial", "Hair Cutting Of All Type", "Bridal Make Over", "Heena on Both Hands", "Waxing", "Threading + Waxing", "Manicure", "Padicure" };
                comboBox1.Items.AddRange(services);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button4.Visible = true;
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("insert into costomer_tbl1(cid,cname,cnumber,cservice,bil)values(@cid,@cname,@cnumber,@cservice,@bil)", conn.sqlConnection1);
                smd.Parameters.AddWithValue("@cid", textBox1.Text);
                smd.Parameters.AddWithValue("@cname", textBox2.Text);
                smd.Parameters.AddWithValue("@cnumber", textBox3.Text);
                smd.Parameters.AddWithValue("@cservice", comboBox1.Text);
                smd.Parameters.AddWithValue("@bil", textBox4.Text);
                smd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Facial")
            {

                textBox4.Text = "2000";

            }
            if (comboBox1.Text == "Hair Cutting Of All Type")
            {

                textBox4.Text = "800";
            }
            if (comboBox1.Text == "Bridal Make Over")
            {
                textBox4.Text = "15000";
            }
            if (comboBox1.Text == "Heena on Both Hands")
            {
                textBox4.Text = "500";
            }
            if (comboBox1.Text == "Waxing")
            {
                textBox4.Text = "1500";
            }
            if (comboBox1.Text == "Threading + Waxing")
            {
                textBox4.Text = "2000";
            }
            if (comboBox1.Text == "Manicure")
            {
                textBox4.Text = "1200";
            }
            if (comboBox1.Text == "Pedicure")
            {
                textBox4.Text = "1200";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
                {
                    conn.sqlConnection1.Open();
                    SqlCommand smd = new SqlCommand("select * from costomer_tbl1", conn.sqlConnection1);
                    SqlDataReader dr = smd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    conn.sqlConnection1.Close();
                }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PO po = new PO();
            po.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            {
                int c = 0;
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select count(vid)from vendor_tbl2", conn.sqlConnection1);
                SqlDataReader dr = smd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                }
                textBox5.Text = "00" + c.ToString();
                conn.sqlConnection1.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("insert into vendor_tbl2(vid,vname,vnumber,cpname,cpnumber,vaddress)values(@vid,@vname,@vnumber,@cpname,@cpnumber,@vaddress)", conn.sqlConnection1);
                smd.Parameters.AddWithValue("@vid", textBox5.Text);
                smd.Parameters.AddWithValue("@vname", textBox6.Text);
                smd.Parameters.AddWithValue("@vnumber", textBox7.Text);
                smd.Parameters.AddWithValue("@cpname", textBox8.Text);
                smd.Parameters.AddWithValue("@cpnumber", textBox9.Text);
                smd.Parameters.AddWithValue("@vaddress", textBox10.Text);
                smd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();

            }
            {
                PO po = new PO();
                po.Show();
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            dataGridView2.Visible = false;
            button11.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GRN grn = new GRN();
            grn.Show();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Invoic inc = new Invoic();
            inc.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            dataGridView2.Visible = true;
            button11.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            button11.Visible = false;
            groupBox3.Visible = true;
            {
                int c = 0;
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select count(eid)from employee_tbl", conn.sqlConnection1);
                SqlDataReader dr = smd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                }
                textBox11.Text = "00" + c.ToString();
                conn.sqlConnection1.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("insert into employee_tbl(eid,ename,enumber,esalary)values(@eid,@ename,@enumber,@esalary)", conn.sqlConnection1);
                smd.Parameters.AddWithValue("@eid", textBox11.Text);
                smd.Parameters.AddWithValue("@ename", textBox12.Text);
                smd.Parameters.AddWithValue("@enumber", textBox13.Text);
                smd.Parameters.AddWithValue("@esalary", textBox14.Text);
                
                smd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            {
                conn.sqlConnection1.Open();
                SqlCommand smd = new SqlCommand("select * from employee_tbl", conn.sqlConnection1);
                SqlDataReader dr = smd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                conn.sqlConnection1.Close();
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
