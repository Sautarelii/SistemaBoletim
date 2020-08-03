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

public class PROFESSORController : Controller
{
    private BoletimOnline2Entities3 db = new BoletimOnline2Entities3();


    // GET: Administrador
    public ActionResult Index()
    {
        var professor = db.PROFESSOR.Include(a => a.Usuario);
        return View(professor.ToList());
    }

    // GET: Administrador/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        PROFESSOR professor = db.PROFESSOR.Find(id);
        if (professor == null)
        {
            return HttpNotFound();
        }
        return View(professor);
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
    public ActionResult CreateProfessor(ProfessorViewModel professorViewModel)
    {
        if (ModelState.IsValid)
        {
            var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == professorViewModel.Email.ToUpper()).FirstOrDefault();
            if (Usuario != null)
            {
                ModelState.AddModelError("email", "E-mail já cadastrado na base");
            }
            else
            {
                PROFESSOR  professor= new PROFESSOR()
                {
                    NOME = professorViewModel.Nome,
                    Usuario = new Usuario()
                    {
                        Email = professorViewModel.Email,
                        HashSenha = GerarHash(professorViewModel.Senha),
                        FlagSenhaTemp = professorViewModel.SenhaTemporaria ? "S" : "N"
                    }
                };
                db.PROFESSOR.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return View(professorViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult EditProfessor(ProfessorViewModel professorViewModel)
    {

        if (ModelState.IsValid)
        {
           PROFESSOR professor = db.PROFESSOR.Find(professorViewModel.Professorid);

            var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == professorViewModel.Email.ToUpper()).FirstOrDefault();
            if (Usuario != null && professor.Usuario.UsuarioId != Usuario.UsuarioId)
            {
                ModelState.AddModelError("email", "E-mail já cadastrado na base");
            }
            else
            {
                professor.NOME = professorViewModel.Nome;
                professor.Usuario.Email = professorViewModel.Email;
                professor.Usuario.HashSenha = GerarHash(professorViewModel.Senha);
                professor.Usuario.FlagSenhaTemp = professorViewModel.SenhaTemporaria ? "S" : "N";

                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return View(professorViewModel);
    }

    public ActionResult EditProfessor(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        PROFESSOR professor = db.PROFESSOR.Find(id);
        if (professor == null)
        {
            return HttpNotFound();
        }
        ProfessorViewModel professorViewModel = new ProfessorViewModel()
        {
            Professorid = professor.COD_PROF,
            Email =professor.Usuario.Email,
            Nome = professor.NOME
        };
        return View(professorViewModel);
    }

    public ActionResult CreateProfessor()
    {

        return View();
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
    public ActionResult Create([Bind(Include = "COD_PROF,Nome,UsuarioId")] PROFESSOR professor)
    {
        if (ModelState.IsValid)
        {
            db.PROFESSOR.Add(professor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", professor.UsuarioId);
        return View(professor);
    }

    // GET: Administrador/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        PROFESSOR professor = db.PROFESSOR.Find(id);
        if (professor == null)
        {
            return HttpNotFound();
        }
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", professor.UsuarioId);
        return View(professor);
    }

    // POST: Administrador/Edit/5
    // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
    // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult EditProfessor([Bind(Include = "COD_PROF,Nome,UsuarioId")] PROFESSOR professor)
    {
        if (ModelState.IsValid)
        {
            db.Entry(professor).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", professor.UsuarioId);
        return View(professor);
    }

    // GET: Administrador/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
       PROFESSOR professor = db.PROFESSOR.Find(id);
        if (professor == null)
        {
            return HttpNotFound();
        }
        return View(professor);
    }

    // POST: Administrador/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        PROFESSOR professor = db.PROFESSOR.Find(id);
        db.PROFESSOR.Remove(professor);
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
}


    //[Authorize(Roles = "SenhaTemporaria")]



//[Authorize(Roles ="SenhaTemporaria")]
