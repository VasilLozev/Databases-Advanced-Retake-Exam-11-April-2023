using Invoices.Data.Models.Enums;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class ExportInvoiceDto
    {
        [XmlElement]
        public int InvoiceNumber { get; set; }
        [XmlElement]
        public decimal InvoiceAmount { get; set; }
        [XmlElement]
        public string DueDate { get; set; }
        [XmlElement]
        public CurrencyType Currency { get; set; }

    }
}
