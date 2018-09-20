using System;
using System.Collections.Generic;

namespace PSA.Models.TempDB
{
    public class Note
    {
        public DateTime Date { get; set; }
        public string Text  { get; set; }
    }

    public class BuilderInfo
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string SalesRep { get; set; }
        public string Division { get; set; }
        public string License { get; set; }
        public string Bond { get; set; }
        public bool Vellum { get; set; }
        public string CustomerType { get; set; }
        public string GeoArea { get; set; }
        public string BuilderCriteria { get; set; }
    }

    public class BuilderInfoContact
    {
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
    }

}
