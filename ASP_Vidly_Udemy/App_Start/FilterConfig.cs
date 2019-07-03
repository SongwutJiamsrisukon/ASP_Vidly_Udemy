using System.Web;
using System.Web.Mvc;

namespace ASP_Vidly_Udemy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
