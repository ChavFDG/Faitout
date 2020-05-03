using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faitout.Data.Model
{
    public class VAT
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "%")]
        [Column(TypeName = "decimal(18,3)")]
        [Required]
        public decimal Tax { get; set; }

        [Display(Name = "Catégories à emporter")]
        public List<Category> TakeAwayCategories { get; set; }

        [Display(Name = "Catégories sur place")]
        public List<Category> EatInCategories { get; set; }

        public override string ToString()
        {
            return (Tax).ToString("##0.##%") ;
        }

    }
}
