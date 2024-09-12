namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ali : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentCourses", newName: "StudentCourses1");
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                        Course_ID1 = c.Int(),
                        Student_ID1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Course_ID })
                .ForeignKey("dbo.Courses", t => t.Course_ID1)
                .ForeignKey("dbo.Students", t => t.Student_ID1)
                .Index(t => t.Course_ID1)
                .Index(t => t.Student_ID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Student_ID1", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_ID1", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Student_ID1" });
            DropIndex("dbo.StudentCourses", new[] { "Course_ID1" });
            DropTable("dbo.StudentCourses");
            RenameTable(name: "dbo.StudentCourses1", newName: "StudentCourses");
        }
    }
}
