using System.Web;
using System.Web.Mvc;

namespace ProjectTeam12_Latest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
