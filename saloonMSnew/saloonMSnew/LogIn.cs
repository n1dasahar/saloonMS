using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saloonMSnew
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="Nida Sahar" && textBox2.Text=="1234")
            {
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                MessageBox.Show("You Entered Wrong User Name Or Password");
            }

        }
    }
}
