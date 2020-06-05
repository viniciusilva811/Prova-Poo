using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bll.Pedido;
using Prova_Poo.Model;

namespace Prova_Poo.Controllers
{
    public class SerieController : Controller
    {
        private provapooEntities db = new provapooEntities();

        // GET: Serie
        public ActionResult Index()
        {
            return View(db.serie.ToList());
        }

        // GET: Serie/Details/5
        public ActionResult Details(long? id)
        {

          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            serie serie = db.serie.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serie/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Temporada")] serie serie)
        {
            if (ModelState.IsValid)
            {
                db.serie.Add(serie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serie);
        }

        // GET: Notificacao_Grupo
        public ActionResult IndexEpisodio(int? id)
        {
            if (id == null)
            {
                return View(episodioBll.Instance.Select());
            }

         
            

            return View(episodioBll.Instance.Select(c => c.Id_Serie == id));
        }


        // GET: Serie/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            serie serie = db.serie.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Serie/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Temporada")] ViewModelSerieEpisodio serie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serie);
        }

        // GET: Serie/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            serie serie = db.serie.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Serie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            serie serie = db.serie.Find(id);
            db.serie.Remove(serie);
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



        public JsonResult GetDados(long? idSerie)
        {

            var serie = db.serie.Find(idSerie);

            var episodios = episodioBll.Instance.Select(c => c.Id_Serie == serie.Id).Count();

            var resultado = "";

            if (episodios > 0)
            {

                resultado = "Erro ao apagar Serie, possui registro no banco de dados com a serie selecionada";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {

                resultado = "";

                serieBll.Instance.Remove(serie.Id, "");



                return Json(resultado, JsonRequestBehavior.AllowGet);

            }

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
