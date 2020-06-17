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
    public class AVALIACAOController : Controller
    {
        private BoletimOnline2Entities1 db = new BoletimOnline2Entities1();

        // GET: AVALIACAO
        public ActionResult Index()
        {
            var aVALIACAO = db.AVALIACAO.Include(a => a.PROFMATERIATURMA);
            return View(aVALIACAO.ToList());
        }

        // GET: AVALIACAO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVALIACAO aVALIACAO = db.AVALIACAO.Find(id);
            if (aVALIACAO == null)
            {
                return HttpNotFound();
            }
            return View(aVALIACAO);
        }

        // GET: AVALIACAO/Create
        public ActionResult Create()
        {
            ViewBag.COD_PROF = new SelectList(db.PROFMATERIATURMA, "COD_PROF", "COD_PROF");
            return View();
        }

        // POST: AVALIACAO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AVALIACAO,NOME,DESCRICAO,DATA,PESO,COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO")] AVALIACAO aVALIACAO)
        {
            if (ModelState.IsValid)
            {
                db.AVALIACAO.Add(aVALIACAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_PROF = new SelectList(db.PROFMATERIATURMA, "COD_PROF", "COD_PROF", aVALIACAO.COD_PROF);
            return View(aVALIACAO);
        }

        // GET: AVALIACAO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVALIACAO aVALIACAO = db.AVALIACAO.Find(id);
            if (aVALIACAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_PROF = new SelectList(db.PROFMATERIATURMA, "COD_PROF", "COD_PROF", aVALIACAO.COD_PROF);
            return View(aVALIACAO);
        }

        // POST: AVALIACAO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AVALIACAO,NOME,DESCRICAO,DATA,PESO,COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO")] AVALIACAO aVALIACAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aVALIACAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_PROF = new SelectList(db.PROFMATERIATURMA, "COD_PROF", "COD_PROF", aVALIACAO.COD_PROF);
            return View(aVALIACAO);
        }

        // GET: AVALIACAO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVALIACAO aVALIACAO = db.AVALIACAO.Find(id);
            if (aVALIACAO == null)
            {
                return HttpNotFound();
            }
            return View(aVALIACAO);
        }

        // POST: AVALIACAO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AVALIACAO aVALIACAO = db.AVALIACAO.Find(id);
            db.AVALIACAO.Remove(aVALIACAO);
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
