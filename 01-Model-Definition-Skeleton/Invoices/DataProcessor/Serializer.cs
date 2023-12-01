namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientsTheirInvoices
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                    .OrderBy(i => i.IssueDate)
                    .ThenByDescending(i=>i.DueDate)
                    .Select(i => new ExportInvoiceDto
                    {
                        InvoiceNumber = i.Number,
                        InvoiceAmount = i.Amount,
                        DueDate = i.DueDate.ToString("MM/dd/yyyy"),       
                        Currency = i.CurrencyType
                    }).ToArray()
                })
                .OrderByDescending(c=>c.InvoicesCount)
                .ThenBy(c=>c.ClientName)
                .ToArray();

            XmlSerializer xmlSerializer =
             new XmlSerializer(typeof(ExportClientsTheirInvoices[]), new XmlRootAttribute("Clients"));

            StringBuilder stringBuilder = new();
            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            using (StringWriter sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, clients, xsn);
                return stringBuilder.ToString().TrimEnd();
            }
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var products = context.Products
                .Where(p => p.ProductsClients.Any(pc=>pc.Client.Name.Length >= nameLength))
                .OrderByDescending(p => p.ProductsClients.Where(pc => pc.Client != null && pc.Client.Name.Length >= nameLength).Count())
                .ThenBy(p => p.Name).ToArray()
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                    .Where(pc => pc.Client != null && pc.Client.Name.Length >= nameLength).ToArray()
                    .Select(c => new {
                        Name = c.Client.Name,
                        NumberVat = c.Client.NumberVat
                    }).ToArray()
                    .OrderBy(c => c.Name).ToArray()
                })
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);

        }
    }
}