namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ai : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Birthday", c => c.Double(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
        }
    }
}
