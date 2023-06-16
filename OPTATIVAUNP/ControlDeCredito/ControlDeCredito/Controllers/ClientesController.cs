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
    public class ClientesController : Controller
    {
        private ControlDeCreditoContainer db = new ControlDeCreditoContainer();

        // GET: Clientes
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Municipio).Include(c => c.Sexo).Include(c => c.TipoDeCliente);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.MunicipioId = new SelectList(db.Municipio, "Id", "CodigoDeMunicipio");
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "CodigoDeSexo");
            ViewBag.TipoDeClienteId = new SelectList(db.TipoDeCliente, "Id", "CodigoTipoDeCliente");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoDeCliente,NombresDeCliente,Apellido1DeCliente,Apellido2DeCliente,DireccionDeCliente,TelefonoDeCliente,FechaNacimientoDeCliente,TipoDeClienteId,SexoId,MunicipioId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipioId = new SelectList(db.Municipio, "Id", "CodigoDeMunicipio", cliente.MunicipioId);
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "CodigoDeSexo", cliente.SexoId);
            ViewBag.TipoDeClienteId = new SelectList(db.TipoDeCliente, "Id", "CodigoTipoDeCliente", cliente.TipoDeClienteId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipioId = new SelectList(db.Municipio, "Id", "CodigoDeMunicipio", cliente.MunicipioId);
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "CodigoDeSexo", cliente.SexoId);
            ViewBag.TipoDeClienteId = new SelectList(db.TipoDeCliente, "Id", "CodigoTipoDeCliente", cliente.TipoDeClienteId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoDeCliente,NombresDeCliente,Apellido1DeCliente,Apellido2DeCliente,DireccionDeCliente,TelefonoDeCliente,FechaNacimientoDeCliente,TipoDeClienteId,SexoId,MunicipioId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipioId = new SelectList(db.Municipio, "Id", "CodigoDeMunicipio", cliente.MunicipioId);
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "CodigoDeSexo", cliente.SexoId);
            ViewBag.TipoDeClienteId = new SelectList(db.TipoDeCliente, "Id", "CodigoTipoDeCliente", cliente.TipoDeClienteId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
