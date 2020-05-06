using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class StockMove
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Date et heure du mouvement")]
        public DateTime Date { get; set; }

        [Display(Name = "Quantité")]
        public int Quantity { get; set; }

        [Display(Name = "Id du produit")]
        public Guid ProductStockId { get; set; }
        [Display(Name = "Produit")]
        [ForeignKey(nameof(ProductStockId))]
        public virtual ProductStock ProductStock { get; set; }

        [Display(Name = "Id du fournisseur")]
        public Guid ProviderId { get; set; }
        [Display(Name = "Fournisseur")]
        [ForeignKey(nameof(ProviderId))]
        public virtual Provider Provider { get; set; }
    }

    public enum StockMoveType
    {
        [Display(Name = "Casse")]
        Broken,
        [Display(Name = "A été jeté")]
        Losed,
        [Display(Name = "Consomation personnel")]
        PersonalConsuming,
        [Display(Name = "Est en off")]
        Off,
        [Display(Name = "Acheté")]
        Buy,
        [Display(Name = "Fabriqué")]
        Made,
        [Display(Name = "Vendu")]
        Sell,
        [Display(Name = "Remboursé")]
        Refound
    }

}
