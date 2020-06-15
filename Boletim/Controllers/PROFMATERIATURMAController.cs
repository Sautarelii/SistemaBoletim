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
    public class PROFMATERIATURMAController : Controller
    {
        private BoletimOnlineEntities5 db = new BoletimOnlineEntities5();

        // GET: PROFMATERIATURMA
        public ActionResult Index()
        {
            var pROFMATERIATURMA = db.PROFMATERIATURMA.Include(p => p.MATERIA).Include(p => p.PROFESSOR).Include(p => p.TURMA);
            return View(pROFMATERIATURMA.ToList());
        }

        // GET: PROFMATERIATURMA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFMATERIATURMA pROFMATERIATURMA = db.PROFMATERIATURMA.Find(id);
            if (pROFMATERIATURMA == null)
            {
                return HttpNotFound();
            }
            return View(pROFMATERIATURMA);
        }

        // GET: PROFMATERIATURMA/Create
        public ActionResult Create()
        {
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME");
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "EMAIL_PROFESSOR");
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE");
            return View();
        }

        // POST: PROFMATERIATURMA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO")] PROFMATERIATURMA pROFMATERIATURMA)
        {
            if (ModelState.IsValid)
            {
                db.PROFMATERIATURMA.Add(pROFMATERIATURMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", pROFMATERIATURMA.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "EMAIL_PROFESSOR", pROFMATERIATURMA.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", pROFMATERIATURMA.COD_TURMA);
            return View(pROFMATERIATURMA);
        }

        // GET: PROFMATERIATURMA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFMATERIATURMA pROFMATERIATURMA = db.PROFMATERIATURMA.Find(id);
            if (pROFMATERIATURMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", pROFMATERIATURMA.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "EMAIL_PROFESSOR", pROFMATERIATURMA.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", pROFMATERIATURMA.COD_TURMA);
            return View(pROFMATERIATURMA);
        }

        // POST: PROFMATERIATURMA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO")] PROFMATERIATURMA pROFMATERIATURMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFMATERIATURMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", pROFMATERIATURMA.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "EMAIL_PROFESSOR", pROFMATERIATURMA.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", pROFMATERIATURMA.COD_TURMA);
            return View(pROFMATERIATURMA);
        }

        // GET: PROFMATERIATURMA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFMATERIATURMA pROFMATERIATURMA = db.PROFMATERIATURMA.Find(id);
            if (pROFMATERIATURMA == null)
            {
                return HttpNotFound();
            }
            return View(pROFMATERIATURMA);
        }

        // POST: PROFMATERIATURMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROFMATERIATURMA pROFMATERIATURMA = db.PROFMATERIATURMA.Find(id);
            db.PROFMATERIATURMA.Remove(pROFMATERIATURMA);
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
