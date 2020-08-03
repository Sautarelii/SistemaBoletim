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

public class AdministradorController : Controller
{
    private BoletimOnline2Entities3 db = new BoletimOnline2Entities3();


    // GET: Administrador
    public ActionResult Index()
    {
        var administrador = db.Administrador.Include(a => a.Usuario);
        return View(administrador.ToList());
    }

    // GET: Administrador/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Administrador administrador = db.Administrador.Find(id);
        if (administrador == null)
        {
            return HttpNotFound();
        }
        return View(administrador);
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
    public ActionResult CreateAdmin( AdminViewModel adminViewModel)
    {
        if (ModelState.IsValid)
        {
            var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == adminViewModel.Email.ToUpper()).FirstOrDefault();
            if (Usuario != null)
            {
                ModelState.AddModelError("email", "E-mail já cadastrado na base");
            } else { 
                Administrador administrador = new Administrador()
                {
                    Nome_Administrador = adminViewModel.Nome,
                    Usuario = new Usuario()
                    {
                        Email = adminViewModel.Email,
                        HashSenha = GerarHash(adminViewModel.Senha),
                        FlagSenhaTemp = adminViewModel.SenhaTemporaria ? "S" : "N"
                    }
                };
                db.Administrador.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return View(adminViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult EditAdmin(AdminViewModel adminViewModel)
    {

        if (ModelState.IsValid)
        {
            Administrador admin = db.Administrador.Find(adminViewModel.AdminId);

            var Usuario = db.Usuario.Where(u => u.Email.ToUpper() == adminViewModel.Email.ToUpper()).FirstOrDefault();
            if (Usuario != null && admin.Usuario.UsuarioId != Usuario.UsuarioId)
            {
                ModelState.AddModelError("email", "E-mail já cadastrado na base");
            }
            else
            {
                admin.Nome_Administrador = adminViewModel.Nome;
                admin.Usuario.Email = adminViewModel.Email;
                admin.Usuario.HashSenha = GerarHash(adminViewModel.Senha);
                admin.Usuario.FlagSenhaTemp = adminViewModel.SenhaTemporaria ? "S" : "N";

                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return View(adminViewModel);
    }

    public ActionResult EditAdmin(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Administrador administrador = db.Administrador.Find(id);
        if (administrador == null)
        {
            return HttpNotFound();
        }
        AdminViewModel adminViewModel = new AdminViewModel()
        {
            AdminId = administrador.Cod_Administrador,
            Email = administrador.Usuario.Email,
            Nome = administrador.Nome_Administrador
        };
        return View(adminViewModel);
    }

    public ActionResult CreateAdmin()
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
    public ActionResult Create([Bind(Include = "Cod_Administrador,Nome_Administrador,UsuarioId")] Administrador administrador)
    {
        if (ModelState.IsValid)
        {
            db.Administrador.Add(administrador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", administrador.UsuarioId);
        return View(administrador);
    }

    // GET: Administrador/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Administrador administrador = db.Administrador.Find(id);
        if (administrador == null)
        {
            return HttpNotFound();
        }
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", administrador.UsuarioId);
        return View(administrador);
    }

    // POST: Administrador/Edit/5
    // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
    // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Cod_Administrador,Nome_Administrador,UsuarioId")] Administrador administrador)
    {
        if (ModelState.IsValid)
        {
            db.Entry(administrador).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", administrador.UsuarioId);
        return View(administrador);
    }

    // GET: Administrador/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Administrador administrador = db.Administrador.Find(id);
        if (administrador == null)
        {
            return HttpNotFound();
        }
        return View(administrador);
    }

    // POST: Administrador/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Administrador administrador = db.Administrador.Find(id);
        db.Administrador.Remove(administrador);
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

    [AllowAnonymous]
    public ActionResult Login()
    {
        return View();
    }

    //[Authorize(Roles = "SenhaTemporaria")]
    [AllowAnonymous]
    public ActionResult RedefinirSenha(int UsuarioId)
    {
        ViewBag.UsuarioId = UsuarioId;
        return View();
    }

    //[Authorize(Roles ="SenhaTemporaria")]
    [AllowAnonymous]
    [HttpPost]
    public ActionResult RedefinirSenha(FormCollection form)
    {
        int UsuarioId = Int32.Parse(form["UsuarioId"]);
        //var Usuario = (ClaimsIdentity)User.Identity;
        //ViewBag.UsuarioId = Usuario.Claims.Where(c => c.Type == ClaimTypes.Sid).FirstOrDefault();
        if (form["Senha"] == form["ConfirmaSenha"])
        {
            
            string novaSenha = form["Senha"];

            Usuario user = db.Usuario.Find(UsuarioId);
            user.HashSenha = GerarHash(novaSenha);
            user.FlagSenhaTemp = "N";

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();


            //Desloga
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");

            //Loga novamente
            CriaPerfil(user, "Administrador");

            return RedirectToAction("Cadastramentos", "Home");
        } else
        {
            ModelState.AddModelError("ConfirmarSenha", "A Senha não confere");
        }
        ViewBag.UsuarioId = UsuarioId;
        return View();
    }



    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login(LoginViewModel loginModel)
    {
        var usuarioRepository = new UsuarioRepository(db);

        //Busca o usuario por meio do repositorio passando o email
        var user = usuarioRepository.BuscarPorEmail(loginModel.Email);
        //Verifica se encontrou o usuario e se a senha cofere
        if (user != null && user.HashSenha == GerarHash(loginModel.Senha))
        {
            if (user.FlagSenhaTemp == "S")
            {

                CriaPerfil(user, "SenhaTemporaria");

                return RedirectToAction("RedefinirSenha", new { UsuarioId = user.UsuarioId });
            } else
            {
                string perfil = "Comum";
                if (user.Administrador.Count > 0)
                {
                    perfil = "Administrador";
                } else if (user.ALUNO.Count > 0)
                {
                    perfil = "ALUNO";
                } else if (user.PROFESSOR.Count > 0)
                {
                    perfil = "PROFESSOR";
                }

                    CriaPerfil(user, perfil);

                return RedirectToAction("Cadastramentos", "Home");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos");
            return View(loginModel);
        }
    }


    private void CriaPerfil(Usuario user, string perfil)
    {
        var identity = new ClaimsIdentity(new[]
        {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Sid, user.UsuarioId + ""),
                        new Claim(ClaimTypes.Role, perfil)
                    }, "ApplicationCookie");


        var context = Request.GetOwinContext();
        var authManager = context.Authentication;
        authManager.SignIn(identity);
        
    }

    public ActionResult LogOut()
    {
        var ctx = Request.GetOwinContext();
        var authManager = ctx.Authentication;
        authManager.SignOut("ApplicationCookie");
        //Elimina qualquer informação que tenha sido salva na sessao
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        return RedirectToAction("Login", "Administrador");
    }
}

    

