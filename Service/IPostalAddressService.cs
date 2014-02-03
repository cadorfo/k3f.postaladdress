using K3F.PostalAddress.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3F.PostalAddress.Service
{
    public interface IPostalAddressService : IDependency
    {
        IList<RegionRecord> ListRegions(int idCountry);
        IList<CountryRecord> ListCountries();
        IList<LocalityRecord> ListLocalities(int idLocality);

        void SaveOrUpdate(RegionRecord region);
        void SaveOrUpdate(LocalityRecord locality);
        void SaveOrUpdate(CountryRecord country);

        LocalityRecord GetLocality(int id);
        RegionRecord GetRegion(int id);
        CountryRecord GetCountry(int id);

        void Delete(RegionRecord region);
        void Delete(CountryRecord country);
        void Delete(LocalityRecord locality);
    }

}
