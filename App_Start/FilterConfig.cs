using System.Web;
using System.Web.Mvc;

namespace Nikunj_Interview_Cisive
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
