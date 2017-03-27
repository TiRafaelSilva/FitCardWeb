using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fitcard.Web.Data;
using Fitcard.Web.Models;

namespace Fitcard.Web.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private FitCardContext db = new FitCardContext();

        // GET: Estabelecimento
        public ActionResult Index()
        {
            var estabelecimento = db.Estabelecimento.Include(e => e.Categoria);
            return View(estabelecimento.ToList());
        }

        // GET: Estabelecimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Create
        public ActionResult Create()
        {
            ViewBag.CAT_ID = new SelectList(db.Categoria, "CAT_ID", "CAT_NOME");
            return View();
        }

        // POST: Estabelecimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EST_ID,EST_NOME,EST_NOME_FANTASIA,EST_CNPJ,EST_EMAIL,EST_TELEFONE,CAT_ID,EST_STATUS")] Estabelecimento estabelecimento)
        {
            estabelecimento.Categoria = db.Categoria.Find(estabelecimento.CAT_ID);

            if (estabelecimento.validaTipo(estabelecimento))
            {
                if (ModelState.IsValid)
                {
                    db.Estabelecimento.Add(estabelecimento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CAT_ID = new SelectList(db.Categoria, "CAT_ID", "CAT_NOME", estabelecimento.CAT_ID);
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAT_ID = new SelectList(db.Categoria, "CAT_ID", "CAT_NOME", estabelecimento.CAT_ID);
            return View(estabelecimento);
        }

        // POST: Estabelecimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EST_ID,EST_NOME,EST_NOME_FANTASIA,EST_CNPJ,EST_EMAIL,EST_TELEFONE,CAT_ID,EST_STATUS")] Estabelecimento estabelecimento)
        {
            estabelecimento.Categoria = db.Categoria.Find(estabelecimento.CAT_ID);

            if (estabelecimento.validaTipo(estabelecimento)){
                if (ModelState.IsValid)
                {
                    db.Entry(estabelecimento).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

   
            ViewBag.CAT_ID = new SelectList(db.Categoria, "CAT_ID", "CAT_NOME", estabelecimento.CAT_ID);
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }

            db.Estabelecimento.Remove(estabelecimento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Estabelecimento/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
        //    db.Estabelecimento.Remove(estabelecimento);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
