using System.Web;
using System.Web.Mvc;

namespace E18I4DABH32D1Gr4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
