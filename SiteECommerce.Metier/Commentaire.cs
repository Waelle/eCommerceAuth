using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Commentaire
    {
        public int Id { get; private set; }
        public int Note { get; set; }
        public string Texte { get; set; }

        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Produit")]
        public int IdProduit { get; set; }
        public virtual Produit Produit { get; set; }
    }
}
