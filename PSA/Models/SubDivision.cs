using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSA.Models
{
    class SubDivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BuilderName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public bool BillableFrame { get; set; }
        public string CrossSt { get; set; }
        public int ClimateZone { get; set; }
        public string Division { get; set; }
        public int LotTotals { get; set; }
        public string SalesRep { get; set; }
        public string UtilityProgram { get; set; }
        public string UtilityExpedition { get; set; }
        public string Registry { get; set; }
    }
}
