namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1651 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.StudentCourses1", newName: "StudentCourses");
            DropForeignKey("dbo.StudentCourses", "Course_ID1", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_ID1", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Course_ID1" });
            DropIndex("dbo.StudentCourses", new[] { "Student_ID1" });
            DropTable("dbo.StudentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                        Course_ID1 = c.Int(),
                        Student_ID1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Course_ID });
            
            CreateIndex("dbo.StudentCourses", "Student_ID1");
            CreateIndex("dbo.StudentCourses", "Course_ID1");
            AddForeignKey("dbo.StudentCourses", "Student_ID1", "dbo.Students", "ID");
            AddForeignKey("dbo.StudentCourses", "Course_ID1", "dbo.Courses", "ID");
            RenameTable(name: "dbo.StudentCourses", newName: "StudentCourses1");
        }
    }
}
