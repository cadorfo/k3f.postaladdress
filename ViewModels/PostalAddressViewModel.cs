using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K3F.PostalAddress.Models;
using System.Web.Mvc;

namespace K3F.PostalAddress.ViewModels
{
    public class PostalAddressViewModel : PostalAddressPart
    {
        public PostalAddressViewModel(PostalAddressPart part)
        {
            this.Record = part.Record;
        }
        public PostalAddressPart Part { get; set; }
        public IList<SelectListItem>
            Country { get; set; }
        public IList<SelectListItem> Regions { get; set; }
        public IList<SelectListItem> Localities { get; set; }

    }
}
