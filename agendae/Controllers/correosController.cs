using System;
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
        private agendafEntiti pj = new agendafEntiti();
       

        // GET: correos
        public ActionResult Index()
        {
           /*

             var INFO = (from P in db.persona
                         where P.disponible == false
                         select P);
            var INFA = (from P in db.persona
                        join r in db.correo
                        where P.disponible == false
                        select P);
                        */

            /*    var IN = (from P in db.correo
                            where P.id_persona == Convert.ToInt64(INFO)
                            select P);*/


            /* var correo = db.correo.Include(c => c.persona);
              return View(correo.ToList());*/
            var correo = db.correo.Include(c => c.persona);
          
            return View(correo.ToList().Except(db.correo));
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

          /*  var INFO = (from P in db.persona
                        where P.disponible == true
                        select P);*/
          /*  ViewBag.id_persona = new SelectList(INFO);*/
            /*  ViewBag.id_persona = new SelectList(db.persona, "id_persona", "nombre", correo.id_persona);*/
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
            ViewBag.id_persona = new SelectList(db.persona, "id_persona", "nombre", correo.id_persona);
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
            ViewBag.id_persona = new SelectList(db.persona, "id_persona", "nombre", correo.id_persona);
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
