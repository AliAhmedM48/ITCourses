namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "MyCourses", c => c.String());
            DropColumn("dbo.Students", "College");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "MyApply", c => c.String());
            AddColumn("dbo.Students", "College", c => c.String());
            DropColumn("dbo.Students", "MyCourses");
        }
    }
}
