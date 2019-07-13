using System.Web;
using System.Web.Mvc;

namespace ASP_Vidly_Udemy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//redirect user to error page when action throw exception
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());//no longer use http localhost:51449
        }
    }
}
