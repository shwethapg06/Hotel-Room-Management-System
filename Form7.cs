using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form7 : Form
    {
        ReservationDetailController rdt;
        public Form7()
        {
            InitializeComponent();
            Random r = new Random();
            int num = r.Next(100, 500);
            int n = r.Next(100, 500);
            int no = r.Next(100, 500);
            txtreserveid.Text = num.ToString();
            txtcustid.Text = n.ToString();
            txtroomno.Text = no.ToString();

        }
        int searchType = -1;
        int id = -1;
        ReservationDetail cd;
        SearchController sc;
        ReservationDetailController cc;
        bool a;
        DataTable dt;

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void btninsert2_Click(object sender, EventArgs e)
        {
            ReservationDetailController re = new ReservationDetailController();
            if (string.IsNullOrWhiteSpace(txtreserveid.Text) || string.IsNullOrWhiteSpace(txtcustid.Text)  || string.IsNullOrWhiteSpace(txtroomno.Text) || string.IsNullOrWhiteSpace(txtdatein.Text)|| string.IsNullOrWhiteSpace(txtdateout.Text))
            {
                MessageBox.Show("One or More fields are empty");
            }
            else
            {
                int i = re.InsertRecord(int.Parse(txtreserveid.Text), int.Parse(txtcustid.Text), comboroomtype.SelectedItem.ToString(), int.Parse(txtroomno.Text), txtdatein.Text, txtdateout.Text);
                if (i == -1)
                {
                    // MessageBox.Show("one or more fields are empty");
                }
                else
                {
                    btninsert2_Click(sender, e);
                    MessageBox.Show("Record Added");
                    Random r = new Random();
                    int num = r.Next(100, 500);
                    int n = r.Next(100, 500);
                    int no = r.Next(100, 500);
                    txtreserveid.Text = num.ToString();
                    txtcustid.Text = n.ToString();
                    txtroomno.Text = no.ToString();
                    comboroomtype.Text = "";
                    txtdatein.Clear();
                    txtdateout.Clear();


                }
            }


        }

        private void btnedit2_Click(object sender, EventArgs e)
        {

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            ReservationDetailController sc = new ReservationDetailController();
            dt = new DataTable();
            dt.Columns.Add("Reserve_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Number", System.Type.GetType("System.String"));
            dt.Columns.Add("Date_In", System.Type.GetType("System.String"));
            dt.Columns.Add("Date_Out", System.Type.GetType("System.String"));




            List<ReservationDetail> sd = sc.GetAllitem();
            foreach (var s in sd)
            {
                dt.Rows.Add(new object[] {
                    s.Reserve_ID,s.Customer_ID,s.Room_Type,s.Room_Number,s.Date_In,s.Date_Out});
            }
            dataGridView1.DataSource = dt;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            int id;

            bool flag = int.TryParse(txtreserveid.Text, out id);
            if (!flag)
            {
                MessageBox.Show("Invalid ID");
                return;
            }


            ReservationDetailController std = new ReservationDetailController();
            ReservationDetail i = std.Searchcustomer(id);
            if (i != null)
            {
                a = true;
                txtreserveid.Text = i.Reserve_ID.ToString();

            }
            else
            {
                a = false;
                MessageBox.Show("Record Not Found");

            }
            ReservationDetailController sc = new ReservationDetailController();
            dt = new DataTable();
            if (a == true)
            {
                dt.Columns.Add("Reserve_ID", System.Type.GetType("System.String"));
                dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
                dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
                dt.Columns.Add("Room_Number", System.Type.GetType("System.String"));
                dt.Columns.Add("Date_in", System.Type.GetType("System.String"));
                dt.Columns.Add("Date_out", System.Type.GetType("System.String"));

                List<ReservationDetail> d = sc.GetAllitem();

                foreach (var s in d)
                {
                    if (id == s.Reserve_ID)
                        dt.Rows.Add(new object[] { s.Reserve_ID, s.Customer_ID, s.Room_Type, s.Room_Number, s.Date_In, s.Date_Out });

                }
                dataGridView1.DataSource = dt;
            }
        }
        private List<ReservationDetail> GetAllitem()
        {
            throw new NotImplementedException();
        }

        private void btndelete3_Click(object sender, EventArgs e)
        {

            cc = new ReservationDetailController();

            dt = new DataTable("SearchRecords");

            dt.Columns.Add("Reserve_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Customer_ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Number", System.Type.GetType("System.String"));
            dt.Columns.Add("Date_in", System.Type.GetType("System.String"));
            dt.Columns.Add("Date_out", System.Type.GetType("System.String"));
            dataGridView1.DataSource = dt;
            btndelete3.Visible = false;
            DialogResult dr = MessageBox.Show("You want to delete the record ?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (id != -1)
                {
                    cc.DeleteRecord(id);

                    dt.Rows.Clear();
                    MessageBox.Show("Record Deleted");
                    btndelete3.Visible = false;
                }
            }
            searchType = 0;
            bool flag = false;
            ReservationDetail cd = null;
            flag = int.TryParse(txtreserveid.Text, out id);
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
                   cd.Reserve_ID, cd.Customer_ID, cd.Room_Type, cd.Room_Number, cd.Date_In,cd.Date_Out  });
                btndelete3.Visible = true;


            }
            else
            {
                dt.Rows.Clear();
                MessageBox.Show("Record Not Found");
                id = -1;
                btndelete3.Visible = false;
            }

        }
    }
   
}
