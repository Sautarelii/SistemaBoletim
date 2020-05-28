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
<<<<<<< HEAD
            var appAluno = new SistemaBoletimAlunoAplicaçao().

            return View();
=======
            var appAluno = new SistemaBoletimAlunoAplicaçao();

            var listaDeAlunos = appAluno.ListarTodos(); 
          
            return View(listaDeAlunos);

>>>>>>> b249c7027d4a872aa3895fa87057d15fcf21a2ff
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