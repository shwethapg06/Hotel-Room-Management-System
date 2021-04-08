using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WindowsFormsApp6
{
    class ReservationDetailController
    {

        public List<int> txtreserveid;
        public List<int> offset;
        public List<string> ReserveName;
        // internal static object itemdetail;

        public ReservationDetailController()
        {
            LoadIndex();
        }
        public void LoadIndex()
        {

            using (FileStream fs = new FileStream("ReservationIndex.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader LoginReader = new StreamReader(fs))
                {
                    string line = "";
                    try
                    {
                        txtreserveid = new List<int>();

                        offset = new List<int>();

                        while ((line = LoginReader.ReadLine()) != null)
                        {
                            string[] subStr = line.Split('|');
                            txtreserveid.Add(int.Parse(subStr[0]));
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

        internal ReservationDetail Searchcustomer(string v)
        {
            throw new NotImplementedException();
        }

        internal ReservationDetail Searchcustomer()
        {
            throw new NotImplementedException();
        }


        void SortRecord()
        {
            for (int i = 0; i < txtreserveid.Count; i++)
            {
                for (int j = 0; j < txtreserveid.Count - 1; j++)
                {
                    if (txtreserveid[j] > txtreserveid[j + 1])
                    {
                        int temp = txtreserveid[j + 1];
                        txtreserveid[j + 1] = txtreserveid[j];
                        txtreserveid[j] = temp;

                        temp = offset[j + 1];
                        offset[j + 1] = offset[j];
                        offset[j] = temp;
                    }
                }
            }
        }

        public int InsertRecord(int Reserve_ID, int Customer_ID, string Room_Type, int Room_Number, string Date_In, string Date_Out)
        {
            int index = txtreserveid.FindIndex(o => o == Reserve_ID);

            if (index != -1)
                return -1;

            using (FileStream fs = new FileStream("ReservationDetails.txt", FileMode.Append))
            {
                using (StreamWriter StuWriter = new StreamWriter(fs))
                {

                    using (FileStream fsIndex = new FileStream("ReservationIndex.txt", FileMode.Append))
                    {
                        using (StreamWriter StuIndexWriter = new StreamWriter(fsIndex))
                        {
                            StuIndexWriter.WriteLine(Reserve_ID + "|" + StuWriter.BaseStream.Position);
                            StuIndexWriter.Close();
                            LoadIndex();
                        }
                        fsIndex.Close();
                    }

                    StuWriter.WriteLine(Reserve_ID + "|" + Customer_ID + "|" + Room_Type + "|" + Room_Number + "|" + Date_In + "|" + Date_Out + "$");
                    StuWriter.Close();
                }
                fs.Close();
            }

            return Reserve_ID;
        }

        public List<ReservationDetail> GetAllitem()
        {
            List<ReservationDetail> details = new List<ReservationDetail>();
            for (int i = 0; i < txtreserveid.Count; i++)
            {
                details.Add(Searchcustomer(txtreserveid[i]));
            }
            return details;
        }
        public ReservationDetail SearchCustomer(string reName)
        {
            ReservationDetail cd = null;
            SortByName();
            int pos = GetPosition(reName);


            if (pos != -1)
            {
                using (FileStream LoginReader = new FileStream("ReservationDetails.txt", FileMode.Open))
                {
                    cd = new ReservationDetail();
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
                    cd.Reserve_ID = int.Parse(subStr[0]);
                    cd.Customer_ID = int.Parse(subStr[1]);
                    cd.Room_Type = subStr[2];
                    cd.Room_Number = int.Parse(subStr[3]);
                    cd.Date_In = subStr[4];
                    cd.Date_Out = subStr[5];



                }
                return cd;
            }
            return cd;

        }

        public ReservationDetail Searchcustomer(int Boid)
        {
            ReservationDetail cd = null ;
            int pos = GetPosition(Boid);
            if (pos != -1)
            {
                using (FileStream LoginReader = new FileStream("ReservationDetails.txt", FileMode.Open))
                {
                    cd = new ReservationDetail();
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
                        cd.Reserve_ID = int.Parse(subStr[0]);
                        cd.Customer_ID = int.Parse(subStr[1]);
                        cd.Room_Type = subStr[2];
                        cd.Room_Number = int.Parse(subStr[3]);
                        cd.Date_In = subStr[4];
                        cd.Date_Out = subStr[5];
                        


                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.StackTrace);
                        Console.Out.WriteLine("inside search Reservation error ---------------------");

                    }

                }
                return cd;
            }
            return cd;
        }

        public void SortByName()
        {
            for (int i = 0; i < ReserveName.Count; i++)
            {
                for (int j = 0; j < ReserveName.Count - 2; j++)
                {
                    if (string.Compare(ReserveName[j], ReserveName[j + 1]) > 0)
                    {
                        int temp = txtreserveid[j + 1];
                        txtreserveid[j + 1] = txtreserveid[j];
                        txtreserveid[j] = temp;

                        temp = offset[j + 1];
                        offset[j + 1] = offset[j];
                        offset[j] = temp;

                        string tmp = "";
                        tmp = ReserveName[j + 1];
                        ReserveName[j + 1] = ReserveName[j];
                        ReserveName[j] = tmp;
                    }
                }
            }
        }
        public int GetPosition(int IID)
        {
            int low = 0, high = txtreserveid.Count;

            for (low = 0; low <= high;)
            {
                int mid = (low + high) / 2;
                if (txtreserveid[mid] == IID)
                {
                    return offset[mid];
                }
                else if (txtreserveid[mid] < IID)
                    low = mid + 1;
                else if (txtreserveid[mid] > IID)
                    high = mid - 1;
            }
            return -1;
        }
        public int GetPosition(string _stuName)
        {
            int low = 0, high = txtreserveid.Count - 1;
            for (low = 0; low <= high;)
            {
                int mid = (low + high) / 2;
                if (ReserveName[mid].Equals(_stuName))
                {
                    return offset[mid];
                }
                else if (string.Compare(ReserveName[mid], _stuName) < 0)
                    low = mid + 1;
                else if (string.Compare(ReserveName[mid], _stuName) > 0)
                    high = mid - 1;
            }
            return -1;
        }

        public int GetNextcustID()
        {
            int nextcustID;

            if (txtreserveid.Count == 0)
                nextcustID = 1;
            else
                nextcustID = txtreserveid[txtreserveid.Count - 1] + 1;

            return nextcustID;
        }
        public void DeleteRecord(int Iid)
        {
            long CurrentOffset = 0;
            using (FileStream fs = new FileStream("ReservationDetails.txt", FileMode.OpenOrCreate))
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



