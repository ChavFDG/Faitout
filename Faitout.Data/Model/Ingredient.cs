using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        [Display(Name = "Est un allergène")]
        public bool IsAllergen { get; set; }

        //Dans le cas d'un ingrédient ayant des sous ingrédients, image de l'étiquette
        [Display(Name = "Nom de image")]
        public string PictureName { get; set; }

        [Display(Name = "Ingrédients enfants")]
        public virtual List<IngredientSubIngredientOrder> ChildsIngredients { get; set; } = new List<IngredientSubIngredientOrder>();

        [Display(Name = "Ingrédients parents")]
        public virtual List<IngredientSubIngredientOrder> ParentsIngredients { get; set; } = new List<IngredientSubIngredientOrder>();

        [Display(Name = "Recetes")]
        public List<IngredientRecipeQuantity> IngredientRecipeQuantity { get; set; } = new List<IngredientRecipeQuantity>();

        public override string ToString()
        {
            return Name;
        }

        public Ingredient Clone()
        {
            var clone = new Ingredient();
            clone.Name = Name;
            clone.ComplementaryInformations = ComplementaryInformations;
            clone.IsOrganic = IsOrganic;
            clone.IsAllergen = IsAllergen;
            return clone;
        }

        public string ToLongString()
        {
            var toReturn = IsAllergen?Name.ToUpper():Name;
            if (IsOrganic)
                toReturn += " ᴮ";// ᵇ ᴮ 
            if (!string.IsNullOrWhiteSpace(ComplementaryInformations))
                toReturn += " (" + ComplementaryInformations +")";
            return toReturn;
        }
    }
}
