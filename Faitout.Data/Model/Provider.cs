using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faitout.Data.Model
{
    public class Provider
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Adresse")]
        public string Address { get; set; }
        [Display(Name = "Livraison")]
        public string Delevery { get; set; }
        [Display(Name = "Informations complémentaire")]
        public string ComplementaryInformations { get; set; }


        [Display(Name = "Matiére première")]
        public List<SubRawMaterialIngredient> SubRawMaterialIngredients { get; set; }
    }
}
