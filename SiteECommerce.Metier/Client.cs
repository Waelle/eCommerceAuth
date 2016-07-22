using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string AdresseLivraison { get; set; }

        [Required]
        public string AdresseFacturation { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }


    }
}
