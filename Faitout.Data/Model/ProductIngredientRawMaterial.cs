using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class ProductIngredientRawMaterial
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Id de produit")]
        public Guid? ProductId { get; set; } = null;
        [Display(Name = "Produit")]
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product{ get; set; } = null;

        [Display(Name = "Id d'ingrédient")]
        public Guid? IngredientId { get; set; } = null;
        [Display(Name = "Ingrédient")]
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient { get; set; } = null;

        [Display(Name = "Id de matière première")]
        public Guid? RawMaterialId { get; set; } = null;
        [Display(Name = "Matière première")]
        [ForeignKey(nameof(RawMaterialId))]
        public virtual RawMaterial RawMaterial { get; set; } = null;


        [Display(Name = "Tracabilité des ingrédients")]
        public List<IngredientTraceability> IngredientsTraceability { get; set; }
    }
}
