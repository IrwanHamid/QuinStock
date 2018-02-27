using System.ComponentModel.DataAnnotations;

namespace QuinStock.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
