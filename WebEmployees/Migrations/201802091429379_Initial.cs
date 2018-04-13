namespace WebEmployees.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EnrollmentDate = c.DateTime(nullable: false),
                        PositionID = c.Int(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Position", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "PositionID", "dbo.Position");
            DropIndex("dbo.Employee", new[] { "PositionID" });
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
        }
    }
}
