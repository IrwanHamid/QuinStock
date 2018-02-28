using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuinStock.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        public bool IsListedInStore { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
