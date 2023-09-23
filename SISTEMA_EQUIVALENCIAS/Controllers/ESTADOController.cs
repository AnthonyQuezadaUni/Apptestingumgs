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
    public class ESTADOController : Controller
    {
        private EQUIVALENCIAEntities db = new EQUIVALENCIAEntities();

        // GET: ESTADO
        public ActionResult Index()
        {
            return View(db.ESTADO.ToList());
        }

        // GET: ESTADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO eSTADO = db.ESTADO.Find(id);
            if (eSTADO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO);
        }

        // GET: ESTADO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTADO,NOMBRE,DESCRIPCION")] ESTADO eSTADO)
        {
            if (ModelState.IsValid)
            {
                db.ESTADO.Add(eSTADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADO);
        }

        // GET: ESTADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO eSTADO = db.ESTADO.Find(id);
            if (eSTADO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO);
        }

        // POST: ESTADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTADO,NOMBRE,DESCRIPCION")] ESTADO eSTADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADO);
        }

        // GET: ESTADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO eSTADO = db.ESTADO.Find(id);
            if (eSTADO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO);
        }

        // POST: ESTADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADO eSTADO = db.ESTADO.Find(id);
            db.ESTADO.Remove(eSTADO);
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
