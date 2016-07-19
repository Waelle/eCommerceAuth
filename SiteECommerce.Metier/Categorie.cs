using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        public string NomCategorie { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }

    }
}
