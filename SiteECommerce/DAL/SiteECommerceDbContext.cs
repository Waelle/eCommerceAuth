using SiteECommerce.Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteECommerce.DAL
{
    public class SiteECommerceDbContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }

    }
}