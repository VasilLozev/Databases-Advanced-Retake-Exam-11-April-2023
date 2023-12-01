using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models
{
    public class ProductClient
    {
        [Key]
        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Key]
        [ForeignKey(nameof(Client))]
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}