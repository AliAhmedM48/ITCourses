namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _815461 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "Phone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Students", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Password", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
