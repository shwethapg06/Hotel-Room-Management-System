using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    class ReservationDetail
    {
        public int Reserve_ID { get; set; }
        public int Customer_ID { get; set; }
        public string Room_Type { get; set; }

        public int Room_Number { get; set; }
        public string Date_In { get; set; }
        public string Date_Out { get; set; }
    }
}
