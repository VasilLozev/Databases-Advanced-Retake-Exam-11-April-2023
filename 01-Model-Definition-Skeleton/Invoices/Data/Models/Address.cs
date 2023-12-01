using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Invoices.Data.Models
{
    [XmlType("address")]
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(10)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string PostCode { get; set; }

        [Required]
        [StringLength(15)]
        [MinLength(5)]
        public string City { get; set; }

        [StringLength(15)]
        [MinLength(5)]
        [Required]
        public string Country { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}