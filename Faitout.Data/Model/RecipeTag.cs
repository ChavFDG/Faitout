﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class RecipeTag
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Id de recette")]
        public Guid RecipeId { get; set; }
        [Display(Name = "Recette")]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        [Display(Name = "Id de tag")]
        public Guid TagId { get; set; }
        [Display(Name = "Tag")]
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag{ get; set; }

    }
}
