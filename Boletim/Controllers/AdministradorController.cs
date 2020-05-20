using System.Web.Mvc;
using Boletim.Models;

namespace Boletim.Controllers
{
    public class AdministradorController : Controller
    {
        private object dc;

        // GET: Administrador
        public ActionResult Index()
        {
            var Administrador = new Administrador
            {
                Email = "",
                Senha = "",

            };
            ViewBag.Email = Administrador.Email;
            ViewBag.Nome = Administrador.Senha;

            return View();
        }
        [HttpPost]
        public ActionResult Administrador(Administrador administrador)
        {


            return View(administrador);
        }
    }
}