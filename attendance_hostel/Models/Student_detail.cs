using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace attendance_hostel.Models
{
    public class Student_detail
    {
        public int Id { get; set; }
        public string Member_id { get; set; }
        public string Name { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string cup { get; set; }
        public string block {get; set;}
        public string standard { get; set; }        
        public string A_year { get; set; }
    }
}