using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSAWebAPI.Models
{
    public class Lot
    {
        [Key]
        public int Id { get; set; }
        public int SubDivisionID { get; set; }

        public int? LotNum { get; set; }
        public string Phase { get; set; }
        public string AddressPermitNum { get; set; }
        public string NeedsToBeDone { get; set; }
        public string PlanPhase { get; set; }
    }
}