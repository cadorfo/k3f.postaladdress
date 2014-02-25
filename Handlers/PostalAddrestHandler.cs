using K3F.PostalAddress.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;


namespace K3F.PostalAddress.Handlers
{
    public class PostalAddrestHandler : ContentHandler
    {
        public PostalAddrestHandler(IRepository<PostalAddressRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }


    }
}