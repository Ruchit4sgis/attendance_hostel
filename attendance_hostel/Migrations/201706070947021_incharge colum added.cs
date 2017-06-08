namespace attendance_hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inchargecolumadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendance_record", "incharge", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendance_record", "incharge");
        }
    }
}
