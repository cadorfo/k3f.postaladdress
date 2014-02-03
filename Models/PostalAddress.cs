using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using System;

namespace K3F.PostalAddress.Models
{
    public class PostalAddressRecord : ContentPartRecord
    {
        public virtual String Name { get; set; }

        public virtual String PostalCode { get; set; }

        public virtual String Street { get; set; }

        /* Town, city */

        public virtual int LocalityId { get; set; }
    }

    public class PostalAddressPart : ContentPart<PostalAddressRecord>
    {
        public virtual String Name
        {
            get { return Record.Name; }
            set { Record.Name = value; }
        }

        public virtual String PostalCode
        {
            get { return Record.PostalCode; }
            set { Record.PostalCode = value; }
        }

        public virtual String Street
        {
            get { return Record.Street; }
            set { Record.Street = value; }
        }

        public virtual int LocalityId
        {
            get { return Record.LocalityId; }
            set { Record.LocalityId = value; }
        }
    }
}