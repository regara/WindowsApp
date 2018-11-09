namespace PSAWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuilderToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDivisions", "BuilderName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubDivisions", "BuilderName");
        }
    }
}
