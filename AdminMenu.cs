using Orchard.Core.Contents;
using Orchard.Localization;
using Orchard.UI.Navigation;


namespace K3F.PostalAddress
{
    public class AdminMenu : INavigationProvider
    {
        public AdminMenu()
        {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder
                .Add(t => t.Caption(T("Add Countrys, States and Cities"))
                .Action("List", "Country", new { area = "K3F.PostalAddress" }));
        }


    }
}