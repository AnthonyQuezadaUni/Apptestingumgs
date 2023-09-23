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
    public class USUARIOController : Controller
    {
        private EQUIVALENCIAEntities db = new EQUIVALENCIAEntities();

        // GET: USUARIO
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.ESTUDIANTE);
            return View(uSUARIO.ToList());
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE");
            return View();
        }

        // POST: USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMBRE,CLAVE,NO_CARNET")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                uSUARIO.CLAVE = EnCryptDecrypt.CryptorEngine.Encrypt(uSUARIO.CLAVE, true);
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE", uSUARIO.NO_CARNET);
            return View(uSUARIO);
        }

        // GET: USUARIO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE", uSUARIO.NO_CARNET);
            return View(uSUARIO);
        }

        // POST: USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NOMBRE,CLAVE,NO_CARNET")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NO_CARNET = new SelectList(db.ESTUDIANTE, "NO_CARNET", "PRIMER_NOMBRE", uSUARIO.NO_CARNET);
            return View(uSUARIO);
        }

        // GET: USUARIO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
