using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlDeCredito.Models;

namespace ControlDeCredito.Controllers
{
    public class ReciboesController : Controller
    {
        private ControlDeCreditoContainer db = new ControlDeCreditoContainer();

        // GET: Reciboes
        public ActionResult Index()
        {
            var recibo = db.Recibo.Include(r => r.Contrato);
            return View(recibo.ToList());
        }

        // GET: Reciboes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // GET: Reciboes/Create
        public ActionResult Create()
        {
            ViewBag.ContratoId = new SelectList(db.Contrato, "Id", "CodigoDeContrato");
            return View();
        }

        // POST: Reciboes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroDeRecibo,FecheDeRecibo,MontoRecibo,NumeroDeCuotaPagada,ContratoId")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                db.Recibo.Add(recibo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoId = new SelectList(db.Contrato, "Id", "CodigoDeContrato", recibo.ContratoId);
            return View(recibo);
        }

        // GET: Reciboes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoId = new SelectList(db.Contrato, "Id", "CodigoDeContrato", recibo.ContratoId);
            return View(recibo);
        }

        // POST: Reciboes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroDeRecibo,FecheDeRecibo,MontoRecibo,NumeroDeCuotaPagada,ContratoId")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoId = new SelectList(db.Contrato, "Id", "CodigoDeContrato", recibo.ContratoId);
            return View(recibo);
        }

        // GET: Reciboes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // POST: Reciboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recibo recibo = db.Recibo.Find(id);
            db.Recibo.Remove(recibo);
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
