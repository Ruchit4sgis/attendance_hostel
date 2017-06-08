using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using attendance_hostel.Models;

namespace attendance_hostel.Controllers
{
    public class ReportController : Controller
    {
        attendance_ho a = new attendance_ho();
        // GET: Report
        public ActionResult Index()
        {

            if (Session["Roal"].ToString() != "admin")
            {
                return RedirectToAction("../Home/Home");
            }
            List<object> mymodel = new List<object>();
            using (var ctx = new attendance_ho())
            {
                mymodel.Add(ctx.Attendance_record.SqlQuery("Select * from Attendance_record").ToList());
            }
            
            return View(mymodel);            
        }


     

       
        

        [HttpPost]
        public ActionResult Index(string floor,DateTime date1,string command,string block)
        {
            List<object> mymodel = new List<object>();
            if (command == "_floor")
            {
                
                using (var ctx = new attendance_ho())
                {
                    mymodel.Add(ctx.Attendance_record.SqlQuery("Select * from Attendance_record where floor = " + floor).ToList());
                }

                var month = ""; var day = "";
                if (date1.Day < 10)
                {
                    day = "0" + date1.Day;
                }

                else if (date1.Day > 9 && date1.Day < 32)
                {
                    day = date1.Day.ToString();
                }
                if (date1.Month < 10)
                {
                    month = "0" + date1.Month;
                }
                else if (date1.Month > 9 && date1.Month < 13)
                {
                    month = date1.Month.ToString();
                }
                string formated_date = "'" + date1.Year + month + day + "'";
                string except = date1.Year + "-" + month + "-" + day;
                ViewBag.formated_date = except;


                int absent_count;
                int total_count;

                // count NO. of Absents Stu filtered by floor and date
                using (var ctx = new attendance_ho())
                {

                    var sql = "SELECT COUNT(DISTINCT Member_id) FROM Attendance_record where floor =" + floor + " AND date = " + formated_date;
                    var total = a.Database.SqlQuery<int>(sql).Single();
                    absent_count = total;
                    ViewBag.absent_count = absent_count;
                }
                //count total students filtered by floor
                using (var ctx = new attendance_ho())
                {
                    var sql = "SELECT COUNT(DISTINCT Member_id) FROM Student_detail where floor ='" + floor+"'";
                    var total = a.Database.SqlQuery<int>(sql).Single();
                    total_count = total;
                    ViewBag.total_count = total_count;
                }
                //present strength on that DAY
                int present = total_count - absent_count;
                present.ToString();
                ViewBag.present_count = present.ToString();
                ViewBag.floor = floor;

                double absent_per = Math.Round((Convert.ToDouble(absent_count) / Convert.ToDouble(total_count)) * 100.00, 1);
                ViewBag.absent_per = absent_per.ToString() + "%";

                double present_per = Math.Round((Convert.ToDouble(present) / Convert.ToDouble(total_count)) * 100.00, 1);
                ViewBag.present_per = present_per.ToString() + "%";
            }
            else if(command == "_block")
            {
                using (var ctx = new attendance_ho())
                {
                    mymodel.Add(ctx.Attendance_record.SqlQuery("Select * from Attendance_record where block = '" + block+"'").ToList());
                }

                var month = ""; var day = "";
                if (date1.Day < 10)
                {
                    day = "0" + date1.Day;
                }

                else if (date1.Day > 9 && date1.Day < 32)
                {
                    day = date1.Day.ToString();
                }
                if (date1.Month < 10)
                {
                    month = "0" + date1.Month;
                }
                else if (date1.Month > 9 && date1.Month < 13)
                {
                    month = date1.Month.ToString();
                }
                string formated_date = "'" + date1.Year + month + day + "'";

                string except = date1.Year + "-" + month + "-" + day;
                ViewBag.formated_date = except;

                int absent_count;
                int total_count;

                // count NO. of Absents Stu filtered by floor and date
                using (var ctx = new attendance_ho())
                {

                    var sql = "SELECT COUNT(DISTINCT Member_id) FROM Attendance_record where block = '" + block + "' AND date = " + formated_date;
                    var total = a.Database.SqlQuery<int>(sql).Single();
                    absent_count = total;
                    ViewBag.absent_count = absent_count;
                }
                //count total students filtered by floor
                using (var ctx = new attendance_ho())
                {
                    var sql = "SELECT COUNT(DISTINCT Member_id) FROM Student_detail where block = '" + block+"'";
                    var total = a.Database.SqlQuery<int>(sql).Single();
                    total_count = total;
                    ViewBag.total_count = total_count;
                }
                //present strength on that DAY
                int present = total_count - absent_count;
                present.ToString();
                ViewBag.present_count = present.ToString();
                ViewBag.block = block;

                double absent_per = Math.Round((Convert.ToDouble(absent_count) / Convert.ToDouble(total_count)) * 100.00, 1);
                ViewBag.absent_per = absent_per.ToString() + "%";

                double present_per = Math.Round((Convert.ToDouble(present) / Convert.ToDouble(total_count)) * 100.00, 1);
                ViewBag.present_per = present_per.ToString() + "%";
            }else if(command == "_Whole")
            {
                

                var month = ""; var day = "";
                if (date1.Day < 10)
                {
                    day = "0" + date1.Day;
                }

                else if (date1.Day > 9 && date1.Day < 32)
                {
                    day = date1.Day.ToString();
                }
                if (date1.Month < 10)
                {
                    month = "0" + date1.Month;
                }
                else if (date1.Month > 9 && date1.Month < 13)
                {
                    month = date1.Month.ToString();
                }
                string formated_date = "'" + date1.Year + month + day + "'";
                string except = date1.Year + "-" + month + "-" + day;
                ViewBag.formated_date = except;

                using (var ctx = new attendance_ho())
                {
                    mymodel.Add(ctx.Attendance_record.SqlQuery("Select * from Attendance_record where date =" + formated_date).ToList());
                }

                int absent_count;
                int total_count;

                // count NO. of Absents Stu filtered by floor and date
                using (var ctx = new attendance_ho())
                {

                    var sql = "SELECT COUNT(DISTINCT Member_id) FROM Attendance_record where date = " + formated_date;
                    var total = a.Database.SqlQuery<int>(sql).Single();
                    absent_count = total;
                    ViewBag.absent_count = absent_count;
                }
                //count total students filtered by floor
                using (var ctx = new attendance_ho())
                {
                    var sql = "SELECT COUNT(DISTINCT Member_id) FROM Student_detail";
                    var total = a.Database.SqlQuery<int>(sql).Single();
                    total_count = total;
                    ViewBag.total_count = total_count;
                }
                //present strength on that DAY
                int present = total_count - absent_count;
                present.ToString();
                ViewBag.present_count = present.ToString();
                ViewBag.floor = floor;

                double absent_per = Math.Round((Convert.ToDouble(absent_count) / Convert.ToDouble(total_count)) * 100.00, 1);
                ViewBag.absent_per = absent_per.ToString() + "%";

                double present_per = Math.Round((Convert.ToDouble(present) / Convert.ToDouble(total_count)) * 100.00, 1);
                ViewBag.present_per = present_per.ToString() + "%";
            }


            return View(mymodel);

        }
    }
}