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
        public ActionResult CadastroAluno()
        {
            return View();
        }
        public ActionResult CadastroProfessor()
        {
            return View();
        }
        public ActionResult CadastroTurma()
        {
            return View();
        }


    }
      
}