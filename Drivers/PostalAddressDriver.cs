using K3F.PostalAddress.Models;
using K3F.PostalAddress.Service;
using K3F.PostalAddress.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;



namespace K3F.PostalAddress.Drivers
{
    public class PostalAddressDriver : ContentPartDriver<PostalAddressPart>
    {
        private readonly IPostalAddressService _postalAddressService;
        public PostalAddressDriver(IPostalAddressService postalAddressService)
        {
            _postalAddressService = postalAddressService;
        }

        protected override string Prefix
        {
            get { return "PostalAddressPart"; }
        }

        protected override DriverResult Display(PostalAddressPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PostalAddress",
                () => shapeHelper.Parts_PostalAddress(
                    Model: part));
        }

        protected override DriverResult Editor(PostalAddressPart part, dynamic shapeHelper)
        {

            IList<CountryRecord> listCountries = _postalAddressService.ListCountries();

            IList<RegionRecord> listRegions = null;
            IList<LocalityRecord> listLocalities = null;

            if (part.Locality != null)
            {
                listRegions = _postalAddressService.ListRegions(part.Locality.Region.Country.Id);
            }
            else if (listCountries.Count > 0)
            {
                listRegions = _postalAddressService.ListRegions(listCountries.FirstOrDefault().Id);
            }
            if (part.Locality != null)
            {
                listLocalities = _postalAddressService.ListLocalities(part.Locality.Region.Id);
            }
            else if (listRegions.Count > 0)
            {
                listLocalities = _postalAddressService.ListLocalities(listRegions.FirstOrDefault().Id);
            }

            PostalAddressViewModel postalViewModel = new PostalAddressViewModel(part)
            {
                Country = listCountries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString(), Selected = part.Locality != null && part.Locality.Region.Country.Id == x.Id }).ToList(),
                Regions = listRegions.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString(), Selected = part.Locality != null && part.Locality.Region.Id == x.Id }).ToList(),
                Localities = listLocalities.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString(), Selected = part.Locality != null && part.Locality.Id == x.Id }).ToList(),
                Part = part
            };

            return ContentShape("Parts_PostalAddress_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/PostalAddress",
                    Model: postalViewModel,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(PostalAddressPart part, IUpdateModel updater, dynamic shapeHelper)
        {

            if (updater.TryUpdateModel(part, Prefix, null, null))
            {
                part.Locality = _postalAddressService.GetLocality(part.Locality.Id);
            }

            return Editor(part, shapeHelper);
        }


    }
}