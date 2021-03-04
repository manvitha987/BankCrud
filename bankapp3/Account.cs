using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp3
{
    class Account
    {
        public int acno { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string date { get; set; }
        public int amount { get; set; }
        public string cheq { get; set; }
        public string actype { get; set; }
        public string status { get; set; }

        public override string ToString()
        {
            return "Account Number : " + acno + "\nFirst Name     : " + fname + "\nLast Name      : " + lname + "\nCity           : " + city + "\nState          : " + state +
                "\nDate of opening:" + date + "\nAmount         : " + amount + "\nCheque Facility: " + cheq + "\nAccount Type   : " + actype + "\nStatus         : " + status;
        }
    }
}
