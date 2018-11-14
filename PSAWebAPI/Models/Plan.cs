using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSAWebAPI.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        public int SubDivisionID { get; set; }

        public string PlanName { get; set; }
        public int? PlanRevisionDate { get; set; }
        public int? PlanSqFt { get; set; }
        public int? PlanUnits { get; set; }
        public int? PlanStories { get; set; }
        public int? PlanGlazingPerc { get; set; }
        public int? PlanESRating { get; set; }
        public string PlanDataSheetDate { get; set; } = DateTime.Now.ToString("MM/dd/yyyy");
        public int? PlanZones { get; set; }
        public int? PlanPrice { get; set; }
        public int? PlanCodeYear { get; set; }



        public bool TestDuctCompliance { get; set; } = false;
        public bool TestDuctSample { get; set; } = false;

        public bool TestTXVCompliance { get; set; } = false;
        public bool TestTXVSample { get; set; } = false;

        public bool TestHighEERCompliance { get; set; } = false;
        public bool TestHighEERSample { get; set; } = false;

        public bool TestInfiltrationCompliance { get; set; } = false;
        public bool TestInfiltrationSample { get; set; } = false;

        public bool TestMaxCoolCompliance { get; set; } = false;
        public bool TestMaxCoolSample { get; set; } = false;

        public bool TestAirFlowVerifCompliance { get; set; } = false;
        public bool TestAirFlowVerifSample { get; set; } = false;

        public bool TestHighQualCompliance { get; set; } = false;
        public bool TestHighQualSample { get; set; } = false;

        public bool TestRoom2RoomCompliance { get; set; } = false;
        public bool TestRoom2RoomCSample { get; set; } = false;

        public bool TestSurfAreaCompliance { get; set; } = false;
        public bool TestSurfAreaSample { get; set; } = false;

        public bool TestDuctInCondSpaceCompliance { get; set; } = false;
        public bool TestDuctInCondSpaceSample { get; set; } = false;

        public bool TestRefChargeCompliance { get; set; } = false;
        public bool TestRefChargeSample { get; set; } = false;

        public bool TestFanWattCompliance { get; set; } = false;
        public bool TestFanWattSample { get; set; } = false;

        public bool TestRadientBarCompliance { get; set; } = false;
        public bool TestRadientBarSample { get; set; } = false;

        public bool TestSolarHERSCompliance { get; set; } = false;
        public bool TestSolarHERSSample { get; set; } = false;

        public bool TestGreenCompliance { get; set; } = false;

        public bool TestEnergyStarCompliance { get; set; } = false;
        public bool TestEnergyStarSample { get; set; } = false;

        public bool TestIAQCompliance { get; set; } = false;
        public bool TestIAQSample { get; set; } = false;

        public bool TestHighSEERCompliance { get; set; } = false;
        public bool TestHighSEERSample { get; set; } = false;

        public bool TestDHWDistCompliance { get; set; } = false;
        public bool TestDHWDistSample { get; set; } = false;

        public bool TestLowLeakAirCompliance { get; set; } = false;
        public bool TestLowLeakAirSample { get; set; } = false;

        public bool TestOtherCompliance { get; set; } = false;
        public bool TestOtherSample { get; set; } = false;

        public bool TestOther2Sample { get; set; } = false;
        public bool TestOther2Compliance { get; set; } = false;



        public string BillInfoItem { get; set; }
        public int? BillInfoAmount { get; set; }
        public string BillInfoNote { get; set; }

        public int? LoadHeat { get; set; }
        public int? LoadCool { get; set; }
        public int? LoadAHRINum { get; set; }

    }
}