namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4515 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "PhotoCourse", c => c.String());
            AddColumn("dbo.Students", "ProfilePhoto", c => c.String());
            DropColumn("dbo.Students", "MyCourses");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "MyCourses", c => c.String());
            DropColumn("dbo.Students", "ProfilePhoto");
            DropColumn("dbo.Courses", "PhotoCourse");
        }
    }
}
