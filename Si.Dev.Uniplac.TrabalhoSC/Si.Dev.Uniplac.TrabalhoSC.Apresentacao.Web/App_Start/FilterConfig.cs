using System.Web;
using System.Web.Mvc;

namespace Si.Dev.Uniplac.TrabalhoSC.Apresentacao.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
