using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class ProductStock
    {
        [Key]
        public Guid Id { get; set; }

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

        [Display(Name = "Nom des images")]
        public string PicturesName { get; set; }

        [Display(Name = "Archivé")]
        public bool IsArchive { get; set; }

        [Display(Name = "Activé")]
        public bool Enable { get; set; }

        [Display(Name = "Activé en ligne")]
        public bool EnableOnLine { get; set; }

    }
}
