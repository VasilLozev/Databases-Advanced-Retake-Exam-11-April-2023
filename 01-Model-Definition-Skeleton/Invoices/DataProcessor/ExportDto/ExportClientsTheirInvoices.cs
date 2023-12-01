using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientsTheirInvoices
    {
        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }
        public string ClientName { get; set; }
        public string VatNumber { get; set; }
        [XmlArray("Invoices")]
        public ExportInvoiceDto[] Invoices { get; set; }
    }
}
