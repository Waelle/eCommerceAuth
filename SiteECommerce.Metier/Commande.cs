﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Commande
    {
        public Commande()
        {
            Produits = new List<Produit>();
        }
        [Key]
        public int Id { get; set; }
        public int Quantite { get; set; }
        public decimal PrixTotal { get; set; }

        [ForeignKey("Client")]
        public int? IdClient { get; set; }
        public virtual Client Client { get; set; }


        public virtual ICollection<Produit> Produits { get; set; }

        public void AjouterACommande(Produit produit)
        {
            Produits.Add(produit);
            //Produits.Add(produit);
            /// calcule du prix total 
            Quantite++;
            produit.Quantite--;
            PrixTotal = Quantite * produit.PrixProduit;
           

        }
    }
}

       