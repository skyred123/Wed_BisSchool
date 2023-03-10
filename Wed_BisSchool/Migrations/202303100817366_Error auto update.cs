namespace Wed_BisSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Errorautoupdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Sources", newName: "Cources");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Cources", newName: "Sources");
        }
    }
}
