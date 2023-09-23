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
    public class EQUIVALENCIAController : Controller
    {
        private EQUIVALENCIAEntities db = new EQUIVALENCIAEntities();

        // GET: EQUIVALENCIA
        public ActionResult Index()
        {
            var eQUIVALENCIA = db.EQUIVALENCIA.Include(e => e.SEDE).Include(e => e.ESTUDIANTE);
            return View(eQUIVALENCIA.ToList());
        }

        // GET: EQUIVALENCIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIVALENCIA eQUIVALENCIA = db.EQUIVALENCIA.Find(id);
            if (eQUIVALENCIA == null)
            {
                return HttpNotFound();
            }
            return View(eQUIVALENCIA);
        }

        // GET: EQUIVALENCIA/Create
        public ActionResult Create()
        {
            ViewBag.ID_SEDE = new SelectList(db.SEDE, "ID_SEDE", "NOMBRE");
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE");
            return View();
        }

        // POST: EQUIVALENCIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EQUIVALENCIA,NO_CARNET,ID_SEDE,FECHA_EQUIVALENCIA,LUGAR_FISICO,OBSERVACIONES")] EQUIVALENCIA eQUIVALENCIA)
        {
            if (ModelState.IsValid)
            {
                db.EQUIVALENCIA.Add(eQUIVALENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SEDE = new SelectList(db.SEDE, "ID_SEDE", "NOMBRE", eQUIVALENCIA.ID_SEDE);
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE", eQUIVALENCIA.NO_CARNET);
            return View(eQUIVALENCIA);
        }

        // GET: EQUIVALENCIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIVALENCIA eQUIVALENCIA = db.EQUIVALENCIA.Find(id);
            if (eQUIVALENCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SEDE = new SelectList(db.SEDE, "ID_SEDE", "NOMBRE", eQUIVALENCIA.ID_SEDE);
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE", eQUIVALENCIA.NO_CARNET);
            return View(eQUIVALENCIA);
        }

        // POST: EQUIVALENCIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EQUIVALENCIA,NO_CARNET,ID_SEDE,FECHA_EQUIVALENCIA,LUGAR_FISICO,OBSERVACIONES")] EQUIVALENCIA eQUIVALENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUIVALENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SEDE = new SelectList(db.SEDE, "ID_SEDE", "NOMBRE", eQUIVALENCIA.ID_SEDE);
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE", eQUIVALENCIA.NO_CARNET);
            return View(eQUIVALENCIA);
        }

        // GET: EQUIVALENCIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIVALENCIA eQUIVALENCIA = db.EQUIVALENCIA.Find(id);
            if (eQUIVALENCIA == null)
            {
                return HttpNotFound();
            }
            return View(eQUIVALENCIA);
        }

        // POST: EQUIVALENCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIVALENCIA eQUIVALENCIA = db.EQUIVALENCIA.Find(id);
            db.EQUIVALENCIA.Remove(eQUIVALENCIA);
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
