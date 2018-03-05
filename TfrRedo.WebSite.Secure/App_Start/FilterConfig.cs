using System.Web;
using System.Web.Mvc;

namespace TfrRedo.WebSite.Secure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
