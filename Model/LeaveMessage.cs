using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    public partial class LeaveMessage
    {
        public LeaveMessage()
        { }

        private string _userid;
        private int _id;
        private string _username;
        private string _context;
        private string _time;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }


        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }


        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }





    }
}
