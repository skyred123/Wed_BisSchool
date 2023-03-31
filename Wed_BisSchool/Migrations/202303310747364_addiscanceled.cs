namespace Wed_BisSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addiscanceled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cources", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cources", "IsCanceled");
        }
    }
}
