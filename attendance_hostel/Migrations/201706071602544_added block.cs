namespace attendance_hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedblock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendance_record", "block", c => c.String());
            AddColumn("dbo.Student_detail", "block", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student_detail", "block");
            DropColumn("dbo.Attendance_record", "block");
        }
    }
}
