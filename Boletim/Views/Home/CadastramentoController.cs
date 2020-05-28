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
        public ActionResult Aluno()
        {

            return View();
        }
        public ActionResult CadastroAluno()
        {
            var appAluno = new SistemaBoletimAlunoAplicaçao().

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