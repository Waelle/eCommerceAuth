using System;
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
             
        [Key]
        public int IdCommande { get; set; }
        
        [ForeignKey("Client")]
        public int? IdClient { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Panier")]
        public int? IdPanier { get; set; }
        public virtual Panier Panier { get; set; }
               

        
    }
}

       