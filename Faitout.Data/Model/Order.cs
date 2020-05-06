using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Numéro de devis / facture")]
        public string OrderId { get; set; }

        [Display(Name = "Numéro d'utilisateur")]
        public string UserId { get; set; }

        [Display(Name = "Utilisateur")]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [Display(Name = "Etat")]
        public OrderState Status { get; set; } = OrderState.Created;

        [Display(Name = "Date de création")]
        public DateTime Created { get; set; }

        [Display(Name = "Mode de commande")]
        public OrderMode OrderMode { get; set; }

        [Display(Name = "Heure de livraison / récupération")]
        public DateTime OrderModeDayAndTime { get; set; }

        [Display(Name = "Entré de commande")]
        public List<Order> Orders { get; set; } = new List<Order>();

        [Display(Name = "Paiments")]
        public List<Payement> Payments { get; set; } = new List<Payement>();

        [Display(Name = "Réductions")]
        public List<Discount> Discounts { get; set; } = new List<Discount>();
    }

    public enum OrderState
    {
        Created = 0,
        Ordered = 1,
        Delivered = 2,
        Payed = 3,
        Refound = 4,
        Canceled = 99
    }

    public enum OrderMode
    {
        OnSite = 0,
        Delivery = 1,
        PickUp = 2
    }
}
