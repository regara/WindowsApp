﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PSAWebAPI.Models
{
    public class PSAWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PSAWebAPIContext() : base("name=PSAWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<PSAWebAPI.Models.TimeEntry> TimeEntries { get; set; }

        public System.Data.Entity.DbSet<PSAWebAPI.Models.SubDivision> SubDivisions { get; set; }

        public System.Data.Entity.DbSet<PSAWebAPI.Models.Lot> Lots { get; set; }

        public System.Data.Entity.DbSet<PSAWebAPI.Models.Plan> Plans { get; set; }
    }
}
