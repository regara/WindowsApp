namespace PSAWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLotsAndPlansModelAndControler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlanName = c.String(),
                        PlanRevisionDate = c.Int(nullable: false),
                        PlanSqFt = c.Int(nullable: false),
                        PlanUnits = c.Int(nullable: false),
                        PlanStories = c.Int(nullable: false),
                        PlanGlazingPerc = c.Int(nullable: false),
                        PlanESRating = c.Int(nullable: false),
                        PlanDataSheetDate = c.String(),
                        PlanZones = c.Int(nullable: false),
                        PlanCodeYear = c.Int(nullable: false),
                        TestEnergyStar = c.Boolean(nullable: false),
                        BillInfoItem = c.String(),
                        BillInfoAmount = c.Int(nullable: false),
                        BillInfoNote = c.String(),
                        LoadHeat = c.Int(nullable: false),
                        LoadCool = c.Int(nullable: false),
                        LoadAHRINum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LotNum = c.Int(nullable: false),
                        Phase = c.String(),
                        AddressPermitNum = c.String(),
                        NeedsToBeDone = c.String(),
                        PlanPhase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SubDivisions", "Lots_Id", c => c.Int());
            AddColumn("dbo.SubDivisions", "Plans_Id", c => c.Int());
            CreateIndex("dbo.SubDivisions", "Lots_Id");
            CreateIndex("dbo.SubDivisions", "Plans_Id");
            AddForeignKey("dbo.SubDivisions", "Lots_Id", "dbo.Lots", "Id");
            AddForeignKey("dbo.SubDivisions", "Plans_Id", "dbo.Plans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDivisions", "Plans_Id", "dbo.Plans");
            DropForeignKey("dbo.SubDivisions", "Lots_Id", "dbo.Lots");
            DropIndex("dbo.SubDivisions", new[] { "Plans_Id" });
            DropIndex("dbo.SubDivisions", new[] { "Lots_Id" });
            DropColumn("dbo.SubDivisions", "Plans_Id");
            DropColumn("dbo.SubDivisions", "Lots_Id");
            DropTable("dbo.Plans");
            DropTable("dbo.Lots");
        }
    }
}
