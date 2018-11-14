namespace PSAWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSubDLotAndPlansLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubDivisions", "Lots_Id", "dbo.Lots");
            DropForeignKey("dbo.SubDivisions", "Plans_Id", "dbo.Plans");
            DropIndex("dbo.SubDivisions", new[] { "Lots_Id" });
            DropIndex("dbo.SubDivisions", new[] { "Plans_Id" });
            AddColumn("dbo.Lots", "SubDivision_Id", c => c.Int());
            AddColumn("dbo.Plans", "SubDivision_Id", c => c.Int());
            CreateIndex("dbo.Lots", "SubDivision_Id");
            CreateIndex("dbo.Plans", "SubDivision_Id");
            AddForeignKey("dbo.Lots", "SubDivision_Id", "dbo.SubDivisions", "Id");
            AddForeignKey("dbo.Plans", "SubDivision_Id", "dbo.SubDivisions", "Id");
            DropColumn("dbo.SubDivisions", "Lots_Id");
            DropColumn("dbo.SubDivisions", "Plans_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubDivisions", "Plans_Id", c => c.Int());
            AddColumn("dbo.SubDivisions", "Lots_Id", c => c.Int());
            DropForeignKey("dbo.Plans", "SubDivision_Id", "dbo.SubDivisions");
            DropForeignKey("dbo.Lots", "SubDivision_Id", "dbo.SubDivisions");
            DropIndex("dbo.Plans", new[] { "SubDivision_Id" });
            DropIndex("dbo.Lots", new[] { "SubDivision_Id" });
            DropColumn("dbo.Plans", "SubDivision_Id");
            DropColumn("dbo.Lots", "SubDivision_Id");
            CreateIndex("dbo.SubDivisions", "Plans_Id");
            CreateIndex("dbo.SubDivisions", "Lots_Id");
            AddForeignKey("dbo.SubDivisions", "Plans_Id", "dbo.Plans", "Id");
            AddForeignKey("dbo.SubDivisions", "Lots_Id", "dbo.Lots", "Id");
        }
    }
}
