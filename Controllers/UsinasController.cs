using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoEngieTestePratico.Data;
using ProjetoEngieTestePratico.Models;
using ProjetoEngieTestePratico.Models.ViewModels;

namespace ProjetoEngieTestePratico.Controllers
{
    public class UsinasController : Controller
    {
        private Context db = new Context();

        // GET: Usinas
        public ActionResult Index()
        {

            var usina = db.Usina.ToList();
            var fornecedor = db.Fornecedor.ToList();

            List<Usina> UsinaCompleta = new List<Usina>();

            foreach (var item in usina)
            {
                foreach (var item2 in fornecedor)
                {
                    if (item.IdFornecedor == item2.Id)
                    {
                        UsinaCompleta.Add(new Usina { Id = item.Id, Ativo = item.Ativo, Uc = item.Uc, IdFornecedor = item.IdFornecedor, Fornecedor = new Fornecedor { Id = item2.Id, Nome = item2.Nome }});
                    }
                }
            }
            return View(UsinaCompleta);
        }


        // GET: Usinas/Create
        public ActionResult Create()
        {
            Fornecedor fornecedor = new Fornecedor();
            var fornecedores = fornecedor.PegarTodos();
            Usina usinas = new Usina();
            var viewModel = new ViewModel { Fornecedor = fornecedores, Usina = usinas };
            viewModel.Usina.Ativo = true;
            return PartialView(viewModel);
        }

        // POST: Usinas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Uc,IdFornecedor,Ativo")] Usina usina)
        {
            if (ModelState.IsValid)
            {
                db.Usina.Add(usina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(usina);
        }

        // GET: Usinas/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usina usina = db.Usina.Find(id);
            var idusina = usina.IdFornecedor;
            Fornecedor fornecedor = db.Fornecedor.Find(idusina);
            usina.Fornecedor = fornecedor;

            Fornecedor forncedor1 = new Fornecedor();
            var listFornecedor = forncedor1.PegarTodos().ToList();

            var viewModel = new ViewModel { Usina = usina, Fornecedor = listFornecedor };

            if (usina == null)
            {
                return HttpNotFound();
            }
            return PartialView(viewModel);
        }

        // POST: Usinas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Uc,IdFornecedor,Ativo")] Usina usina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(usina);
        }

        // GET: Usinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usina usina = db.Usina.Find(id);
            if (usina == null)
            {
                return HttpNotFound();
            }
            return PartialView(usina);
        }

        // POST: Usinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usina usina = db.Usina.Find(id);
            db.Usina.Remove(usina);
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
