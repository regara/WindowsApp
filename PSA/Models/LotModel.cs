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
        public SubDivision SubDivision { get; set; }

        public int LotNum { get; set; }
        public string Phase { get; set; }
        public string AddressPermitNum { get; set; }
        public string NeedsToBeDone { get; set; }
        public string PlanPhase { get; set; }
    }
}
