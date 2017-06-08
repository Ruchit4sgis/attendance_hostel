namespace attendance_hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance_record",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        reason = c.String(),
                        Member_id = c.String(),
                        Name = c.String(),
                        floor = c.String(),
                        room = c.String(),
                        cup = c.String(),
                        standard = c.String(),
                        A_year = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendance_record");
        }
    }
}
