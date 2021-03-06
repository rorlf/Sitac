﻿using System;
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
    public class protocoloesController : Controller
    {
        private testandoContext db = new testandoContext();

        // GET: protocoloes
        public ActionResult Index()
        {
            return View(db.protocoloes.ToList());
        }

        // GET: protocoloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            protocolo protocolo = db.protocoloes.Find(id);
            if (protocolo == null)
            {
                return HttpNotFound();
            }
            return View(protocolo);
        }

        // GET: protocoloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: protocoloes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ano,data_cadastro,data_prazo,protocolo_status_id")] protocolo protocolo)
        {
            if (ModelState.IsValid)
            {
                db.protocoloes.Add(protocolo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(protocolo);
        }

        // GET: protocoloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            protocolo protocolo = db.protocoloes.Find(id);
            if (protocolo == null)
            {
                return HttpNotFound();
            }
            return View(protocolo);
        }

        // POST: protocoloes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ano,data_cadastro,data_prazo,protocolo_status_id")] protocolo protocolo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protocolo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(protocolo);
        }

        // GET: protocoloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            protocolo protocolo = db.protocoloes.Find(id);
            if (protocolo == null)
            {
                return HttpNotFound();
            }
            return View(protocolo);
        }

        // POST: protocoloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            protocolo protocolo = db.protocoloes.Find(id);
            db.protocoloes.Remove(protocolo);
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
