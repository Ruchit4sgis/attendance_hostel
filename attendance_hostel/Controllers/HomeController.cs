using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using attendance_hostel.Models;

namespace attendance_hostel.Controllers
{
    public class HomeController : Controller
    {
        // GET: HOme
        public ActionResult Home()
        {
            string roal = Session["Roal"].ToString();
            attendance_ho a = new attendance_ho();
            List<object> mymodel = new List<object>();
            if (roal == "admin")
            {
                mymodel.Add(a.Student_detail.ToList());
                mymodel.Add(a.Reasons.ToList());
                ViewBag.id = new SelectList(a.Reasons, "id", "c_Attributs");
            }
            else
            {
                using (var ctx = new attendance_ho())
                {
                    roal = Session["Roal"].ToString();
                    mymodel.Add(ctx.Student_detail.SqlQuery("Select * from Student_detail where floor = '" + roal+"'").ToList());
                    ViewBag.id = new SelectList(a.Reasons, "id", "c_Attributs");
                }
            }
            
            return View(mymodel);
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction("Home");
        }

        ////vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

        [HttpPost]   //string Reason, int? student_id, DateTime date1, string room, string cup
        public ActionResult Home(DateTime date1,string Member_Id,string floor,string Name,string Room,string cup,string std,string reasons,int? s_id,string block)
        {
            
            string user_1 = Session["UserName"].ToString();


            string roal = Session["UserName"].ToString();
            attendance_ho a = new attendance_ho();
            List<object> mymodel = new List<object>();
            if (roal == "admin")
            {
                mymodel.Add(a.Student_detail.ToList());
                mymodel.Add(a.Reasons.ToList());
                ViewBag.id = new SelectList(a.Reasons, "id", "c_Attributs");
            }
            else
            {
                using (var ctx = new attendance_ho())
                {
                    roal = Session["roal"].ToString();
                    mymodel.Add(ctx.Student_detail.SqlQuery("Select * from Student_detail where floor = '" + roal + "'").ToList());
                    ViewBag.id = new SelectList(a.Reasons, "id", "c_Attributs");
                }
            }

            ViewBag.id = new SelectList(a.Reasons, "id", "c_Attributs");
                using (var ctx = new attendance_ho())
                {

                    var studentList = ctx.Student_detail.SqlQuery("Select * from Student_detail where Id = " + s_id).ToList();
                    string _Member_ID = studentList[0].Member_id.ToString();
                    string _Name = studentList[0].Name.ToString();
                    string _Room = studentList[0].room.ToString();
                    string _cup = studentList[0].cup.ToString();
                    string _std = studentList[0].standard.ToString();
                    string _ac = studentList[0].A_year.ToString();
                    string _floor = studentList[0].floor.ToString();
                    string _block = studentList[0].block.ToString();
                Attendance_record rec = new Attendance_record
                {
                    date = date1,
                    reason = reasons,
                    Member_id = _Member_ID,
                    Name = _Name,
                    floor = _floor,
                    room = _Room,
                    cup = _cup,
                    block = _block,
                        standard = _std,
                        A_year = _ac,
                        incharge = user_1,

                       
                    };
                    using (var qwer = new attendance_ho())
                    {
                    qwer.Attendance_record.Add(rec);
                    qwer.SaveChanges();
                }

                }
            

            ViewBag.reason = reasons;
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
            ViewBag.date11 = date1.Year + "-" + month + "-" + day;
            ViewBag.room = Room;
            ViewBag.cup = cup;
            ViewBag.floor = floor;


            return View(mymodel);
        }

       //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public ActionResult Index()
        {
            return View();
        }

        attendance_ho db = new attendance_ho();

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Logins.Where(a => a.Name.Equals(login.Name) && a.password.Equals(login.password)).FirstOrDefault();
                if (obj != null)
                {
                    ViewBag.loginstatus = "Jay Swaminarayan";
                    Session["UserName"] = obj.Name.ToString();
                    Session["Roal"] = obj.roal.ToString();
                }
            }
            return RedirectToAction("Home");
        }

    }
}