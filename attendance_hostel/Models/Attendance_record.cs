using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace attendance_hostel.Models
{
    public class Attendance_record
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string reason { get; set; }
        public string Member_id { get; set; }
        public string Name { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string cup { get; set; }
        public string block { get; set; }
        public string standard { get; set; }
        public string A_year { get; set; }
        public string incharge { get; set; }
    }
}