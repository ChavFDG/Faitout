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
        public Guid Id { get; set; } = Guid.NewGuid();
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Informations complémentaire, marque ...")]
        public string ComplementaryInformations { get; set; }

        [Display(Name = "Est bio")]
        public bool IsOrganic { get; set; }

        //Dnas le cas de la viande de boeuf obligation d'indiquer l'origine
        [Display(Name = "Origine de la viande")]
        public string Origin { get; set; }

        [Display(Name = "Est un allergène")]
        public bool IsAllergen { get; set; }

        [Display(Name = "Est un AOC")]
        public bool IsAOC { get; set; }

        [Display(Name = "Est un AOP")]
        public bool IsAOP { get; set; }

        //Dans le cas d'un ingrédient ayant des sous ingrédients, image de l'étiquette
        [Display(Name = "Nom de image")]
        public string PictureName { get; set; }

        public Guid? ParentId { get; set; }
        [Display(Name = "Ingrédient parent")]
        [ForeignKey(nameof(ParentId))]
        public virtual Ingredient Parent { get; set; }

        public virtual List<Ingredient> SubIngredients { get; set; } = new List<Ingredient>();

        [Display(Name = "Recetes")]
        public List<IngredientRecipeQuantity> IngredientRecipeQuantity { get; set; } = new List<IngredientRecipeQuantity>();

        public override string ToString()
        {
            return Name;
        }
    }
}
