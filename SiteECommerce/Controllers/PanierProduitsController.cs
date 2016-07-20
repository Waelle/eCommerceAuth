using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteECommerce.DAL;
using SiteECommerce.Metier;
using System.Data.Entity.Core;
using System.Drawing;

namespace SiteECommerce.Controllers
{
    public class PanierProduitsController : Controller
    {
        private SiteECommerceDbContext db = new SiteECommerceDbContext();

        // GET: PanierProduits
        public ActionResult Index()
        {
            var produits = db.Produits.Include(p => p.Categorie).Include(p => p.Marque);
            return View(produits.ToList());
        }

        // GET: PanierProduits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: PanierProduits/Create
        public ActionResult Create()
        {
            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "NomCategorie");
            ViewBag.IdMarque = new SelectList(db.Marques, "IdMarque", "NomMarque");
            return View();
        }

        // POST: PanierProduits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduit,NomProduit,ImgProduit,PrixProduit,DescriptionProduit,Quantite,IdMarque,IdCategorie")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "NomCategorie", produit.IdCategorie);
            ViewBag.IdMarque = new SelectList(db.Marques, "IdMarque", "NomMarque", produit.IdMarque);
            return View(produit);
        }

        public ActionResult AjouterProduit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = (Commande)Session["panier"];
            if (commande == null)
            {
                commande = new Commande();
                Session["panier"] = commande;
            }

            commande.AjouterACommande(db.Produits.Find(id));
            //db.Commandes.Add(commande);
            //    db.SaveChanges();
            
                return RedirectToAction("Index");
           
        }
         
        //public ActionResult DisplayId(int? id)
        //{
        //    ViewBag.Id = id;
        //    return View();
        //}


        // GET: PanierProduits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "NomCategorie", produit.IdCategorie);
            ViewBag.IdMarque = new SelectList(db.Marques, "IdMarque", "NomMarque", produit.IdMarque);
            return View(produit);
        }

        // POST: PanierProduits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduit,NomProduit,ImgProduit,PrixProduit,DescriptionProduit,Quantite,IdMarque,IdCategorie")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategorie = new SelectList(db.Categories, "IdCategorie", "NomCategorie", produit.IdCategorie);
            ViewBag.IdMarque = new SelectList(db.Marques, "IdMarque", "NomMarque", produit.IdMarque);
            return View(produit);
        }

        // GET: PanierProduits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: PanierProduits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produit produit = db.Produits.Find(id);
            db.Produits.Remove(produit);
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
