using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SISTEMA_EQUIVALENCIAS.Models;

namespace SISTEMA_EQUIVALENCIAS.Controllers
{
    public class SEDEController : Controller
    {
        private EQUIVALENCIAEntities db = new EQUIVALENCIAEntities();

        // GET: SEDE
        public ActionResult Index()
        {
            return View(db.SEDE.ToList());
        }

        // GET: SEDE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEDE sEDE = db.SEDE.Find(id);
            if (sEDE == null)
            {
                return HttpNotFound();
            }
            return View(sEDE);
        }

        // GET: SEDE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEDE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SEDE,NOMBRE,DESCRIPCION")] SEDE sEDE)
        {
            if (ModelState.IsValid)
            {
                db.SEDE.Add(sEDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEDE);
        }

        // GET: SEDE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEDE sEDE = db.SEDE.Find(id);
            if (sEDE == null)
            {
                return HttpNotFound();
            }
            return View(sEDE);
        }

        // POST: SEDE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SEDE,NOMBRE,DESCRIPCION")] SEDE sEDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEDE);
        }

        // GET: SEDE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEDE sEDE = db.SEDE.Find(id);
            if (sEDE == null)
            {
                return HttpNotFound();
            }
            return View(sEDE);
        }

        // POST: SEDE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEDE sEDE = db.SEDE.Find(id);
            db.SEDE.Remove(sEDE);
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
