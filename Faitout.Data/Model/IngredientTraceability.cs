using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class IngredientTraceability
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Information complémentaire")]
        public string ComplementaryInformation { get; set; }
        [Display(Name = "Chemin de l'image")]
        public string PicturePath { get; set; }

        [Display(Name = "Id de lien produit, matériel première, ingrédient")]
        public Guid ProductIngredientRawMaterialId { get; set; }
        [Display(Name = "Lien produit, matériel première, ingrédient")]
        [ForeignKey(nameof(ProductIngredientRawMaterialId))]
        public virtual ProductIngredientRawMaterial ProductIngredientRawMaterial { get; set; }
    }
}
