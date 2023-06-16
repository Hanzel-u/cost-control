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
    public class TipoDeClientesController : Controller
    {
        private ControlDeCreditoContainer db = new ControlDeCreditoContainer();

        // GET: TipoDeClientes
        public ActionResult Index()
        {
            return View(db.TipoDeCliente.ToList());
        }

        // GET: TipoDeClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeCliente tipoDeCliente = db.TipoDeCliente.Find(id);
            if (tipoDeCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeCliente);
        }

        // GET: TipoDeClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoTipoDeCliente,DescripcionTipoDeCliente")] TipoDeCliente tipoDeCliente)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeCliente.Add(tipoDeCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeCliente);
        }

        // GET: TipoDeClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeCliente tipoDeCliente = db.TipoDeCliente.Find(id);
            if (tipoDeCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeCliente);
        }

        // POST: TipoDeClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoTipoDeCliente,DescripcionTipoDeCliente")] TipoDeCliente tipoDeCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeCliente);
        }

        // GET: TipoDeClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeCliente tipoDeCliente = db.TipoDeCliente.Find(id);
            if (tipoDeCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeCliente);
        }

        // POST: TipoDeClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeCliente tipoDeCliente = db.TipoDeCliente.Find(id);
            db.TipoDeCliente.Remove(tipoDeCliente);
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
