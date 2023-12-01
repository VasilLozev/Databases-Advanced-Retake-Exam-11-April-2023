﻿using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(10)]
        public string StreetName { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(5)]
        public string City { get; set; }
        [MaxLength(15)]
        [MinLength(5)]
        [Required]
        public string Country { get; set; }
        public Client Client { get; set; }
    }
}
