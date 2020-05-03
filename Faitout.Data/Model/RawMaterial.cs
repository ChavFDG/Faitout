using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faitout.Data.Model
{
    public class RawMaterial : BaseRawMaterial
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Chemin de l'image")] //Image de l'étiquette pour les sous ingédients ...
        public string PicturePath { get; set; }

        [Display(Name = "Id de fournisseur")]
        public Guid ProviderId { get; set; }
        [Display(Name = "Produit")]
        [ForeignKey(nameof(ProviderId))]
        public virtual Provider Provider{ get; set; }


        [Display(Name = "Sous ingrédients")]
        public List<SubRawMaterialIngredient> SubRawMaterialIngredients { get; set; }

        [Display(Name = "Lien produit, matériel première, ingrédient")]
        public List<ProductIngredientRawMaterial> ProductsIngredientsRawMaterials { get; set; }
    }
}
