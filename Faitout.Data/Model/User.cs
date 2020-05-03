using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Faitout.Data.Model
{
    public class User : IdentityUser
    {
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Prénom")]
        public string Surname { get; set; }

        [Display(Name = "Avoir")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Token { get; set; }  = 0;
        [Display(Name = "Création")]
        public DateTime Created { get; set; }
        [Display(Name = "Désactivé")]
        public bool Disable { get; set; } = false;
        [Display(Name = "Raison de la désactivation")]
        public string DisableReason { get; set; }
        [Display(Name = "Administrateur")]
        public bool IsAdmin { get; set; } = false;
        [Display(Name = "Commandes")]
        public List<Order> Orders { get; set; }

    }
}
