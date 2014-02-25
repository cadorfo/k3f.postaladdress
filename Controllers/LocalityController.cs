using K3F.PostalAddress.Models;
using K3F.PostalAddress.Service;
using Orchard.UI.Admin;
using System.Web.Mvc;
using System.Linq;

namespace K3F.PostalAddress.Controllers
{
    //[Admin] or [Themed] for a default layout. Can be placed on the controller or methods
    public class LocalityController : Controller
    {
        private readonly IPostalAddressService _postalAddressService;
        public LocalityController(IPostalAddressService postalAddressService)
        {

            _postalAddressService = postalAddressService;
        }
        [Admin]
        public ActionResult List(int idRegion)
        {
            var model = _postalAddressService.ListLocalities(idRegion);
            ViewBag.Region = _postalAddressService.GetRegion(idRegion);
            return View(model);
        }
        public ActionResult ListJSON(int idRegion)
        {
            var model = _postalAddressService.ListLocalities(idRegion);
            ViewBag.Region = _postalAddressService.GetRegion(idRegion);
            return new JsonResult()
            {
                Data = model.Select(x => new { Name = x.Name, Id = x.Id }).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Admin]
        public ActionResult New(int idRegion)
        {

            ViewBag.IdRegion = idRegion;
            ViewBag.Region = _postalAddressService.GetRegion(idRegion);
            return View();
        }
        [Admin]
        [HttpPost]
        public ActionResult New(LocalityRecord locality, FormCollection formCollection)
        {
            var region = _postalAddressService.GetRegion(int.Parse(formCollection["Region_Id"]));
            locality.Region = region;
            //region.Localities.Add(locality);
            _postalAddressService.SaveOrUpdate(locality);
            return RedirectToAction("List", new { idRegion = region.Id });
        }
        [Admin]
        public ActionResult Edit(int idRegion)
        {
            ViewBag.IdRegion = idRegion;
            return View();
        }
        [Admin]
        [HttpPost]
        public ActionResult Edit(LocalityRecord locality, FormCollection formCollection)
        {
            var localityToUpdate = _postalAddressService.GetLocality(locality.Id);
            localityToUpdate.Name = locality.Name;

            _postalAddressService.SaveOrUpdate(localityToUpdate);
            return RedirectToAction("List", new { idRegion = localityToUpdate.Region.Id });
        }
    }
}