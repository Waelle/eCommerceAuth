using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Marque
    {
        [Key]
        public int IdMarque { get; set; }
        public string NomMarque { get; set; }


        public virtual ICollection<Produit> Produits { get; set; }
    }

}


