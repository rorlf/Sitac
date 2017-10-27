using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testando.Models;

namespace testando.Controllers
{
    public class ProfissionalsController : Controller
    {
        private testandoContext db = new testandoContext();

        // GET: Profissionals
        public ActionResult Index()
        {
            return View(db.Profissionals.ToList());
        }

        // GET: Profissionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissionals.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        // GET: Profissionals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profissionals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cpf,nome,data_nascimento")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                db.Profissionals.Add(profissional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profissional);
        }

        // GET: Profissionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissionals.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        // POST: Profissionals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cpf,nome,data_nascimento")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profissional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profissional);
        }

        // GET: Profissionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissional profissional = db.Profissionals.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        // POST: Profissionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profissional profissional = db.Profissionals.Find(id);
            db.Profissionals.Remove(profissional);
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
