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
    public class TURMAController : Controller
    {
        private BoletimOnline2Entities3 db = new BoletimOnline2Entities3();

        // GET: TURMA
        public ActionResult Index()
        {
            return View(db.TURMA.ToList());
        }

        // GET: TURMA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TURMA tURMA = db.TURMA.Find(id);
            if (tURMA == null)
            {
                return HttpNotFound();
            }
            return View(tURMA);
        }

        // GET: TURMA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TURMA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_TURMA,SERIE,PERIODO_LET")] TURMA tURMA)
        {
            if (ModelState.IsValid)
            {
                db.TURMA.Add(tURMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tURMA);
        }

        // GET: TURMA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TURMA tURMA = db.TURMA.Find(id);
            if (tURMA == null)
            {
                return HttpNotFound();
            }
            return View(tURMA);
        }

        // POST: TURMA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_TURMA,SERIE,PERIODO_LET")] TURMA tURMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tURMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tURMA);
        }

        // GET: TURMA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TURMA tURMA = db.TURMA.Find(id);
            if (tURMA == null)
            {
                return HttpNotFound();
            }
            return View(tURMA);
        }

        // POST: TURMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TURMA tURMA = db.TURMA.Find(id);
            db.TURMA.Remove(tURMA);
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
