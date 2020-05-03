using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{

    public class OrderLine
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Id de commande")]
        public Guid OrderId { get; set; }

        [Display(Name = "Commande")]
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        [Display(Name = "Numéro de ligne")]
        public int LineOrder { get; set; }
    }
    public class ProductLine: OrderLine
    {
        [Display(Name = "Id de produit")]
        public Guid ProductId { get; set; }
        [Display(Name = "Produit")]
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Display(Name = "Nom")]
        public int Name { get; set; } = 0;

        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 0;

        [Display(Name = "Sell price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }    
    }


    public class CosmeticLine : OrderLine
    {
        [Display(Name = "Type")]
        public CosmeticLineType Type { get; set; }

        [Display(Name = "Contenu")]
        public string Content { get; set; }
    }

    public enum CosmeticLineType
    {
        Title,
        Text,
        SubTotal,
        Separator
    }
}
