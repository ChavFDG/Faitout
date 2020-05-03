using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Etapes")]
        public string Steps { get; set; }
        [Display(Name = "Pour n personne(s)")]
        public int Quantity { get; set; }
        [Display(Name = "Ingrédients")]
        public List<Ingredient> Ingredients { get; set; }
        [Display(Name = "Tag de recette")]
        public List<RecipeTag> RecipesTags { get; set; }
        [Display(Name = "Chemin de l'image")]
        public string PicturePath { get; set; }
    }
}
