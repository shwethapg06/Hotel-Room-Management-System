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
    public partial class welcompage : Form
    {
        public welcompage()
        {
            InitializeComponent();
        }

        private void welcompage_Load(object sender, EventArgs e)
        {

        }

        private void btnwelcome_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }
    }
}
