using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaItehl_DeyvidMartinez.Models;

namespace PruebaItehl_DeyvidMartinez.Controllers
{
    public class ModalidadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modalidads
        public ActionResult Index()
        {
            return View(db.Tb_Modalidad.ToList());
        }

        // GET: Modalidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidad modalidad = db.Tb_Modalidad.Find(id);
            if (modalidad == null)
            {
                return HttpNotFound();
            }
            return View(modalidad);
        }

        // GET: Modalidads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modalidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Moda_Id,Moda_Nom")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Modalidad.Add(modalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modalidad);
        }

        // GET: Modalidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidad modalidad = db.Tb_Modalidad.Find(id);
            if (modalidad == null)
            {
                return HttpNotFound();
            }
            return View(modalidad);
        }

        // POST: Modalidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Moda_Id,Moda_Nom")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modalidad);
        }

        // GET: Modalidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidad modalidad = db.Tb_Modalidad.Find(id);
            if (modalidad == null)
            {
                return HttpNotFound();
            }
            return View(modalidad);
        }

        // POST: Modalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modalidad modalidad = db.Tb_Modalidad.Find(id);
            db.Tb_Modalidad.Remove(modalidad);
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
