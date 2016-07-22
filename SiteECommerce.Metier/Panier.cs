using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Panier
    {
        public Panier()
        {
            LignePaniers = new List<LignePanier>();
        }

        [Key]
        public int IdPanier { get; set; }
        public int QuantitePanier { get; set; }
        public decimal PrixTotalPanier { get; set; }

        public virtual ICollection<LignePanier> LignePaniers { get; set; }

        public void AjouterAuPanier(Produit produit, int quantite)
        {
            LignePanier lignePanier = LignePaniers.FirstOrDefault(lp => lp.Produit.IdProduit == produit.IdProduit);
            if (lignePanier != null)
            {
                lignePanier.Quantite += quantite;
            }
            else // donc lignePanier == null
            {
                LignePaniers.Add(new LignePanier { Produit = produit, Quantite = quantite });
            }

            produit.Quantite -= quantite;
            PrixTotalPanier += quantite * produit.PrixProduit;
        }


    }
    
}
