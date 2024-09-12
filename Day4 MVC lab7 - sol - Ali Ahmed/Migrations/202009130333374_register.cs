namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class register : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "Email");
        }
    }
}
