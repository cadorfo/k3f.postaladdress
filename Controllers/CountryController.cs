using K3F.PostalAddress.Models;
using K3F.PostalAddress.Service;
using Orchard.UI.Admin;
using System.Web.Mvc;


namespace K3F.PostalAddress.Controllers
{
    //[Admin] or [Themed] for a default layout. Can be placed on the controller or methods
    public class CountryController : Controller
    {
        private readonly IPostalAddressService _postalAddressService;
        [Admin]
        public CountryController(IPostalAddressService postalAddresService)
        {
            _postalAddressService = postalAddresService;
        }
        [Admin]
        public ActionResult List()
        {
            var countries = _postalAddressService.ListCountries();
            return View(countries);
        }
        [Admin]
        public ActionResult New()
        {
            return View();
        }
        [Admin]
        [HttpPost]
        public ActionResult New(CountryRecord country)
        {
            _postalAddressService.SaveOrUpdate(country);
            return RedirectToAction("List");
        }
        [Admin]
        public ActionResult Edit(int id)
        {
            var model = _postalAddressService.GetCountry(id);
            return View(model);
        }
        [Admin]
        [HttpPost]
        public ActionResult Edit(CountryRecord country,
            FormCollection formCollection)
        {
            var entityToUpdate = _postalAddressService.GetCountry(country.Id);
            entityToUpdate.Name = entityToUpdate.Name;
            _postalAddressService.SaveOrUpdate(entityToUpdate);
            return RedirectToAction("List");
        }

    }
}