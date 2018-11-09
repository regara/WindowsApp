namespace PSAWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubDivisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        BillableFrame = c.Boolean(nullable: false),
                        CrossSt = c.String(),
                        ClimateZone = c.Int(nullable: false),
                        Division = c.String(),
                        LotTotals = c.Int(nullable: false),
                        SalesRep = c.String(),
                        UtilityProgram = c.String(),
                        UtilityExpedition = c.String(),
                        Registry = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjId = c.Int(),
                        Project = c.String(),
                        Day = c.String(),
                        Date = c.String(),
                        ClassNum = c.Int(nullable: false),
                        Hours = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        OTHours = c.Int(nullable: false),
                        OTMinutes = c.Int(nullable: false),
                        VacationHours = c.Int(nullable: false),
                        HolidayHours = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeEntries");
            DropTable("dbo.SubDivisions");
        }
    }
}
