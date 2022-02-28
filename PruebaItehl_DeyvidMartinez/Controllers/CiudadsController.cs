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
    public class CiudadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ciudads
        public ActionResult Index()
        {
            return View(db.Tb_Ciudad.ToList());
        }

        // GET: Ciudads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Tb_Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ciud_Id,Ciud_Nom")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Ciudad.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ciudad);
        }

        // GET: Ciudads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Tb_Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ciud_Id,Ciud_Nom")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ciudad);
        }

        // GET: Ciudads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Tb_Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = db.Tb_Ciudad.Find(id);
            db.Tb_Ciudad.Remove(ciudad);
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
