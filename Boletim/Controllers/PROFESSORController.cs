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
    public class PROFESSORController : Controller
    {
        private BoletimOnlineEntities5 db = new BoletimOnlineEntities5();

        // GET: PROFESSOR
        public ActionResult Index()
        {
            var pROFESSOR = db.PROFESSOR.Include(p => p.Usuario);
            return View(pROFESSOR.ToList());
        }

        // GET: PROFESSOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESSOR pROFESSOR = db.PROFESSOR.Find(id);
            if (pROFESSOR == null)
            {
                return HttpNotFound();
            }
            return View(pROFESSOR);
        }

        // GET: PROFESSOR/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email");
            return View();
        }

        // POST: PROFESSOR/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PROF,EMAIL_PROFESSOR,NOME,UsuarioId")] PROFESSOR pROFESSOR)
        {
            if (ModelState.IsValid)
            {
                db.PROFESSOR.Add(pROFESSOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", pROFESSOR.UsuarioId);
            return View(pROFESSOR);
        }

        // GET: PROFESSOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESSOR pROFESSOR = db.PROFESSOR.Find(id);
            if (pROFESSOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", pROFESSOR.UsuarioId);
            return View(pROFESSOR);
        }

        // POST: PROFESSOR/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PROF,EMAIL_PROFESSOR,NOME,UsuarioId")] PROFESSOR pROFESSOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFESSOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Email", pROFESSOR.UsuarioId);
            return View(pROFESSOR);
        }

        // GET: PROFESSOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESSOR pROFESSOR = db.PROFESSOR.Find(id);
            if (pROFESSOR == null)
            {
                return HttpNotFound();
            }
            return View(pROFESSOR);
        }

        // POST: PROFESSOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROFESSOR pROFESSOR = db.PROFESSOR.Find(id);
            db.PROFESSOR.Remove(pROFESSOR);
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
