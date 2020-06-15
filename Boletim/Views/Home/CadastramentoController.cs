using System.Web.Mvc;

using Boletim.Models;
using Microsoft.Ajax.Utilities;

namespace Boletim.Controllers
{
    public class CadastramentoController : Controller
    {
        // GET: Cadastramento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Aluno()
        {

            return View();
        }
      
        public ActionResult PROFESSOR()
        {
            return View();
        }
        public ActionResult TURMA()
        {
            return View();
        }
        public ActionResult Materia()
        {
            return View();
        }
        public ActionResult PROFMATERIATURMA()
        {
            return View();
        }
        public ActionResult AVALIACAO()
        {
            return View();
        }

    }
      
}