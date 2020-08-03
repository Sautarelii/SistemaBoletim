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
    public class NOTAController : Controller
    {
        private BoletimOnline2Entities3 db = new BoletimOnline2Entities3();

        // GET: NOTA
        public ActionResult Index()
        {
            var nOTA = db.NOTA.Include(n => n.MATERIA).Include(n => n.PROFESSOR).Include(n => n.TURMA);
            return View(nOTA.ToList());
        }

        // GET: NOTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA nOTA = db.NOTA.Find(id);
            if (nOTA == null)
            {
                return HttpNotFound();
            }
            return View(nOTA);
        }

        // GET: NOTA/Create
        public ActionResult Create()
        {
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME");
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME");
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE");
            return View();
        }

        // POST: NOTA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_NOTA,COD_ALUNO,COD_PROF,COD_MATERIA,COD_TURMA,VALOR")] NOTA nOTA)
        {
            if (ModelState.IsValid)
            {
                db.NOTA.Add(nOTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", nOTA.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME", nOTA.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", nOTA.COD_TURMA);
            return View(nOTA);
        }

        // GET: NOTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA nOTA = db.NOTA.Find(id);
            if (nOTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", nOTA.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME", nOTA.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", nOTA.COD_TURMA);
            return View(nOTA);
        }

        // POST: NOTA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_NOTA,COD_ALUNO,COD_PROF,COD_MATERIA,COD_TURMA,VALOR")] NOTA nOTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", nOTA.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME", nOTA.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", nOTA.COD_TURMA);
            return View(nOTA);
        }

        // GET: NOTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA nOTA = db.NOTA.Find(id);
            if (nOTA == null)
            {
                return HttpNotFound();
            }
            return View(nOTA);
        }

        // POST: NOTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOTA nOTA = db.NOTA.Find(id);
            db.NOTA.Remove(nOTA);
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
