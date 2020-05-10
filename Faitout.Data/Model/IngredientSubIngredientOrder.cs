using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class IngredientSubIngredientOrder
    {
        public IngredientSubIngredientOrder()
        {

        }
        public IngredientSubIngredientOrder(Ingredient parent, Ingredient child)
        {
            Order = parent.ChildsIngredients.Count + 1;
            ParentId = parent.Id;
            Parent = parent;
            Parent.ChildsIngredients.Add(this);
            ChildId = child.Id;
            Child = child;
            Child.ParentsIngredients.Add(this);
            
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Order")]
        public int Order{ get; set; }

        [Display(Name = "Pourcentage")]
        public double Percentage { get; set; }

        public Guid? ParentId { get; set; }
        [Display(Name = "Ingredient parent")]
        [ForeignKey(nameof(ParentId))]
        public virtual Ingredient Parent { get; set; }

        public Guid? ChildId { get; set; }
        [Display(Name = "Ingredient enfant")]
        [ForeignKey(nameof(ChildId))]
        public virtual Ingredient Child { get; set; }

    }
}
