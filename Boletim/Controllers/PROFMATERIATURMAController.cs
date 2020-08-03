using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boletim;
using Boletim.Models;
namespace Boletim.Controllers
{
    public class PROFMATERIATURMAController : Controller
    {
        private BoletimOnline2Entities3 db = new BoletimOnline2Entities3();

        // GET: PROFMATERIATURMA
        public ActionResult Index()
        {
            return View(db.PROFMATERIATURMA.ToList());
        }
     

        // GET: PROFMATERIATURMA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFMATERIATURMA pROFMATERIATURMA = db.PROFMATERIATURMA.Find();
            if (pROFMATERIATURMA == null)
            {
                return HttpNotFound();
            }
            return View(pROFMATERIATURMA);
        }

        // GET: PROFMATERIATURMA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROFMATERIATURMA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROFMATERIATURMAid,Nome,Email")] PROFMATERIATURMA pROFMATERIATURMA)
        {
            if (ModelState.IsValid)
            {
                db.PROFMATERIATURMA.Add(pROFMATERIATURMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(pROFMATERIATURMA);
        }

        // POST: PROFMATERIATURMA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROFMATERIATURMAid,Nome,Email")] PROFMATERIATURMA pROFMATERIATURMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFMATERIATURMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
