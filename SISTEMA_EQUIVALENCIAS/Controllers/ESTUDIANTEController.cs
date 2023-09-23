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
    public class ESTUDIANTEController : Controller
    {
        private EQUIVALENCIAEntities db = new EQUIVALENCIAEntities();

        // GET: ESTUDIANTE
        public ActionResult Index()
        {
            var eSTUDIANTE = db.ESTUDIANTE.Include(e => e.CARRERA);
            return View(eSTUDIANTE.ToList());
        }

        // GET: ESTUDIANTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTE/Create
        public ActionResult Create()
        {
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE");
            return View();
        }

        // POST: ESTUDIANTE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NO_CARNET,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TELEFONO,FECHA_NAC,DIRECCION,CORREO,DPI,ID_CARRERA,INSCRITO")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.ESTUDIANTE.Add(eSTUDIANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE", eSTUDIANTE.ID_CARRERA);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE", eSTUDIANTE.ID_CARRERA);
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NO_CARNET,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TELEFONO,FECHA_NAC,DIRECCION,CORREO,DPI,ID_CARRERA, INSCRITO")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTUDIANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE", eSTUDIANTE.ID_CARRERA);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            db.ESTUDIANTE.Remove(eSTUDIANTE);
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
