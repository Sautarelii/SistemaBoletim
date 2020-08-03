using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Boletim;
using Boletim.Models;
using Microsoft.Owin.Security;
using SistemaBoletim.Repositories;

public class AlunoController : Controller
{
    private BoletimOnline2Entities3 db = new BoletimOnline2Entities3();


    // GET: Administrador
    public ActionResult Index()
    {
        var Aluno = db.ALUNO.Include(a => a.Usuario);
        return View(Aluno.ToList());
    }

    // GET: Administrador/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
     ALUNO aluno = db.ALUNO.Find(id);
        if (aluno == null)
        {
            return HttpNotFound();
        }
        return View(aluno);
    }

    public ActionResult VerificaSeEmailJaExiste(string Email)
    {
        var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == Email.ToUpper()).FirstOrDefault();
        ModelState.AddModelError("email", "E-mail já cadastrado na base");
        var EmailNaoExiste = true;
        if (Usuario != null)
        {
            EmailNaoExiste = false;
        }

        return Json(EmailNaoExiste, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateAluno(AlunoViewModel alunoViewModel)
    {
        if (ModelState.IsValid)
        {
            var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == alunoViewModel.Email.ToUpper()).FirstOrDefault();
            if (Usuario != null)
            {
                ModelState.AddModelError("email", "E-mail já cadastrado na base");
            }
            else
            {
                ALUNO aluno = new ALUNO()
                {
                    NOME = alunoViewModel.Nome,
                    Usuario = new Usuario()
                    {
                        Email = alunoViewModel.Email,
                        HashSenha = GerarHash(alunoViewModel.Senha),
                        FlagSenhaTemp = alunoViewModel.SenhaTemporaria ? "S" : "N"
                    }
                };
                db.ALUNO.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return View(alunoViewModel);
    }
    public ActionResult CreateAluno()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult EditAluno(AlunoViewModel AlunoViewModel)
    {

        if (ModelState.IsValid)
        {
           ALUNO Aluno = db.ALUNO.Find(AlunoViewModel.Alunoid);

            var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == AlunoViewModel.Email.ToUpper()).FirstOrDefault();
            if (Usuario != null && Aluno.Usuario.UsuarioId != Usuario.UsuarioId)
            {
                ModelState.AddModelError("email", "E-mail já cadastrado na base");
            }
            else
            {
                Aluno.NOME = AlunoViewModel.Nome;
                Aluno.Usuario.Email = AlunoViewModel.Email;
                Aluno.Usuario.HashSenha = GerarHash(AlunoViewModel.Senha);
                Aluno.Usuario.FlagSenhaTemp = AlunoViewModel.SenhaTemporaria ? "S" : "N";

                db.Entry(Aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return View(AlunoViewModel);
    }

    public ActionResult EditAluno(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ALUNO Aluno = db.ALUNO.Find(id);
        if (Aluno == null)
        {
            return HttpNotFound();
        }
        AlunoViewModel alunoViewModel = new AlunoViewModel()
        {
            Alunoid = Aluno.COD_ALUNO,
            Email = Aluno.Usuario.Email,
            Nome = Aluno.NOME
        };
        return View(alunoViewModel);
    }

   
    // GET: Administrador/Create
    public ActionResult Create()
    {
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email");
        return View();
    }

    // POST: Administrador/Create
    // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
    // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "COD_ALUNO,Nome,UsuarioId")] ALUNO aluno)
    {
        if (ModelState.IsValid)
        {
            db.ALUNO.Add(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", aluno.UsuarioId);
        return View(aluno);
    }

    // GET: Administrador/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ALUNO aluno = db.ALUNO.Find(id);
        if (aluno == null)
        {
            return HttpNotFound();
        }
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", aluno.UsuarioId);
        return View(aluno);
    }

    // POST: Administrador/Edit/5
    // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
    // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Cod_Aluno,Nome_Aluno,UsuarioId")] ALUNO aluno)
    {
        if (ModelState.IsValid)
        {
            db.Entry(aluno).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", aluno.UsuarioId);
        return View(aluno);
    }

    // GET: Administrador/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ALUNO aluno = db.ALUNO.Find(id);
        if (aluno == null)
        {
            return HttpNotFound();
        }
        return View(aluno);
    }

    // POST: Administrador/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        ALUNO aluno = db.ALUNO.Find(id);
        db.ALUNO.Remove(aluno);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
    private static string GerarHash(string senha)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            //Converte a senha para um array de bytes e calcula o hash
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
            //Cria um StringBuilder para coletar os bytes e criar a string com o hash
            StringBuilder sBuilder = new StringBuilder();
            //Esse laço percorre cada byte do array de bytes do hash
            //e obtendo sua representação hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                //cada byte se transforam em 2 caracteres hexa(0..9,A..F)
                sBuilder.Append(data[i].ToString("x2"));
            }
            //retorna a string hexadecimal correspondente ao hash
            return sBuilder.ToString();
        }
    }


    //[Authorize(Roles = "SenhaTemporaria")]
 
  

    //[Authorize(Roles ="SenhaTemporaria")]
    



   


   
    
}
