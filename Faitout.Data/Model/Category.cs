using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faitout.Data.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Produits")]
        public List<Product> Products{ get; set; }

        public Guid EatInVatId { get; set; }
        [Display(Name = "TVA sur place")]
        [Required(ErrorMessage = "Veuillez choisir une TVA pour le service sur place")]
        [ForeignKey(nameof(EatInVatId))]
        public virtual VAT EatInVat { get; set; }

        public Guid TakeAwayVatId { get; set; }
        [Display(Name = "TVA à emporter")]
        [Required(ErrorMessage = "Veuillez choisir une TVA pour le service à emporter")]
        [ForeignKey(nameof(TakeAwayVatId))]
        public virtual VAT TakeAwayVat { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
