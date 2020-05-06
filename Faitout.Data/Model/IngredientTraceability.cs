using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class IngredientTraceability
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Id du produit")]
        public Guid ProductStockId { get; set; }
        [Display(Name = "Produit")]
        [ForeignKey(nameof(ProductStockId))]
        public virtual ProductStock ProductStock { get; set; }

        [NotMapped]
        public Product Product
        {
            get { return ProductStock as Product; }
            set { ProductStock = value; }
        }

        [Display(Name = "Information complémentaire")]
        public string ComplementaryInformation { get; set; }

        [Display(Name = "Image")]
        public string Picture { get; set; }
    }
}
