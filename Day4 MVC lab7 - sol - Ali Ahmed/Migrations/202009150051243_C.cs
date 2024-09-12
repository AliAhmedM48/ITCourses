namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class C : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "ProfilePicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ProfilePicture", c => c.String());
        }
    }
}
