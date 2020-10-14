using GerenciamentoConsultas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoConsultas.Controllers
{
    public class TipoExameController : Controller
    {
        TipoExameDbContext db;

        public TipoExameController() {
            db = new TipoExameDbContext();
        }
        // GET: TipoExame
        public ActionResult List()
        {
            var tipoExame = db.TipoExames.ToList();
            return View(tipoExame);
        }

        public ActionResult Create(TipoExameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tipoExame = new TipoExame();
                tipoExame.NmTipoExame = model.NmTipoExame;
                tipoExame.Descricao = model.Descricao;

                db.TipoExames.Add(tipoExame);
                db.SaveChanges();
                return Redirect("List");
            }

            return View(model);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoExame tipoExame = db.TipoExames.Find(id);

            if (tipoExame == null) {
                return HttpNotFound();
            }

            return View(tipoExame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "TipoExameId,Descricao,NmTipoExame")] TipoExame model)
        {
            if (ModelState.IsValid)
            {
                var tipoExame = db.TipoExames.Find(model.TipoExameId);

                if (tipoExame == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                tipoExame.Descricao = model.Descricao;
                tipoExame.NmTipoExame = model.NmTipoExame;

                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoExame tipoExame = db.TipoExames.Find(id);

            if (tipoExame == null) {
                return HttpNotFound();
            }

            return View(tipoExame);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmar(int id)
        {
            TipoExame tipoExame = db.TipoExames.Find(id);
            db.TipoExames.Remove(tipoExame);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoExame tipoExame = db.TipoExames.Find(id);

            if (tipoExame == null)  {
                return HttpNotFound();
            }

            return View(tipoExame);
        }
    }
}