using System;
using System.Collections.Generic;

namespace K3F.PostalAddress.Models
{
    public class CountryRecord
    {
        public CountryRecord()
        {
            Regions = new List<RegionRecord>();
        }

        public virtual int Id { get; set; }

        public virtual String Name { get; set; }

        public virtual IList<RegionRecord> Regions { get; set; }
    }
}