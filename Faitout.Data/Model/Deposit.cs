using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    //Attention un deposit ne pourra jamais être modifié, sans quoi ça donneré des erreurs de facturation par la suite
    //Les emballages consignés ou récupérables sont soumis à TVA lorsqu'ils ne sont pas restitués. Le versement de la consignation et son remboursement ne sont pas soumis à TVA. 
    //La non-restitution de l'emballage consigné est une vente soumise à TVA.
    public class Deposit : ProductStock
    {

        [Display(Name = "Produits")]
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
