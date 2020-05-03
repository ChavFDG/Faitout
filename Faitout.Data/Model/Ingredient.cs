using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Quantité")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Display(Name = "Unité de la quantité")]
        public Unity QuantityUnity { get; set; }
        
        [Display(Name = "Id de recette")]
        public Guid RecipeId { get; set; }
        [Display(Name = "Recette")]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        [Display(Name = "Lien produit, matériel première, ingrédient")]
        public List<ProductIngredientRawMaterial> ProductsIngredientsRawMaterials { get; set; }

    }

    public enum Unity
    {
        kg,
        g,
        l,
        cl,
        cc,
        cs
    }
}
