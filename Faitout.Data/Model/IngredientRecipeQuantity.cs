using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class IngredientRecipeQuantity
    {

        public IngredientRecipeQuantity()
        {

        }
        public IngredientRecipeQuantity(Ingredient ingredient, Recipe recipe)
        {
            Ingredient = ingredient;
            IngredientId = ingredient.Id;
            ingredient.IngredientRecipeQuantity.Add(this);
            Recipe = recipe;
            RecipeId = recipe.Id;
            Recipe.IngredientRecipeQuantity.Add(this);
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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

        [Display(Name = "Id d'ingredient")]
        public Guid IngredientId { get; set; }
        [Display(Name = "Ingredient")]
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient{ get; set; }

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
