using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.IO;


namespace attendance_hostel.Controllers
{
    public class DataPanelController : Controller
    {
        // GET: DataPanel
        public ActionResult ImportData()
        {
            if (Session["Roal"].ToString() != "admin")
            {
                return RedirectToAction("~/Home/Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ImportData(HttpPostedFileBase file, string command)
        {
            if (command == "g_details")
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string filepath = "/excelfolder/" + filename;
                file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
                InsertExceldata_studentdetails(filepath, filename);
                ViewBag.Success = "Successfully Data Impororted";
            }
            else if (command == "reason")
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string filepath = "/excelfolder/" + filename;
                file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
               reason(filepath, filename);
                ViewBag.Success = "Successfully Data Impororted";
            }
            return View();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["attendance_ho"].ConnectionString);
        OleDbConnection Econ;

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);

        }

        private void InsertExceldata_studentdetails(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];

            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Student_detail";
            objbulk.ColumnMappings.Add("Member_id", "Member_id");
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("floor", "floor");
            objbulk.ColumnMappings.Add("room", "room");
            objbulk.ColumnMappings.Add("cup", "cup");
            objbulk.ColumnMappings.Add("block", "block");
            objbulk.ColumnMappings.Add("standard", "standard");
            objbulk.ColumnMappings.Add("A_year", "A_year");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();
        }

        private void reason(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];

            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "res_com";
            objbulk.ColumnMappings.Add("reasons", "reasons");
            objbulk.ColumnMappings.Add("comment", "comment");          
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();

        }


        public ActionResult student()
        {
            string file = @"c:\downloade\Student Detail Import Format for att.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(file, contentType, Path.GetFileName(file));
        }

        public ActionResult reason()
        {
            string file = @"c:\downloade\reason for absent.xlsx";
            string contenttype = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(file, contenttype, Path.GetFileName(file));
        }

        public ActionResult records_attendance()
        {
            string file = @"c:\downloade\records_attendance.xlsx";
            string contenttype = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(file, contenttype, Path.GetFileName(file));
        }




    }

}