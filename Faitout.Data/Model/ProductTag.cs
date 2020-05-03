using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class ProductTag
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Id de product")]
        public Guid ProductId { get; set; }
        [Display(Name = "Produit")]
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Display(Name = "Id de tag")]
        public Guid TagId { get; set; }
        [Display(Name = "Tag")]
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag{ get; set; }

    }
}
