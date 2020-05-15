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
            var adm = new Administrador
            {
                 Email= "Gabriel21saltareli2002@gmail.com",
                 Senha="escola"
               
            };
       

 
            return View();
        }
        public ActionResult Administrador()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contatos( Administrador adm)
        {
            //Um comentario qualquer
            //Comentario Professor

            return View(adm);
        }

    }

}
