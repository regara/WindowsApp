namespace PSAWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubDModelUpdatedStartAndCompDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDivisions", "StartDate", c => c.String());
            AddColumn("dbo.SubDivisions", "CompDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubDivisions", "CompDate");
            DropColumn("dbo.SubDivisions", "StartDate");
        }
    }
}
