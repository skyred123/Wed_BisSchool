namespace Wed_BisSchool.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Wed_BisSchool.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Wed_BisSchool.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //CreateTableCourse

            //PopulateCategoryTable

            /*Sql("INSERT INTO CATEGORIES(ID, NAME)VALUES(1,'Development')");
            Sql("INSERT INTO CATEGORIES(ID, NAME)VALUES(2,'Business')");
            Sql("INSERT INTO CATEGORIES(ID, NAME)VALUES(3,'Marketing')");*/
        }
    }
}
