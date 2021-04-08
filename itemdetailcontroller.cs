using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WindowsFormsApp6
{
    class itemdetailcontroller
    {

        public List<int> txtcustid;
        public List<int> offset;
        public List<string> CustName;
        // internal static object itemdetail;

        public itemdetailcontroller()
        {
            LoadIndex();
        }
        public void LoadIndex()
        {

            using (FileStream fs = new FileStream("CustomerIndex.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader LoginReader = new StreamReader(fs))
                {
                    string line = "";
                    try
                    {
                        txtcustid = new List<int>();

                        offset = new List<int>();

                        while ((line = LoginReader.ReadLine()) != null)
                        {
                            string[] subStr = line.Split('|');
                            txtcustid.Add(int.Parse(subStr[0]));
                            offset.Add(int.Parse(subStr[1]));

                        }
                        LoginReader.Close();
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine();
                    }
                }

                fs.Close();
            }

            SortRecord();
        }

        internal itemdetail Searchcustomer(string v)
        {
            throw new NotImplementedException();
        }

        internal itemdetail Searchcustomer()
        {
            throw new NotImplementedException();
        }


        void SortRecord()
        {
            for (int i = 0; i < txtcustid.Count; i++)
            {
                for (int j = 0; j < txtcustid.Count - 1; j++)
                {
                    if (txtcustid[j] > txtcustid[j + 1])
                    {
                        int temp = txtcustid[j + 1];
                        txtcustid[j + 1] = txtcustid[j];
                        txtcustid[j] = temp;

                        temp = offset[j + 1];
                        offset[j + 1] = offset[j];
                        offset[j] = temp;
                    }
                }
            }
        }

        public int InsertRecord(int Customer_ID, string Fname, string Lname, string email, string phone)
        {
            int index = txtcustid.FindIndex(o => o == Customer_ID);

            if (index != -1)
                return -1;

            using (FileStream fs = new FileStream("CustomerDetails.txt", FileMode.Append))
            {
                using (StreamWriter StuWriter = new StreamWriter(fs))
                {

                    using (FileStream fsIndex = new FileStream("CustomerIndex.txt", FileMode.Append))
                    {
                        using (StreamWriter StuIndexWriter = new StreamWriter(fsIndex))
                        {
                            StuIndexWriter.WriteLine(Customer_ID + "|" + StuWriter.BaseStream.Position);
                            StuIndexWriter.Close();
                            LoadIndex();
                        }
                        fsIndex.Close();
                    }

                    StuWriter.WriteLine(Customer_ID + "|" + Fname + "|" + Lname + "|" + email + "|" + phone + "$");
                    StuWriter.Close();
                }
                fs.Close();
            }

            return Customer_ID;
        }

        public List<itemdetail> GetAllitem()
        {
            List<itemdetail> details = new List<itemdetail>();
            for (int i = 0; i < txtcustid.Count; i++)
            {
                details.Add(Searchcustomer(txtcustid[i]));
            }
            return details;
        }
        public itemdetail SearchCustomer(string cuName)
        {
            itemdetail cd = null;
            SortByName();
            int pos = GetPosition(cuName);


            if (pos != -1)
            {
                using (FileStream LoginReader = new FileStream("CustomerDetails.txt", FileMode.Open))
                {
                    cd = new itemdetail();
                    string line = "";
                    int chr;
                    LoginReader.Seek(pos, SeekOrigin.Begin);
                    while ((chr = LoginReader.ReadByte()) > 0)
                    {
                        char c;
                        c = Convert.ToChar(chr);
                        if (c == '$')
                        {
                            break;
                        }
                        line += c;
                    }
                    string[] subStr = line.Split('|');
                    cd.Customer_ID = int.Parse(subStr[0]);
                    cd.Fname = subStr[1];
                    cd.Lname = subStr[2];
                    cd.email = subStr[3];
                    cd.phone = subStr[4];
                    
     

                }
                return cd;
            }
            return cd;

        }

        public itemdetail Searchcustomer(int Boid)
        {
            itemdetail cd = null;
            int pos = GetPosition(Boid);
            if (pos != -1)
            {
                using (FileStream LoginReader = new FileStream("CustomerDetails.txt", FileMode.Open))
                {
                    cd = new itemdetail();
                    string line = "";
                    int chr;
                    LoginReader.Seek(pos, SeekOrigin.Begin);
                    while ((chr = LoginReader.ReadByte()) > 0)
                    {
                        char c;
                        c = Convert.ToChar(chr);
                        if (c == '$')
                        {
                            break;
                        }
                        line += c;
                    }
                    string[] subStr = line.Split('|');
                    try
                    {
                        cd.Customer_ID = int.Parse(subStr[0]);
                        cd.Fname = subStr[1];
                        cd.Lname = subStr[2];
                        cd.email = subStr[3];
                        cd.phone = subStr[4];
                        
                        
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.StackTrace);
                        Console.Out.WriteLine("inside search customer error ---------------------");

                    }

                }
                return cd;
            }
            return cd;
        }

        public void SortByName()
        {
            for (int i = 0; i < CustName.Count; i++)
            {
                for (int j = 0; j < CustName.Count - 2; j++)
                {
                    if (string.Compare(CustName[j], CustName[j + 1]) > 0)
                    {
                        int temp = txtcustid[j + 1];
                        txtcustid[j + 1] = txtcustid[j];
                        txtcustid[j] = temp;

                        temp = offset[j + 1];
                        offset[j + 1] = offset[j];
                        offset[j] = temp;

                        string tmp = "";
                        tmp = CustName[j + 1];
                        CustName[j + 1] = CustName[j];
                        CustName[j] = tmp;
                    }
                }
            }
        }
        public int GetPosition(int IID)
        {
            int low = 0, high = txtcustid.Count;

            for (low = 0; low <= high;)
            {
                int mid = (low + high) / 2;
                if (txtcustid[mid] == IID)
                {
                    return offset[mid];
                }
                else if (txtcustid[mid] < IID)
                    low = mid + 1;
                else if (txtcustid[mid] > IID)
                    high = mid - 1;
            }
            return -1;
        }
        public int GetPosition(string _stuName)
        {
            int low = 0, high = txtcustid.Count - 1;
            for (low = 0; low <= high;)
            {
                int mid = (low + high) / 2;
                if (CustName[mid].Equals(_stuName))
                {
                    return offset[mid];
                }
                else if (string.Compare(CustName[mid], _stuName) < 0)
                    low = mid + 1;
                else if (string.Compare(CustName[mid], _stuName) > 0)
                    high = mid - 1;
            }
            return -1;
        }

        public int GetNextcustID()
        {
            int nextcustID;

            if (txtcustid.Count == 0)
                nextcustID = 1;
            else
                nextcustID = txtcustid[txtcustid.Count - 1] + 1;

            return nextcustID;
        }
        public void DeleteRecord(int Iid)
        {
            long CurrentOffset = 0;
            using (FileStream fs = new FileStream("CustomerDetails.txt", FileMode.OpenOrCreate))
            {

                string line = "";
                int chr;
                bool FoundFlag = false;
                while ((chr = fs.ReadByte()) > 0)
                {
                    char c;

                    c = Convert.ToChar(chr);
                    if (char.IsWhiteSpace(c))
                        continue;
                    if (c == '$')
                    {

                        string[] subStr = line.Split('|');
                        int empid;
                        bool flag = int.TryParse(subStr[0], out empid);
                        if (flag)
                            if (Iid == empid)
                            {
                                FoundFlag = true;
                                break;
                            }
                            else
                                CurrentOffset = fs.Position;
                        line = "";
                    }
                    else
                        line += c;
                }

                if (FoundFlag)
                {
                    fs.Seek(CurrentOffset, SeekOrigin.Begin);
                    byte[] b;
                    if (CurrentOffset == 0)
                        b = new byte[] { Convert.ToByte('#') };
                    else
                        b = new byte[] { Convert.ToByte('\r'), Convert.ToByte('\n'), Convert.ToByte('#') };
                    fs.Write(b, 0, b.Length);
                }
                
                fs.Close();
            }
            LoadIndex();

        }


    }
}


