namespace ContosoUniversityModelBinding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "EnrollmentDate");
        }
    }
}
