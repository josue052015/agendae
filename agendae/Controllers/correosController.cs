﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using agendae.basea;

namespace agendae.Controllers
{
    public class correosController : Controller
    {
        private agendafEntiti db = new agendafEntiti();

        // GET: correos
        public ActionResult Index()
        {
            return View(db.correo.ToList());
        }

        // GET: correos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            correo correo = db.correo.Find(id);
            if (correo == null)
            {
                return HttpNotFound();
            }
            return View(correo);
        }

        // GET: correos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: correos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_correo,correo1,id_persona")] correo correo)
        {
            if (ModelState.IsValid)
            {
                db.correo.Add(correo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(correo);
        }

        // GET: correos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            correo correo = db.correo.Find(id);
            if (correo == null)
            {
                return HttpNotFound();
            }
            return View(correo);
        }

        // POST: correos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_correo,correo1,id_persona")] correo correo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(correo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(correo);
        }

        // GET: correos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            correo correo = db.correo.Find(id);
            if (correo == null)
            {
                return HttpNotFound();
            }
            return View(correo);
        }

        // POST: correos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            correo correo = db.correo.Find(id);
            db.correo.Remove(correo);
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