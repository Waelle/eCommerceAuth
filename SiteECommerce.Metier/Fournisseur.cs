using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Fournisseur
    {
        [Key]
        public int Idfournisseur { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
