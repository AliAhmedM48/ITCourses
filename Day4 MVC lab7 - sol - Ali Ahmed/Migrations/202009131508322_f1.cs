namespace Day4_MVC_lab7___sol___Ali_Ahmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ProfilePicture");
        }
    }
}
