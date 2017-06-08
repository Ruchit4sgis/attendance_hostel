namespace attendance_hostel.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class attendance_ho : DbContext
    {
        // Your context has been configured to use a 'attendance_ho' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'attendance_hostel.Models.attendance_ho' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'attendance_ho' 
        // connection string in the application configuration file.
        public attendance_ho()
            : base("name=attendance_ho")
        {
        }

        public System.Data.Entity.DbSet<attendance_hostel.Models.res_com> Reasons { get; set; }

        public System.Data.Entity.DbSet<attendance_hostel.Models.Student_detail> Student_detail { get; set; }

        public System.Data.Entity.DbSet<attendance_hostel.Models.Login> Logins { get; set; }

        public System.Data.Entity.DbSet<attendance_hostel.Models.Attendance_record> Attendance_record { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}