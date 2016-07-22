using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class LignePanier
    {
        [Key]
        public int Id { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
        
    }
}
