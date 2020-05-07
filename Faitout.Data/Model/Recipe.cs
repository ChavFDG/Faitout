using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Faitout.Data.Model
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Name { get; set; }

        [Display(Name = "Four ?")]
        public bool UseOven { get; set; } = true;

        [Display(Name = "Température du four")]
        public int OvenTemepature { get; set; } = 180;

        [Display(Name = "Humidité du four")]
        public int OvenHumidity { get; set; } = 0;

        [Display(Name = "Temp de cuisson")]
        public TimeSpan OvenTime { get; set; } = new TimeSpan(1, 30, 0);

        [Display(Name = "Etapes")]
        public string Steps { get; set; }
        [Display(Name = "Pour n personne(s)")]
        public int Quantity { get; set; } = 20;

        [Display(Name = "Tag de recette")]
        public List<RecipeTag> RecipesTags { get; set; } = new List<RecipeTag>();

        public string ConcatenatedPicturesNames { get; set; }

        [Display(Name = "Nom de l'image")]
        [NotMapped]
        public List<string> Pictures
        {
            get
            {
                List<string> toReturn = ConcatenatedPicturesNames.Split(';').ToList();
                toReturn.RemoveAll(x => String.IsNullOrWhiteSpace(x));
                return toReturn;
            }
            set
            {
                ConcatenatedPicturesNames = "";
                if (value.Count != 0)
                {
                    foreach (var picture in value)
                    {
                        ConcatenatedPicturesNames += picture + ";";
                    }
                    ConcatenatedPicturesNames.Remove(ConcatenatedPicturesNames.Count() - 1);
                }
            }
        }

        [Display(Name = "Ingredients")]
        public List<IngredientRecipeQuantity> IngredientRecipeQuantity { get; set; } = new List<IngredientRecipeQuantity>();


        public override string ToString()
        {
            return Name;
        }
    }
}
