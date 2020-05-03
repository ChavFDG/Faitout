using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faitout.Data.Model
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Veuillez saisir une description")]
        public string Description { get; set; }
        [Display(Name = "Icone")]
        public string Icon { get; set; } // sous une forme vectoriel, ou voir avec Come le mieux à faire

        [Display(Name = "Tag de recette")]
        public List<RecipeTag> RecipesTags { get; set; }

        [Display(Name = "Tag de produit")]
        public List<ProductTag> ProductTags { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
