namespace Wed_BisSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAttendances : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Cources", t => t.CourceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourceId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "CourceId", "dbo.Cources");
            DropIndex("dbo.Attendances", new[] { "User_Id" });
            DropIndex("dbo.Attendances", new[] { "CourceId" });
            DropTable("dbo.Attendances");
        }
    }
}
