using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteECommerce.Metier
{
    public class Facture : Commande
    {

        public string MoyenPaiement { get; set; }
        public bool PaiementValid { get; set; }

    }
}