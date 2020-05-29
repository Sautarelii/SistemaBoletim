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
        private ControleAtualiEntities1 db = new ControleAtualiEntities1();

        // GET: PROFESSOR
        public ActionResult Index()
        {
            var pROFESSORs = db.PROFESSORs.Include(p => p.Aluno).Include(p => p.Turma);
            return View(pROFESSORs.ToList());
        }

        // GET: PROFESSOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESSOR pROFESSOR = db.PROFESSORs.Find(id);
            if (pROFESSOR == null)
            {
                return HttpNotFound();
            }
            return View(pROFESSOR);
        }

        // GET: PROFESSOR/Create
        public ActionResult Create()
        {
            ViewBag.IdAluno = new SelectList(db.Alunoes, "idAluno", "Nome");
            ViewBag.IdTurma = new SelectList(db.Turmas, "idTURMA", "SÉRIE");
            return View();
        }

        // POST: PROFESSOR/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProfessor,Nome,Endereco,Cep,Telefone,Celular,dataNascimento,dataCadastro,dataUltAtualizacao,IdTurma,IdAluno")] PROFESSOR pROFESSOR)
        {
            if (ModelState.IsValid)
            {
                db.PROFESSORs.Add(pROFESSOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAluno = new SelectList(db.Alunoes, "idAluno", "Nome", pROFESSOR.IdAluno);
            ViewBag.IdTurma = new SelectList(db.Turmas, "idTURMA", "SÉRIE", pROFESSOR.IdTurma);
            return View(pROFESSOR);
        }

        // GET: PROFESSOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESSOR pROFESSOR = db.PROFESSORs.Find(id);
            if (pROFESSOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAluno = new SelectList(db.Alunoes, "idAluno", "Nome", pROFESSOR.IdAluno);
            ViewBag.IdTurma = new SelectList(db.Turmas, "idTURMA", "SÉRIE", pROFESSOR.IdTurma);
            return View(pROFESSOR);
        }

        // POST: PROFESSOR/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProfessor,Nome,Endereco,Cep,Telefone,Celular,dataNascimento,dataCadastro,dataUltAtualizacao,IdTurma,IdAluno")] PROFESSOR pROFESSOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFESSOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAluno = new SelectList(db.Alunoes, "idAluno", "Nome", pROFESSOR.IdAluno);
            ViewBag.IdTurma = new SelectList(db.Turmas, "idTURMA", "SÉRIE", pROFESSOR.IdTurma);
            return View(pROFESSOR);
        }

        // GET: PROFESSOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESSOR pROFESSOR = db.PROFESSORs.Find(id);
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
            PROFESSOR pROFESSOR = db.PROFESSORs.Find(id);
            db.PROFESSORs.Remove(pROFESSOR);
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
