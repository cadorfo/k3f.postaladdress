using System;

namespace K3F.PostalAddress.Models
{
    public class LocalityRecord
    {
        public virtual int Id { get; set; }

        public virtual String Name { get; set; }

        public virtual RegionRecord Region { get; set; }
    }
}