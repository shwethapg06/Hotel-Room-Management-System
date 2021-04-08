using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form5 : Form
    {
        itemdetailcontroller itmdcon;
        public Form5()
        {
            InitializeComponent();
            Random r = new Random();
            int num = r.Next(100, 500);
            txtcustid.Text = num.ToString();
        }
        int searchType = -1;
        int id = -1;
        itemdetail cd;
        SearchController sc;
        itemdetailcontroller cc;
        bool a;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            itemdetailcontroller item = new itemdetailcontroller();
            if (string.IsNullOrWhiteSpace(txtcustid.Text) || string.IsNullOrWhiteSpace(txtfirstcust.Text) || string.IsNullOrWhiteSpace(txtlastcust.Text) || string.IsNullOrWhiteSpace(txtcustemail.Text) || string.IsNullOrWhiteSpace(txtcustphone.Text))
            {
                MessageBox.Show("One or More fields are empty");
            }
            else
            {
                int i = item.InsertRecord(int.Parse(txtcustid.Text), txtfirstcust.Text, txtlastcust.Text, txtcustemail.Text, txtcustphone.Text);
                if (i == -1)
                {
                    // MessageBox.Show("one or more fields are empty");
                }
                else
                {
                    btninsert_Click(sender, e);
                    MessageBox.Show("Record Added");
                    /* this.Hide();
                     Form3 f3 = new Form3();
                     f3.Show();*/
                    Random r = new Random();
                    int num = r.Next(100, 500);
                    txtcustid.Text = num.ToString();
                    txtfirstcust.Clear();
                    txtlastcust.Clear();
                    txtcustemail.Clear();
                    txtcustphone.Clear();

                }

            }
        }



        private void btnview_Click(object sender, EventArgs e)
        {
            itemdetailcontroller sc = new itemdetailcontroller();
            dt = new DataTable();
            dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Fname", System.Type.GetType("System.String"));
            dt.Columns.Add("Lname", System.Type.GetType("System.String"));
            dt.Columns.Add("email", System.Type.GetType("System.String"));
            dt.Columns.Add("Phno", System.Type.GetType("System.String"));



            List<itemdetail> sd = sc.GetAllitem();
            foreach (var s in sd)
            {
                dt.Rows.Add(new object[] {
                    s.Customer_ID,s.Fname,s.Lname,s.email,s.phone});
            }
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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


            itemdetailcontroller std = new itemdetailcontroller();
            itemdetail i = std.Searchcustomer(id);
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
            itemdetailcontroller sc = new itemdetailcontroller();
            dt = new DataTable();
            if (a == true)
            {
                dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
                dt.Columns.Add("Fname", System.Type.GetType("System.String"));
                dt.Columns.Add("Lname", System.Type.GetType("System.String"));
                dt.Columns.Add("email", System.Type.GetType("System.String"));
                dt.Columns.Add("phone", System.Type.GetType("System.String"));
                List<itemdetail> d = sc.GetAllitem();

                foreach (var s in d)
                {
                    if (id == s.Customer_ID)
                        dt.Rows.Add(new object[] { s.Customer_ID, s.Fname, s.Lname, s.email, s.phone });

                }
                dataGridView2.DataSource = dt;
            }
        }






        private List<itemdetail> GetAllitem()
        {
            throw new NotImplementedException();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
           
            cc = new itemdetailcontroller();

            dt = new DataTable("SearchRecords");

            dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Fname", System.Type.GetType("System.String"));
            dt.Columns.Add("Lname", System.Type.GetType("System.String"));
            dt.Columns.Add("email", System.Type.GetType("System.String"));
            dt.Columns.Add("phone", System.Type.GetType("System.String"));
            dataGridView2.DataSource = dt;
            btndelete.Visible = false;
            DialogResult dr = MessageBox.Show("You want to delete the record ?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (id != -1)
                {
                    cc.DeleteRecord(id);

                    dt.Rows.Clear();
                    MessageBox.Show("Record Deleted");
                    btndelete.Visible = false;
                }
            }
            searchType = 0;
            bool flag = false;
            itemdetail cd = null;
            flag = int.TryParse(txtcustid.Text, out id);
            cd = cc.Searchcustomer(id);
            if (cd == null)
                flag = false;
            else
            {
                id = cd.Customer_ID;
                searchType = 1;
                flag = true;
            }
            if (flag)
            {
                dt.Rows.Clear();
                dt.Rows.Add(new object[] {
                   cd.Customer_ID, cd.Fname, cd.Lname, cd.email, cd.phone  });
                btndelete.Visible = true;


            }
            else
            {
                dt.Rows.Clear();
                MessageBox.Show("Record Not Found");
                id = -1;
                btndelete.Visible = false;
            }
        
           
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView2.SelectedCells)
            {
                if (oneCell.Selected)
                    dataGridView2.Rows.RemoveAt(oneCell.RowIndex);
            }
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

        }
    }
}












