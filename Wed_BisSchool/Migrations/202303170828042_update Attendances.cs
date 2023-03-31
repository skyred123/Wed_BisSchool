/*namespace Wed_BisSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAttendances : DbMigration
    {
        public override void Up()
        {
             "dbo.Attendances",
                c => new
                    {
                        CourceId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Attendee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourceId, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.Attendee_Id)
                .ForeignKey("dbo.Cources", t => t.CourceId)
                .Index(t => t.CourceId)
                .Index(t => t.Attendee_Id);
            
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
*/