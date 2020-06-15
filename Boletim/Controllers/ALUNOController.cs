using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boletim;

namespace Boletim.Controllers
{
    public class ALUNOController : Controller
    {
        private BoletimOnlineEntities5 db = new BoletimOnlineEntities5();

        // GET: ALUNO
        public ActionResult Index()
        {
            var aLUNO = db.ALUNO.Include(a => a.Usuario);
            return View(aLUNO.ToList());
        }

        // GET: ALUNO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO aLUNO = db.ALUNO.Find(id);
            if (aLUNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUNO);
        }

        // GET: ALUNO/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email");
            return View();
        }

        // POST: ALUNO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ALUNO,EMAIL_ALUNO,NOME,UsuarioId")] ALUNO aLUNO)
        {
            if (ModelState.IsValid)
            {
                db.ALUNO.Add(aLUNO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", aLUNO.UsuarioId);
            return View(aLUNO);
        }

        // GET: ALUNO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO aLUNO = db.ALUNO.Find(id);
            if (aLUNO == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", aLUNO.UsuarioId);
            return View(aLUNO);
        }

        // POST: ALUNO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ALUNO,EMAIL_ALUNO,NOME,UsuarioId")] ALUNO aLUNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", aLUNO.UsuarioId);
            return View(aLUNO);
        }

        // GET: ALUNO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO aLUNO = db.ALUNO.Find(id);
            if (aLUNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUNO);
        }

        // POST: ALUNO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUNO aLUNO = db.ALUNO.Find(id);
            db.ALUNO.Remove(aLUNO);
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
    }
}
