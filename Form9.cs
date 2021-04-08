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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        billdetail cd;
        SearchController sc;
        billcontroller cc;
        bool a;
        DataTable dt;

        private void btnview_Click(object sender, EventArgs e)
        {
            billcontroller sc = new billcontroller();
            dt = new DataTable();
            dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
            dt.Columns.Add("Payment", System.Type.GetType("System.String"));
           



            List<billdetail> sd = sc.GetAllitem();
            foreach (var s in sd)
            {
                dt.Rows.Add(new object[] {
                    s.Customer_ID,s.Room_Type,s.Payment});
            }
            dataGridView1.DataSource = dt;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
                 billcontroller bi = new billcontroller();
                int i = bi.InsertRecord(int.Parse(txtcustid.Text), cmbroomtype.SelectedItem.ToString(), cmbpayments.SelectedItem.ToString());
                if (i == -1)
                {
                    // MessageBox.Show("one or more fields are empty");
                }
                else
                {
                    btninsert_Click(sender, e);
                    MessageBox.Show("Payment Done");
                txtcustid.Clear();
                cmbroomtype.Text = "";
                cmbpayments.Text = "";
                }
            
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            int id;

            bool flag = int.TryParse(txtcustid.Text, out id);
            if (!flag)
            {
                MessageBox.Show("Invalid ID");
                return;
            }


            billcontroller std = new billcontroller();
            billdetail i = std.Searchcustomer(id);
            if (i != null)
            {
                a = true;
                txtcustid.Text = i.Customer_ID.ToString();

            }
            else
            {
                a = false;
                MessageBox.Show("Record Not Found");

            }
            billcontroller sc = new billcontroller();
            dt = new DataTable();
            if (a == true)
            {
               
                dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
                dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
                dt.Columns.Add("Payment", System.Type.GetType("System.String"));

                List<billdetail> d = sc.GetAllitem();

                foreach (var s in d)
                {
                    if (id == s.Customer_ID)
                        dt.Rows.Add(new object[] {  s.Customer_ID, s.Room_Type, s.Payment });

                }
                dataGridView1.DataSource = dt;
            }
        }
    }
}
