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
    public class CursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cursos
        public ActionResult Index()
        {
            var tb_Curso = db.Tb_Curso.Include(c => c.Ciudad).Include(c => c.Modalidad).Include(c => c.Pais);
            return View(tb_Curso.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Tb_Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.IdCiudad = new SelectList(db.Tb_Ciudad, "Ciud_Id", "Ciud_Nom");
            ViewBag.IdModalidad = new SelectList(db.Tb_Modalidad, "Moda_Id", "Moda_Nom");
            ViewBag.IdPais = new SelectList(db.Tb_Pais, "Pais_Id", "Pais_Nom");
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Curs_Id,Curs_Nom,Curs_Desc,IdModalidad,Curs_Costo,IdPais,IdCiudad,Curs_Direc")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCiudad = new SelectList(db.Tb_Ciudad, "Ciud_Id", "Ciud_Nom", curso.IdCiudad);
            ViewBag.IdModalidad = new SelectList(db.Tb_Modalidad, "Moda_Id", "Moda_Nom", curso.IdModalidad);
            ViewBag.IdPais = new SelectList(db.Tb_Pais, "Pais_Id", "Pais_Nom", curso.IdPais);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Tb_Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCiudad = new SelectList(db.Tb_Ciudad, "Ciud_Id", "Ciud_Nom", curso.IdCiudad);
            ViewBag.IdModalidad = new SelectList(db.Tb_Modalidad, "Moda_Id", "Moda_Nom", curso.IdModalidad);
            ViewBag.IdPais = new SelectList(db.Tb_Pais, "Pais_Id", "Pais_Nom", curso.IdPais);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Curs_Id,Curs_Nom,Curs_Desc,IdModalidad,Curs_Costo,IdPais,IdCiudad,Curs_Direc")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCiudad = new SelectList(db.Tb_Ciudad, "Ciud_Id", "Ciud_Nom", curso.IdCiudad);
            ViewBag.IdModalidad = new SelectList(db.Tb_Modalidad, "Moda_Id", "Moda_Nom", curso.IdModalidad);
            ViewBag.IdPais = new SelectList(db.Tb_Pais, "Pais_Id", "Pais_Nom", curso.IdPais);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Tb_Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Tb_Curso.Find(id);
            db.Tb_Curso.Remove(curso);
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
