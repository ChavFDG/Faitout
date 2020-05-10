using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class SubIngredient : IIngredient
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir un nom pour l'ingrédient")]
        public string Name { get; set; }

        [Display(Name = "Informations complémentaire, marque ...")]
        public string ComplementaryInformations { get; set; }

        [Display(Name = "Est bio")]
        public bool IsOrganic { get; set; }

        [Display(Name = "Est un allergène")]
        public bool IsAllergen { get; set; }

        [Display(Name = "Id de l'ingrédient parent")]
        public Guid ParentId { get; set; }
        [Display(Name = "Parent")]
        [ForeignKey(nameof(ParentId))]
        public virtual Ingredient Parent { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public string ToLongString()
        {
            var toReturn = IsAllergen ? Name.ToUpper() : Name;
            if (IsOrganic)
                toReturn += " ᴮ";// ᵇ ᴮ 
            if (!string.IsNullOrWhiteSpace(ComplementaryInformations))
                toReturn += " (" + ComplementaryInformations + ")";
            return toReturn;
        }

        [Display(Name = "Order")]
        public int Order { get; set; }

        [Display(Name = "Pourcentage")]
        [Column(TypeName = "decimal(18,3)")]
        public double Percentage { get; set; }
       
    }
}
