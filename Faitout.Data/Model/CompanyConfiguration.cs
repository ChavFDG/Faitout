using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class CompanyConfiguration
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        //Pickup and delivery
        [Display(Name = "Fait du à emporter")]
        public bool EnablePickUp { get; set; } = true;
        [Display(Name = "Fait de la livraison")]
        public bool EnableDelivery { get; set; } = true;

        [Display(Name = "Ticket restaurent")]
        public bool UseRestoTicket { get; set; } = true;
        [Display(Name = "Commission fixe des tickets restaurent")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RestoTicketFixedFees { get; set; } = 0;
        [Display(Name = "Comission variable des tickets restaurent")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RestoTicketPercentageFees { get; set; } = 5;

        [Display(Name = "Carte de crédit")]
        public bool UseCard { get; set; } = true;
        [Display(Name = "Comission fixe des cartes bancaires")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CartFixedFees { get; set; } = 0;
        [Display(Name = "Comission variable des cartes bancaires")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CartPercentageFees { get; set; } = 1.75M;
        [Display(Name = "Avec TVA")]
        public bool UseTax { get; set; } = false;
        [Display(Name = "MicroEntreprise")]
        public bool IsMicro { get; set; } = true; //Ajouter : Non assujettie à la TVA article 293b du CGI , sur la factures
    }
}