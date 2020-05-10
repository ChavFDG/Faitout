using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Faitout.Data.Model
{

    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage ="Veuillez saisir un nom pour l'ingrédient")]
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

        [Display(Name = "Nom des images")]
        [NotMapped]
        public List<string> Pictures
        {
            get
            {
                List<string> toReturn = new List<string>();
                if(!string.IsNullOrWhiteSpace(PictureName))
                    toReturn.Add(PictureName);
                return toReturn;
            }
            set
            {
                if (value.Count != 0)
                {
                    PictureName = value.First();
                }
            }
        }

        [Display(Name = "Ingrédients enfants")]
        public virtual List<SubIngredient> ChildsIngredients { get; set; } = new List<SubIngredient>();


        [Display(Name = "Recetes")]
        public List<IngredientRecipeQuantity> IngredientRecipeQuantity { get; set; } = new List<IngredientRecipeQuantity>();

        public override string ToString()
        {
            return Name;
        }

        public Ingredient Clone()
        {
            var clone = new Ingredient
            {
                Name = Name,
                ComplementaryInformations = ComplementaryInformations,
                IsOrganic = IsOrganic,
                IsAllergen = IsAllergen
            };
            //foreach (var isio in ChildsIngredients)
            //{
            //   new IngredientSubIngredientOrder(clone, isio.Child) { Order = isio.Order, Percentage = isio.Percentage };                
            //}
            return clone;
        }

        public bool CompareValues(Ingredient ingredient)
        {
            if (ingredient.Name != Name)
                return false;
            if (ingredient.ComplementaryInformations != ComplementaryInformations)
                return false;
            if (ingredient.IsOrganic != IsOrganic)
                return false;
            if (ingredient.IsAllergen != IsAllergen)
                return false;
            foreach (var isio in ChildsIngredients)
            {
                //var child = ingredient.ChildsIngredients.FirstOrDefault(x => x.Child == isio.Child);
                //if (child == null)
                //    return false;
                //else if (!isio.Child.CompareValues(child.Child))
                //    return false;
            }
            return true;
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
