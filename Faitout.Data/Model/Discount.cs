using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class Discount
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Réduction")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; } = 0;

        [Display(Name = "Nature")]
        public DiscountType Type { get; set; } = 0;

        [Display(Name = "Description de la réduction")]
        public string Description { get; set; }

        [Display(Name = "Numéro de commande")]
        public Guid OrderId { get; set; }

        [Display(Name = "Commande")]
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
    public enum DiscountType
    {
        Cash = 0,
        Pourcentage = 1
    }
}
