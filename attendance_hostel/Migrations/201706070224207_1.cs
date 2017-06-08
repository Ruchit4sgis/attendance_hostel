namespace attendance_hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.res_com",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        reasons = c.String(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Student_detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Member_id = c.String(),
                        Name = c.String(),
                        floor = c.String(),
                        room = c.String(),
                        cup = c.String(),
                        standard = c.String(),
                        A_year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student_detail");
            DropTable("dbo.res_com");
        }
    }
}
