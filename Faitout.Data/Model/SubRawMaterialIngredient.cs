using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faitout.Data.Model
{
    public class SubRawMaterialIngredient : BaseRawMaterial
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Ordre")]
        public int Ordre { get; set; }
        [Display(Name = "Quantité en %")]//Si connu sinon 0
        public int Quantity { get; set; } = 0;

        [Display(Name = "Id de matière première")]
        public Guid RawMaterialId { get; set; }
        [Display(Name = "Matière première")]
        [ForeignKey(nameof(RawMaterialId))]
        public virtual RawMaterial RawMaterial { get; set; }
    }
}
