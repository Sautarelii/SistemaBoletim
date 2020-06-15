using Boletim.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Boletim.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
       

 
            return View();
        }

        public ActionResult Cadastramentos()
        {
            return View();         
        }

    }

}
