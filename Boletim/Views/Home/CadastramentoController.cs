using System.Web.Mvc;
using AlunoAplicaçao;
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
        public ActionResult Alunoe()
        {
            return View();
        }
        public ActionResult Professor()
        {
            return View();
        }
        public ActionResult Turma()
        {
            return View();
        }


    }
      
}