using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{

    public class Product : ProductStock
    {

        [Display(Name = "Prix d'achat ou coût de production estimé")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BuyPrice { get; set; }

        [Display(Name = "Stock initial")]
        public int InitialStock { get; set; }

        [Display(Name = "DLC")]
        public DateTime DLC { get; set; }

        [Display(Name = "Date de création")]
        public DateTime Created { get; set; }

        [Display(Name = "Numéro de lot")]
        public string BatchNumber { get; set; }

        [Display(Name = "A un poids net")]
        public bool HasNetWeight { get; set; }

        [Display(Name = "Poids net")]
        public int NetWeight { get; set; }

        [Display(Name = "Id de recette")]
        public Guid RecipeId { get; set; }

        [Display(Name = "Recette")]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe{ get; set; }


        [Display(Name = "Id de la catégorie")]
        public Guid CategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [Display(Name = "Id de consigne")]
        public Guid DepositId { get; set; }
        [Display(Name = "Deposit")]
        [ForeignKey(nameof(DepositId))]
        public virtual Deposit Deposit { get; set; }

        [Display(Name = "Lien produit, matiére première, ingrédient")]
        public List<ProductIngredientRawMaterial> ProductsIngredientsRawMaterials { get; set; }

        [Display(Name = "Tags")]
        public List<RecipeTag> RecipesTags { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
