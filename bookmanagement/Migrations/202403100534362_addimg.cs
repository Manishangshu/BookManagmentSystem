namespace bookmanagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "img");
        }
    }
}
