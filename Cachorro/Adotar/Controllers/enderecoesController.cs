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
    public class enderecoesController : Controller
    {
        private adotarEntities db = new adotarEntities();

        // GET: enderecoes
        public ActionResult Index()
        {
            var endereco = db.endereco.Include(e => e.bairro);
            return View(endereco.ToList());
        }

        // GET: enderecoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: enderecoes/Create
        public ActionResult Create()
        {
            ViewBag.Bairro_id = new SelectList(db.bairro, "id", "descricao");
            return View();
        }

        // POST: enderecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cep,complemento,numero,Bairro_id")] endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bairro_id = new SelectList(db.bairro, "id", "descricao", endereco.Bairro_id);
            return View(endereco);
        }

        // GET: enderecoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bairro_id = new SelectList(db.bairro, "id", "descricao", endereco.Bairro_id);
            return View(endereco);
        }

        // POST: enderecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cep,complemento,numero,Bairro_id")] endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bairro_id = new SelectList(db.bairro, "id", "descricao", endereco.Bairro_id);
            return View(endereco);
        }

        // GET: enderecoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            endereco endereco = db.endereco.Find(id);
            db.endereco.Remove(endereco);
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
