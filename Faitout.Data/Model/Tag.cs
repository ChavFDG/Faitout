using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faitout.Data.Model
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Veuillez saisir une description")]

        [Display(Name = "Color")]
        public string Color { get; set; } ="#a3c2c2";

        [Display(Name = "Tag de recette")]
        public List<RecipeTag> RecipesTags { get; set; } = new List<RecipeTag>();

        [Display(Name = "Tag de produit")]
        public List<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

        public override string ToString()
        {
            return Name;
        }
    }
}
