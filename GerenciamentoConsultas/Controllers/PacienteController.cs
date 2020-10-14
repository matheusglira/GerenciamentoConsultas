using GerenciamentoConsultas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoConsultas.Controllers
{
    public class PacienteController : Controller
    {
        PacienteDbContext db;

        public PacienteController()
        {
            db = new PacienteDbContext();
        }
        // GET: Paciente
        public ActionResult ListPacientes()
        {
            var pacientes = db.Pacientes.ToList();
            return View(pacientes);
        }

        public ActionResult Create(PacienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paciente = new Paciente();

                paciente.NomePaciente = model.NomePaciente;
                paciente.Cpf = model.Cpf;
                paciente.DataNascimento = model.DataNascimento;
                paciente.Sexo = model.Sexo;
                paciente.Telefone = model.Telefone;
                paciente.Email = model.Email;

                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return Redirect("ListPacientes");
            }

            return View(model);
        }

        public ActionResult EditPaciente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Paciente paciente = db.Pacientes.Find(id);

            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPaciente([Bind(Include = "PacienteId,NomePaciente,Cpf,DataNascimento,Sexo,Telefone,Email")] Paciente model)
        {
            if (ModelState.IsValid)
            {
                var paciente = db.Pacientes.Find(model.PacienteId);

                if (paciente == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                paciente.NomePaciente = model.NomePaciente;
                paciente.Cpf = model.Cpf;
                paciente.DataNascimento = model.DataNascimento;
                paciente.Sexo = model.Sexo;
                paciente.Telefone = model.Telefone;
                paciente.Email = model.Email;

                db.SaveChanges();
                return RedirectToAction("ListPacientes");
            }

            return View(model);
        }

        public ActionResult DeletePaciente(int? id) {

            if (id == null) { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Paciente paciente = db.Pacientes.Find(id);

            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("DeletePaciente")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmar(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("ListPacientes");
        }
    }
}