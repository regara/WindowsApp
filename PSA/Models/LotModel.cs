using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSA.Models
{
    class LotModel
    {
        public int Id { get; set; }
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

        public bool TestEnergyStar { get; set; }
        public bool[] TestDuct { get; set; } = new bool[2];
        public bool[] TestTXV { get; set; } = new bool[2];
        public bool[] TestHighEER { get; set; } = new bool[2];
        public bool[] TestInfiltration { get; set; } = new bool[2];
        public bool[] TestMaxCool { get; set; } = new bool[2];
        public bool[] TestAirFlowVerif { get; set; } = new bool[2];
        public bool[] TestHighQual { get; set; } = new bool[2];
        public bool[] TestRoom2Room { get; set; } = new bool[2];
        public bool[] TestSurfaceArea { get; set; } = new bool[2];
        public bool[] TestDuctInCond { get; set; } = new bool[2];
        public bool[] TestRefCharge { get; set; } = new bool[2];
        public bool[] TestFanWatt { get; set; } = new bool[2];
        public bool[] TestRadianyBarr { get; set; } = new bool[2];
        public bool[] TestSolarHERS { get; set; } = new bool[2];
        public bool[] TestGreen { get; set; } = new bool[2];
        public bool[] TestIAQ { get; set; } = new bool[2];
        public bool[] TestHighSeer { get; set; } = new bool[2];
        public bool[] TestDHWDist { get; set; } = new bool[2];
        public bool[] TestLowLeakage { get; set; } = new bool[2];
        public bool[] TestOther { get; set; } = new bool[2];
        public bool[] TestOther2 { get; set; } = new bool[2];

        public string BillInfoItem { get; set; }
        public int BillInfoAmount { get; set; }
        public string BillInfoNote { get; set; }

        public int LoadHeat { get; set; }
        public int LoadCool { get; set; }
        public int LoadAHRINum { get; set; }
    }
}
