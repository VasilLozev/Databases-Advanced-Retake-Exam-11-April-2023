using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.Data.Models
{
    [XmlType("client")]
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(10)]
        public string Name { get; set; }
        [Required]
        public string NumberVat { get; set; }
        public virtual HashSet<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public virtual HashSet<Address> Addresses { get; set; } = new HashSet<Address>();
        public virtual HashSet<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}