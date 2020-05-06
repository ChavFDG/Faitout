using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class Payement
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Date et heure du payement")]
        public DateTime Date { get; set; }

        [Display(Name = "Valeur")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Type de paiement")]
        public PayementType Type { get; set; }

        [Display(Name = "Numéro de commande")]
        public Guid OrderId { get; set; }

        [Display(Name = "Commande")]
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order{ get; set; }
    }

    public enum PayementType
    {
        [Display(Name = "Liquide")]
        Cash,
        [Display(Name = "Monnaie local")]
        LocalCash,
        [Display(Name = "Virevement")]
        Transfer,
        [Display(Name = "Chéque")]
        Check,
        [Display(Name = "Carte")]
        Card,
        [Display(Name = "Tiquet resto")]
        RestaurentTicket,
        [Display(Name = "Avoir")]
        Credit
    }
}
