using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faitout.Data.Model
{    public abstract class BaseRawMaterial
    {
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Prix au poids")]
        decimal WeightPrice { get; set; }
        [Display(Name = "Est bio")]
        bool IsOrganic { get; set; }
        [Display(Name = "Est commerce équitable")]
        bool IsFairTrade { get; set; }
        [Display(Name = "Est d'origine française")]
        bool IsFrance { get; set; }
        [Display(Name = "Est d'origine de l'UE")]
        bool IsEU { get; set; }
        [Display(Name = "Est d'origine de l'UE")]
        bool IsNonEU { get; set; }
        [Display(Name = "Est local")]
        bool IsLocal { get; set; }
        [Display(Name = "Est un allergène")]
        bool IsAllergen { get; set; }
        [Display(Name = "Est un AOC")]
        bool IsAOC { get; set; }
        [Display(Name = "Est un AOP")]
        bool IsAOP { get; set; }
    }
}
