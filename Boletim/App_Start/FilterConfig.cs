using System.Web;
using System.Web.Mvc;
using Boletim;
using Boletim.Models;

namespace SistemaBoletim
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()
            {
                Roles = "Administrador" 

            });
            filters.Add(new OutputCacheAttribute 
            { 
           VaryByParam ="*",
           Duration =0,
           NoStore = true,
            
            }
            );
        }
    }
}