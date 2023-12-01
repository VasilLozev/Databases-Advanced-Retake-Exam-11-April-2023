using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductsClients
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public CategoryType CategoryType { get; set; }
        public virtual HashSet<ProductClient> Clients { get; set; } = new HashSet<ProductClient>();
    }
}
