﻿namespace ST10187895_PROG6212_PART1.Services
{
    using QuestPDF.Fluent;
    using QuestPDF.Helpers;
    using QuestPDF.Infrastructure;
    using ST10187895_PROG6212_PART1.Models;
    using System.Security.Claims;

    public class InvoiceCreator
    {
        public byte[] GenerateInvoice(ReviewClaimsModel claim)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text("Invoice")
                        .FontSize(20)
                        .SemiBold()
                        .AlignCenter();

                    page.Content()
                        .Column(column =>
                        {
                            // Claim details
                            column.Item().Text($"Claim ID: {claim.claimID}");
                            column.Item().Text($"Contractor ID: {claim.contractorID}");
                            column.Item().Text($"Hours Worked: {claim.hoursWorked}");
                            column.Item().Text($"Hourly Rate: R{claim.hourlyRate:F2}");

                            // Total calculation
                            column.Item().PaddingTop(10).Text($"Total Amount: R{claim.totalAmount:F2}")
                                .FontSize(16)
                                .Bold();

                            // Notes
                            column.Item().PaddingTop(10).Text($"Notes: {claim.notes ?? "N/A"}");
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text("Generated by CCONTRACTOR MONTHLY CLAIMS SYSTEM")
                        .FontSize(10);
                });
            }).GeneratePdf();
        }
    }

}
