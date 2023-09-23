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
    public class EQUIVALENCIA_CURSOController : Controller
    {
        private EQUIVALENCIAEntities db = new EQUIVALENCIAEntities();

        // GET: EQUIVALENCIA_CURSO
        public ActionResult Index()
        {
            var eQUIVALENCIA_CURSO = db.EQUIVALENCIA_CURSO.Include(e => e.CURSO).Include(e => e.EQUIVALENCIA).Include(e => e.ESTADO);
            return View(eQUIVALENCIA_CURSO.ToList());
        }

        // GET: EQUIVALENCIA_CURSO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIVALENCIA_CURSO eQUIVALENCIA_CURSO = db.EQUIVALENCIA_CURSO.Find(id);
            if (eQUIVALENCIA_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(eQUIVALENCIA_CURSO);
        }

        // GET: EQUIVALENCIA_CURSO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CURSO = new SelectList(db.CURSO, "ID_CURSO", "NOMBRE");
            ViewBag.ID_EQUIVALENCIA = new SelectList(db.EQUIVALENCIA, "ID_EQUIVALENCIA", "LUGAR_FISICO");
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE");
            return View();
        }

        // POST: EQUIVALENCIA_CURSO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EQUIVALENCIA_CURSO,ID_CURSO,ID_EQUIVALENCIA,FECHA_INICIO,FECHA_FIN,ID_ESTADO,OBSERVACIONES")] EQUIVALENCIA_CURSO eQUIVALENCIA_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.EQUIVALENCIA_CURSO.Add(eQUIVALENCIA_CURSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CURSO = new SelectList(db.CURSO, "ID_CURSO", "NOMBRE", eQUIVALENCIA_CURSO.ID_CURSO);
            ViewBag.ID_EQUIVALENCIA = new SelectList(db.EQUIVALENCIA, "ID_EQUIVALENCIA", "LUGAR_FISICO", eQUIVALENCIA_CURSO.ID_EQUIVALENCIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE", eQUIVALENCIA_CURSO.ID_ESTADO);
            return View(eQUIVALENCIA_CURSO);
        }

        // GET: EQUIVALENCIA_CURSO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIVALENCIA_CURSO eQUIVALENCIA_CURSO = db.EQUIVALENCIA_CURSO.Find(id);
            if (eQUIVALENCIA_CURSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CURSO = new SelectList(db.CURSO, "ID_CURSO", "NOMBRE", eQUIVALENCIA_CURSO.ID_CURSO);
            ViewBag.ID_EQUIVALENCIA = new SelectList(db.EQUIVALENCIA, "ID_EQUIVALENCIA", "LUGAR_FISICO", eQUIVALENCIA_CURSO.ID_EQUIVALENCIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE", eQUIVALENCIA_CURSO.ID_ESTADO);
            return View(eQUIVALENCIA_CURSO);
        }

        // POST: EQUIVALENCIA_CURSO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EQUIVALENCIA_CURSO,ID_CURSO,ID_EQUIVALENCIA,FECHA_INICIO,FECHA_FIN,ID_ESTADO,OBSERVACIONES")] EQUIVALENCIA_CURSO eQUIVALENCIA_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUIVALENCIA_CURSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CURSO = new SelectList(db.CURSO, "ID_CURSO", "NOMBRE", eQUIVALENCIA_CURSO.ID_CURSO);
            ViewBag.ID_EQUIVALENCIA = new SelectList(db.EQUIVALENCIA, "ID_EQUIVALENCIA", "LUGAR_FISICO", eQUIVALENCIA_CURSO.ID_EQUIVALENCIA);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO, "ID_ESTADO", "NOMBRE", eQUIVALENCIA_CURSO.ID_ESTADO);
            return View(eQUIVALENCIA_CURSO);
        }

        // GET: EQUIVALENCIA_CURSO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIVALENCIA_CURSO eQUIVALENCIA_CURSO = db.EQUIVALENCIA_CURSO.Find(id);
            if (eQUIVALENCIA_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(eQUIVALENCIA_CURSO);
        }

        // POST: EQUIVALENCIA_CURSO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIVALENCIA_CURSO eQUIVALENCIA_CURSO = db.EQUIVALENCIA_CURSO.Find(id);
            db.EQUIVALENCIA_CURSO.Remove(eQUIVALENCIA_CURSO);
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
