using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MinLength(9)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(5.00, 1000.00)]
        [Required]
        public decimal Price { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }

        public virtual HashSet<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
