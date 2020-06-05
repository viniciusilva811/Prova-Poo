using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prova_Poo.Model;

namespace Prova_Poo.Controllers
{
    public class EpisodioController : Controller
    {
        private provapooEntities db = new provapooEntities();

        // GET: Episodio
        public ActionResult Index()
        {
            var episodio = db.episodio.Include(e => e.serie);
            return View(episodio.ToList());
        }

        // GET: Episodio/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            episodio episodio = db.episodio.Find(id);
            if (episodio == null)
            {
                return HttpNotFound();
            }
            return View(episodio);
        }

        // GET: Episodio/Create
        public ActionResult Create()
        {

            ViewBag.Id_Serie = new SelectList(db.serie, "Id", "Nome");


            return View();
        }

        // POST: Episodio/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Serie,Nome,NumeroEpisodio,Avaliacao")] episodio episodio)
        {
            if (ModelState.IsValid)
            {
                db.episodio.Add(episodio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Serie = new SelectList(db.serie, "Id", "Nome", episodio.Id_Serie);
            return View(episodio);
        }

        // GET: Episodio/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            episodio episodio = db.episodio.Find(id);
            if (episodio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Serie = new SelectList(db.serie, "Id", "Nome", episodio.Id_Serie);
            return View(episodio);
        }

        // POST: Episodio/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Serie,Nome,NumeroEpisodio,Avaliacao")] episodio episodio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(episodio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Serie = new SelectList(db.serie, "Id", "Nome", episodio.Id_Serie);
            return View(episodio);
        }

        // GET: Episodio/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            episodio episodio = db.episodio.Find(id);
            if (episodio == null)
            {
                return HttpNotFound();
            }
            return View(episodio);
        }

        // POST: Episodio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            episodio episodio = db.episodio.Find(id);
            db.episodio.Remove(episodio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private static serie InstanciarSerie(ViewModelSerieEpisodio vm)
        {


            var serieOjeto = new serie()
            {
                Nome = vm.NomeSerie,
                Temporada = vm.Temporada
            };



            var episodio = new List<episodio>
            {

                new episodio
                {


               Nome = vm.Nome,
               NumeroEpisodio = vm.NumeroEpisodio,
               Avaliacao = vm.Avaliacao,
               serie = serieOjeto

                }

            };



            return serieOjeto;
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
