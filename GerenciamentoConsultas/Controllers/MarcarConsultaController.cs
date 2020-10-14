using GerenciamentoConsultas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoConsultas.Controllers
{
    public class MarcarConsultaController : Controller
    {
        MarcarExameDbContext db;

        public MarcarConsultaController()
        {
            db = new MarcarExameDbContext();
        }

        // GET: MarcarConsulta
        public ActionResult Index()
        {
            var marcarExame = db.MarcarConsultas.ToList();
            return View(marcarExame);
        }

        public ActionResult Create()
        {
            ViewBag.Pacientes = db.Pacientes;
            ViewBag.TipoExames = db.TipoExames;
            var model = new MarcarConsultaViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcarConsultaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var marcarConsulta = new MarcarConsulta();
                marcarConsulta.DataConsulta = model.DataConsulta;
                marcarConsulta.PacienteId = model.PacienteId;
                marcarConsulta.TipoExameId = model.TipoExameId;

                db.MarcarConsultas.Add(marcarConsulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pacientes = db.Pacientes;
            ViewBag.TipoExames = db.TipoExames;
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MarcarConsulta marcarConsulta = db.MarcarConsultas.Find(id);

            if (marcarConsulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pacientes = db.Pacientes.Find(marcarConsulta.PacienteId).NomePaciente;
            ViewBag.TipoExames = db.TipoExames.Find(marcarConsulta.TipoExameId).NmTipoExame;

            return View(marcarConsulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Protocolo,PacienteId,TipoExameId,DataConsulta")] MarcarConsulta model)
        {
            if (ModelState.IsValid)
            {
                var marcarConsulta = db.MarcarConsultas.Find(model.Protocolo);
                if (marcarConsulta == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                marcarConsulta.PacienteId = model.PacienteId;
                marcarConsulta.TipoExameId = model.TipoExameId;
                marcarConsulta.DataConsulta = model.DataConsulta;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pacientes = db.Pacientes;
            ViewBag.TipoExames = db.TipoExames;
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MarcarConsulta marcarConsulta = db.MarcarConsultas.Find(id);

            if (marcarConsulta == null)
            {
                return HttpNotFound();
            }

            ViewBag.Paciente = db.Pacientes.Find(marcarConsulta.PacienteId).NomePaciente;
            ViewBag.TipoExame = db.TipoExames.Find(marcarConsulta.TipoExameId).NmTipoExame;

            return View(marcarConsulta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmar(int id)
        {
            MarcarConsulta marcarConsulta = db.MarcarConsultas.Find(id);
            db.MarcarConsultas.Remove(marcarConsulta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}