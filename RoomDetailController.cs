using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WindowsFormsApp6
{
    class RoomDetailController
    {

        public List<int> txtnumber;
        public List<int> offset;
        public List<string> RoomName;
        // internal static object itemdetail;

        public RoomDetailController()
        {
            LoadIndex();
        }
        public void LoadIndex()
        {

            using (FileStream fs = new FileStream("RoomIndex.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader LoginReader = new StreamReader(fs))
                {
                    string line = "";
                    try
                    {
                        txtnumber = new List<int>();

                        offset = new List<int>();

                        while ((line = LoginReader.ReadLine()) != null)
                        {
                            string[] subStr = line.Split('|');
                            txtnumber.Add(int.Parse(subStr[0]));
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

        internal RoomDetail Searchcustomer(string v)
        {
            throw new NotImplementedException();
        }

        internal RoomDetail Searchcustomer()
        {
            throw new NotImplementedException();
        }


        void SortRecord()
        {
            for (int i = 0; i < txtnumber.Count; i++)
            {
                for (int j = 0; j < txtnumber.Count - 1; j++)
                {
                    if (txtnumber[j] > txtnumber[j + 1])
                    {
                        int temp = txtnumber[j + 1];
                        txtnumber[j + 1] = txtnumber[j];
                        txtnumber[j] = temp;

                        temp = offset[j + 1];
                        offset[j + 1] = offset[j];
                        offset[j] = temp;
                    }
                }
            }
        }

        public int InsertRecord(int Room_Number, string Room_Type, string Phone, string Reserved)
        {
            int index = txtnumber.FindIndex(o => o == Room_Number);

            if (index != -1)
                return -1;

            using (FileStream fs = new FileStream("RoomDetails.txt", FileMode.Append))
            {
                using (StreamWriter StuWriter = new StreamWriter(fs))
                {

                    using (FileStream fsIndex = new FileStream("RoomIndex.txt", FileMode.Append))
                    {
                        using (StreamWriter StuIndexWriter = new StreamWriter(fsIndex))
                        {
                            StuIndexWriter.WriteLine(Room_Number + "|" + StuWriter.BaseStream.Position);
                            StuIndexWriter.Close();
                            LoadIndex();
                        }
                        fsIndex.Close();
                    }

                    StuWriter.WriteLine(Room_Number + "|" + Room_Type + "|" + Phone + "|" + Reserved + "$");
                    StuWriter.Close();
                }
                fs.Close();
            }

            return Room_Number;
        }

        public List<RoomDetail> GetAllitem()
        {
            List<RoomDetail> details = new List<RoomDetail>();
            for (int i = 0; i < txtnumber.Count; i++)
            {
                details.Add(Searchcustomer(txtnumber[i]));
            }
            return details;
        }
        public RoomDetail SearchCustomer(string ruName)
        {
            RoomDetail cd = null;
            SortByName();
            int pos = GetPosition(ruName);


            if (pos != -1)
            {
                using (FileStream LoginReader = new FileStream("RoomDetails.txt", FileMode.Open))
                {
                    cd = new RoomDetail();
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
                    cd.Room_Number = int.Parse(subStr[0]);
                    cd.Room_Type = subStr[1];
                    cd.Phone = subStr[2];
                    cd.Reserved = subStr[3];
                   



                }
                return cd;
            }
            return cd;

        }

        public RoomDetail Searchcustomer(int Boid)
        {
            RoomDetail cd = null;
            int pos = GetPosition(Boid);
            if (pos != -1)
            {
                using (FileStream LoginReader = new FileStream("RoomDetails.txt", FileMode.Open))
                {
                    cd = new RoomDetail();
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
                        cd.Room_Number = int.Parse(subStr[0]);
                        cd.Room_Type = subStr[1];
                        cd.Phone = subStr[2];
                        cd.Reserved = subStr[3];
                      


                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.StackTrace);
                        Console.Out.WriteLine("inside search Room error ---------------------");

                    }

                }
                return cd;
            }
            return cd;
        }

        public void SortByName()
        {
            for (int i = 0; i < RoomName.Count; i++)
            {
                for (int j = 0; j < RoomName.Count - 2; j++)
                {
                    if (string.Compare(RoomName[j], RoomName[j + 1]) > 0)
                    {
                        int temp = txtnumber[j + 1];
                        txtnumber[j + 1] = txtnumber[j];
                        txtnumber[j] = temp;

                        temp = offset[j + 1];
                        offset[j + 1] = offset[j];
                        offset[j] = temp;

                        string tmp = "";
                        tmp = RoomName[j + 1];
                        RoomName[j + 1] = RoomName[j];
                        RoomName[j] = tmp;
                    }
                }
            }
        }
        public int GetPosition(int IID)
        {
            int low = 0, high = txtnumber.Count;

            for (low = 0; low <= high;)
            {
                int mid = (low + high) / 2;
                if (txtnumber[mid] == IID)
                {
                    return offset[mid];
                }
                else if (txtnumber[mid] < IID)
                    low = mid + 1;
                else if (txtnumber[mid] > IID)
                    high = mid - 1;
            }
            return -1;
        }
        public int GetPosition(string _stuName)
        {
            int low = 0, high = txtnumber.Count - 1;
            for (low = 0; low <= high;)
            {
                int mid = (low + high) / 2;
                if (RoomName[mid].Equals(_stuName))
                {
                    return offset[mid];
                }
                else if (string.Compare(RoomName[mid], _stuName) < 0)
                    low = mid + 1;
                else if (string.Compare(RoomName[mid], _stuName) > 0)
                    high = mid - 1;
            }
            return -1;
        }

        public int GetNextcustID()
        {
            int nextcustID;

            if (txtnumber.Count == 0)
                nextcustID = 1;
            else
                nextcustID = txtnumber[txtnumber.Count - 1] + 1;

            return nextcustID;
        }
        public void DeleteRecord(int Iid)
        {
            long CurrentOffset = 0;
            using (FileStream fs = new FileStream("RoomDetails.txt", FileMode.OpenOrCreate))
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



