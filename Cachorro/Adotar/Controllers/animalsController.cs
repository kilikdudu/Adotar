using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adotar;

namespace Adotar.Controllers
{
    public class animalsController : Controller
    {
        private adotarEntities db = new adotarEntities();

        // GET: animals
        public ActionResult Index()
        {
            var animal = db.animal.Include(a => a.usuario);
            return View(animal.ToList());
        }

        // GET: animals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animal animal = db.animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: animals/Create
        public ActionResult Create()
        {
            ViewBag.Usuario_id = new SelectList(db.usuario, "id", "nome");
            return View();
        }

        // POST: animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,texto,urlImagem,Usuario_id")] animal animal)
        {
            if (ModelState.IsValid)
            {
                db.animal.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Usuario_id = new SelectList(db.usuario, "id", "nome", animal.Usuario_id);
            return View(animal);
        }

        // GET: animals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animal animal = db.animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Usuario_id = new SelectList(db.usuario, "id", "nome", animal.Usuario_id);
            return View(animal);
        }

        // POST: animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,texto,urlImagem,Usuario_id")] animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Usuario_id = new SelectList(db.usuario, "id", "nome", animal.Usuario_id);
            return View(animal);
        }

        // GET: animals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animal animal = db.animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            animal animal = db.animal.Find(id);
            db.animal.Remove(animal);
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
