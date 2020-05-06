using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Faitout.Data.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Produits")]
        public List<Product> Products { get; set; } = new List<Product>();

        [Display(Name = "Visible par les clients")]
        public bool ClientVisible { get; set; }

        [Display(Name = "Visible sur la caisse")]
        public bool CashRegisterVisible { get; set; }

        public Guid EatInVatId { get; set; }
        [Display(Name = "TVA sur place")]
        [ForeignKey(nameof(EatInVatId))]
        public virtual VAT EatInVat { get; set; }

        [NotMapped]
        public string EatInVatIdString
        {
            get
            {
                return EatInVatId.ToString();
            }
            set
            {
                EatInVatId = Guid.Parse(value);
            }
        }
        public Guid TakeAwayVatId { get; set; }
        [Display(Name = "TVA à emporter")]
        [ForeignKey(nameof(TakeAwayVatId))]
        public virtual VAT TakeAwayVat { get; set; }

        [NotMapped]
        public string TakeAwayVatIdString
        {
            get
            {
                return TakeAwayVatId.ToString();
            }
            set
            {
                TakeAwayVatId = Guid.Parse(value);
            }
        }

        public int Level { get; set; } = 0;
        public int Order { get; set; } = 0;
        public Guid? ParentId { get; set; }
        [Display(Name = "Categorie parent")]
        [ForeignKey(nameof(ParentId))]
        public virtual Category Parent { get; set; }

        public virtual List<Category> Childs { get; set; } = new List<Category>();


        public override string ToString()
        {
            return Name.ToString();
        }

        /// <summary>
        /// Get back the number of level of a lsit of categories
        /// </summary>
        /// <param name="categories">List of categories</param>
        /// <returns>Number of level inside</returns>
        public static int CountLevels(List<Category> categories)
        {
            List<int> levels = new List<int>();
            foreach (var category in categories)
            {
                if (!levels.Contains(category.Level))
                    levels.Add(category.Level);
            }
            return levels.Distinct().ToList().Count();
        }

    }
}
