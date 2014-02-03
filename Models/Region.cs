using System;
using System.Collections.Generic;

namespace K3F.PostalAddress.Models
{
    public class RegionRecord
    {
        public RegionRecord()
        {
            Localities = new List<LocalityRecord>();
        }

        public virtual int Id { get; set; }

        public virtual String Name { get; set; }

        public virtual CountryRecord Country { get; set; }

        public virtual IList<LocalityRecord> Localities { get; set; }
    }
}