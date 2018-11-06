using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSAWebAPI.Models
{
    public class TimeEntry
    {
        [Key]
        public int Id { get; set; }
        public int? ProjId { get; set; }
        public string Project { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public int ClassNum { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int OTHours { get; set; }
        public int OTMinutes { get; set; }
        public int VacationHours { get; set; }
        public int HolidayHours { get; set; }
        public string Notes { get; set; }

    }
}