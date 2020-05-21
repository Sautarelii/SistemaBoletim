using System.Web.Mvc;
using Boletim.Models;

namespace Boletim.Controllers
{
    public class CadastramentoController : Controller
    {
        // GET: Cadastramento
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroAluno()

        {


            return View();
        }
    }
      
}