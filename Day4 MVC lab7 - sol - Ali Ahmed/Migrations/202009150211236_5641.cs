namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5641 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Department_ID", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Department_ID" });
            AlterColumn("dbo.Courses", "Department_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Department_ID");
            AddForeignKey("dbo.Courses", "Department_ID", "dbo.Departments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Department_ID", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Department_ID" });
            AlterColumn("dbo.Courses", "Department_ID", c => c.Int());
            CreateIndex("dbo.Courses", "Department_ID");
            AddForeignKey("dbo.Courses", "Department_ID", "dbo.Departments", "ID");
        }
    }
}
