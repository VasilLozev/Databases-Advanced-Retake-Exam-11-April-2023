using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [MinLength(9)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(5.00, 1000.00)]
        [Required]
        public decimal Price { get; set; }
        [Required]
        [EnumDataType(typeof(CategoryType))]
        public CategoryType CategoryType { get; set; }

        public int[] Clients { get; set; }
    }
}
