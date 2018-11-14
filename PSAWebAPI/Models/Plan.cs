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
        public SubDivision SubDivision { get; set; }
        public string PlanName { get; set; }
        public int PlanRevisionDate { get; set; }
        public int PlanSqFt { get; set; }
        public int PlanUnits { get; set; }
        public int PlanStories { get; set; }
        public int PlanGlazingPerc { get; set; }
        public int PlanESRating { get; set; }
        public string PlanDataSheetDate { get; set; }
        public int PlanZones { get; set; }
        public int PlanCodeYear { get; set; }



        public bool TestDuctCompliance { get; set; }
        public bool TestDuctSample { get; set; }

        public bool TestTXVCompliance { get; set; }
        public bool TestTXVSample { get; set; }

        public bool TestHighEERCompliance { get; set; }
        public bool TestHighEERSample { get; set; }

        public bool TestInfiltrationCompliance { get; set; }
        public bool TestInfiltrationSample { get; set; }

        public bool TestMaxCoolCompliance { get; set; }
        public bool TestMaxCoolSample { get; set; }

        public bool TestAirFlowVerifCompliance { get; set; }
        public bool TestAirFlowVerifSample { get; set; }

        public bool TestHighQualCompliance { get; set; }
        public bool TestHighQualSample { get; set; }

        public bool TestRoom2RoomCompliance { get; set; }
        public bool TestRoom2RoomCSample { get; set; }

        public bool TestSurfAreaCompliance { get; set; }
        public bool TestSurfAreaSample { get; set; }

        public bool TestDuctInCondSpaceCompliance { get; set; }
        public bool TestDuctInCondSpaceSample { get; set; }

        public bool TestRefChargeCompliance { get; set; }
        public bool TestRefChargeSample { get; set; }

        public bool TestFanWattCompliance { get; set; }
        public bool TestFanWattSample { get; set; }

        public bool TestRadientBarCompliance { get; set; }
        public bool TestRadientBarSample { get; set; }

        public bool TestSolarHERSCompliance { get; set; }
        public bool TestSolarHERSSample { get; set; }

        public bool TestGreenCompliance { get; set; }

        public bool TestEnergyStarCompliance { get; set; }
        public bool TestEnergyStarSample { get; set; }

        public bool TestIAQCompliance { get; set; }
        public bool TestIAQSample { get; set; }

        public bool TestHighSEERCompliance { get; set; }
        public bool TestHighSEERSample { get; set; }

        public bool TestDHWDistCompliance { get; set; }
        public bool TestDHWDistSample { get; set; }

        public bool TestLowLeakAirCompliance { get; set; }
        public bool TestLowLeakAirSample { get; set; }

        public bool TestOtherCompliance { get; set; }
        public bool TestOtherSample { get; set; }

        public bool TestOther2Sample { get; set; }
        public bool TestOther2Compliance { get; set; }



        public string BillInfoItem { get; set; }
        public int BillInfoAmount { get; set; }
        public string BillInfoNote { get; set; }

        public int LoadHeat { get; set; }
        public int LoadCool { get; set; }
        public int LoadAHRINum { get; set; }

    }
}