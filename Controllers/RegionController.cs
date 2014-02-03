using K3F.PostalAddress.Models;
using K3F.PostalAddress.Service;
using Orchard.UI.Admin;
using System.Web.Mvc;


namespace K3F.PostalAddress.Controllers
{
    //[Admin] or [Themed] for a default layout. Can be placed on the controller or methods
    public class RegionController : Controller
    {
        private readonly IPostalAddressService _postalAddressService;
        public RegionController(IPostalAddressService postalAddressService)
        {
            _postalAddressService = postalAddressService;
        }

        [Admin]
        public ActionResult List(int idCountry)
        {
            var regions = _postalAddressService.ListRegions(idCountry);
            var country = _postalAddressService.GetCountry(idCountry);
            ViewBag.Country = country;
            return View(regions);
        }
        [Admin]
        public ActionResult New(int idCountry)
        {
            ViewBag.IdCountry = idCountry;
            return View();
        }
        [Admin]
        [HttpPost]
        public ActionResult New(RegionRecord region, int idCountry)
        {
            var country = _postalAddressService.GetCountry(idCountry);
            region.Country = country;
            _postalAddressService.SaveOrUpdate(region);
            return RedirectToAction("List", new { idCountry = idCountry });
        }

        [Admin]
        public ActionResult Edit(int idRegion)
        {
            RegionRecord region = _postalAddressService.GetRegion(idRegion);

            return View(region);
        }
        [Admin]
        [HttpPost]
        public ActionResult Edit(RegionRecord region)
        {
            var regionToUpdate = _postalAddressService.GetRegion(region.Id);
            regionToUpdate.Name = region.Name;
            _postalAddressService.SaveOrUpdate(regionToUpdate);
            return RedirectToAction("List", new { idCountry = regionToUpdate.Country.Id });
        }
    }
}