using K3F.PostalAddress.Models;
using Orchard;
using Orchard.Data;
using System.Collections.Generic;
using System.Linq;

namespace K3F.PostalAddress.Service
{
    public class PostalAddressService : IPostalAddressService
    {
        private readonly IRepository<LocalityRecord> _localityRepository;
        private readonly IRepository<CountryRecord> _countryRepository;
        private readonly IRepository<RegionRecord> _regionRepository;

        public PostalAddressService(IRepository<RegionRecord> regionRepository,
            IRepository<CountryRecord> countryRepository,
            IRepository<LocalityRecord> localityRepository)
        {
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
        }
        public IList<RegionRecord> ListRegions(int idCountry)
        {
            return _regionRepository.Fetch(x => x.Country.Id == idCountry).OrderBy(x => x.Name).ToList();
        }

        public IList<CountryRecord> ListCountries()
        {
            return _countryRepository.Fetch(x => x.Id != 0).OrderBy(x => x.Name).ToList();
        }

        public System.Collections.Generic.IList<Models.LocalityRecord> ListLocalities(int idRegion)
        {
            return _localityRepository.Fetch(x => x.Region.Id == idRegion).OrderBy(x => x.Name).ToList();
        }

        public void SaveOrUpdate(Models.RegionRecord region)
        {
            if (region.Id == 0)
            {
                _regionRepository.Create(region);
            }
            else
            {
                _regionRepository.Update(region);
            }
        }

        public void SaveOrUpdate(Models.LocalityRecord locality)
        {
            if (locality.Id == 0)
            {
                _localityRepository.Create(locality);
            }
            else
            {
                _localityRepository.Update(locality);
            }
        }

        public void SaveOrUpdate(Models.CountryRecord country)
        {
            if (country.Id == 0)
            {
                _countryRepository.Create(country);
            }
            else
            {
                _countryRepository.Update(country);
            }
        }

        public LocalityRecord GetLocality(int id)
        {
            return _localityRepository.Get(id);
        }

        public RegionRecord GetRegion(int id)
        {
            return _regionRepository.Get(id);
        }

        public CountryRecord GetCountry(int id)
        {
            return _countryRepository.Get(id);
        }


        public void Delete(RegionRecord region)
        {
            _regionRepository.Delete(region);
        }

        public void Delete(CountryRecord country)
        {
            _countryRepository.Delete(country);
        }

        public void Delete(LocalityRecord locality)
        {
            _localityRepository.Delete(locality);
        }
    }
}