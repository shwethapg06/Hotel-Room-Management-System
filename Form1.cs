using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Username or Password is missing");
            }
            else
            {
                if(txtusername.Text=="STAFF" && txtpassword.Text=="staff")
                {
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("Username and Password is incorrect");
                    txtusername.Clear();
                    txtpassword.Clear();
                }
            }
           
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
