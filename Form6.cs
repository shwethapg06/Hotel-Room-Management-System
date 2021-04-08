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
    public partial class Form6 : Form
    {
        RoomDetailController romdcon;
        public Form6()
        {
            InitializeComponent();
            Random r = new Random();
            int num = r.Next(100, 500);
            txtnumber.Text = num.ToString();
        }
        int searchType = -1;
        int id = -1;
        RoomDetail cd;
        SearchController sc;
        RoomDetailController cc;
        bool a;
        DataTable dt;

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void btnroominsert_Click(object sender, EventArgs e)
        {
            RoomDetailController room = new RoomDetailController();
            if (string.IsNullOrWhiteSpace(txtnumber.Text) || string.IsNullOrWhiteSpace(txtphoneno.Text))
            {
                MessageBox.Show("One or More fields are empty");
            }
            else
            {
                int i = room.InsertRecord(int.Parse(txtnumber.Text), comboroomtype.SelectedItem.ToString(), txtphoneno.Text, cmbreserved.SelectedItem.ToString());
                if (i == -1)
                {
                    // MessageBox.Show("one or more fields are empty");
                }
                else
                {
                    btnroominsert_Click(sender, e);
                    MessageBox.Show("Record Added");
                    Random r = new Random();
                    int num = r.Next(100, 500);
                    txtnumber.Text = num.ToString();
                    comboroomtype.Text = "";
                    txtphoneno.Clear();
                    cmbreserved.Text = "";


                }
            }
        }

        private void cmbreserved_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Click(object sender, EventArgs e)
        {

            RoomDetailController sc = new RoomDetailController();
            dt = new DataTable();
            dt.Columns.Add("Room_Number", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
            dt.Columns.Add("Phone", System.Type.GetType("System.String"));
            dt.Columns.Add("Reserved", System.Type.GetType("System.String"));
            



            List<RoomDetail> sd = sc.GetAllitem();
            foreach (var s in sd)
            {
                dt.Rows.Add(new object[] {
                    s.Room_Number,s.Room_Type,s.Phone,s.Reserved});
            }
            dataGridView1.DataSource = dt;

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            int id;

            bool flag = int.TryParse(txtnumber.Text, out id);
            if (!flag)
            {
                MessageBox.Show("Invalid ID");
                return;
            }


            RoomDetailController std = new RoomDetailController();
            RoomDetail i = std.Searchcustomer(id);
            if (i != null)
            {
                a = true;
                txtnumber.Text = i.Room_Number.ToString();

            }
            else
            {
                a = false;
                MessageBox.Show("Record Not Found");

            }
            RoomDetailController sc = new RoomDetailController();
            dt = new DataTable();
            if (a == true)
            {
                dt.Columns.Add("Room_Number", System.Type.GetType("System.String"));
                dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
                dt.Columns.Add("Phone", System.Type.GetType("System.String"));
                dt.Columns.Add("Reserved", System.Type.GetType("System.String"));
                List<RoomDetail> d = sc.GetAllitem();

                foreach (var s in d)
                {
                    if (id == s.Room_Number)
                        dt.Rows.Add(new object[] { s.Room_Number, s.Room_Type, s.Phone, s.Reserved });

                }
                dataGridView1.DataSource = dt;
            }
        }






        private List<RoomDetail> GetAllitem()
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cc = new RoomDetailController();

            dt = new DataTable("SearchRecords");

            dt.Columns.Add("Room_Number", System.Type.GetType("System.String"));
            dt.Columns.Add("Room_Type", System.Type.GetType("System.String"));
            dt.Columns.Add("Phone", System.Type.GetType("System.String"));
            dt.Columns.Add("Reserved", System.Type.GetType("System.String"));
            
            dataGridView1.DataSource = dt;
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
            RoomDetail cd = null;
            flag = int.TryParse(txtnumber.Text, out id);
            cd = cc.Searchcustomer(id);
            if (cd == null)
                flag = false;
            else
            {
                id = cd.Room_Number;
                searchType = 1;
                flag = true;
            }
            if (flag)
            {
                dt.Rows.Clear();
                dt.Rows.Add(new object[] {
                   cd.Room_Number, cd.Room_Type, cd.Phone, cd.Reserved  });
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
    }
}
