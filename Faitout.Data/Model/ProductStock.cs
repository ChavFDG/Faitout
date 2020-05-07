using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Faitout.Data.Model
{
    public class ProductStock
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Nom")]
        [Required(ErrorMessage ="Veuillez saisir un nom")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Description { get; set; }

        [Display(Name = "Stock courent")]
        public int CurrentStock { get; set; }

        [Display(Name = "Prix")]
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Prix")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OnlinePrice { get; set; }

        public string ConcatenatedPicturesNames { get; set; }

        [Display(Name = "Nom des images")]
        [NotMapped]
        public List<string> Pictures
        {
            get
            {
                List<string> toReturn = ConcatenatedPicturesNames.Split(';').ToList();
                toReturn.RemoveAll(x => String.IsNullOrWhiteSpace(x));
                return toReturn;
            }
            set
            {
                ConcatenatedPicturesNames = "";
                if (value.Count != 0)
                {
                    foreach (var picture in value)
                    {
                        ConcatenatedPicturesNames += picture + ";";
                    }
                    ConcatenatedPicturesNames.Remove(ConcatenatedPicturesNames.Count() - 1);
                }
            }
        }

        [Display(Name = "Archivé")]
        public bool IsArchive { get; set; }

        [Display(Name = "Activé")]
        public bool Enable { get; set; }

        [Display(Name = "Activé en ligne")]
        public bool EnableOnLine { get; set; }


        [Display(Name = "Tracabilité")]
        public List<IngredientTraceability> Traceability { get; set; } = new List<IngredientTraceability>();

    }
}
