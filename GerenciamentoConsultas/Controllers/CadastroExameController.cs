using GerenciamentoConsultas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoConsultas.Controllers
{
    public class CadastroExameController : Controller
    {
        CadastroExameDbContext db;
        public CadastroExameController()
        {
            db = new CadastroExameDbContext();
        }

        // GET: CadastroExame
        public ActionResult Index()
        {
            var cadastroExames = db.CadastroExame.ToList();
            return View(cadastroExames);
        }

        public ActionResult Create()
        {
            ViewBag.TipoExames = db.TipoExames;
            var model = new CadastroExameViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CadastroExameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cadastroExame = new CadastroExame();
                cadastroExame.NomeExame = model.NomeExame;
                cadastroExame.Observacao = model.Observacao;
                cadastroExame.TipoExameid = model.TipoExameId;

                db.CadastroExame.Add(cadastroExame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            ViewBag.TipoExames = db.TipoExames;
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CadastroExame cadastroExame = db.CadastroExame.Find(id);
            if (cadastroExame == null) {
                return HttpNotFound();
            }

            ViewBag.TipoExames = db.TipoExames;
            return View(cadastroExame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "CadastroExameId,NomeExame,Observacao,TipoExameid")] CadastroExame model)
        {
            if (ModelState.IsValid)
            {
                var cadastroExame = db.CadastroExame.Find(model.CadastroExameId);
                if (cadastroExame == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                cadastroExame.NomeExame = model.NomeExame;
                cadastroExame.Observacao = model.Observacao;
                cadastroExame.TipoExameid = model.TipoExameid;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoExames = db.TipoExames;
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CadastroExame cadastroExame = db.CadastroExame.Find(id);

            if (cadastroExame == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoExames = db.TipoExames.Find(cadastroExame.TipoExameid).NmTipoExame;
            return View(cadastroExame);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmar(int id)
        {
            CadastroExame cadastroExame = db.CadastroExame.Find(id);
            db.CadastroExame.Remove(cadastroExame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CadastroExame cadastroExame = db.CadastroExame.Find(id);

            if (cadastroExame == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoExames = db.TipoExames.Find(cadastroExame.TipoExameid).NmTipoExame;
            return View(cadastroExame);

        }
    }
}