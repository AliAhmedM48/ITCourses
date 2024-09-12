using System.Web;
using System.Web.Mvc;

namespace Day4_MVC_lab7___sol___Ali_Ahmed
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
