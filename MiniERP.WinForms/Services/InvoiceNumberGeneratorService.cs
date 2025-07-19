using System;

namespace MiniERP.WinForms.Services
{
    public class InvoiceNumberGeneratorService
    {
        /// <summary>
        /// Satış faturası için otomatik fatura numarası oluşturur
        /// Format: SF-YYYYMMDD-HHMMSS-MMM
        /// </summary>
        public string GenerateSalesInvoiceNumber()
        {
            var now = DateTime.Now;
            var milliseconds = now.Millisecond.ToString("000");
            return $"SF-{now:yyyyMMdd}-{now:HHmmss}-{milliseconds}";
        }

        /// <summary>
        /// Alış faturası için otomatik fatura numarası oluşturur
        /// Format: AF-YYYYMMDD-HHMMSS-MMM
        /// </summary>
        public string GeneratePurchaseInvoiceNumber()
        {
            var now = DateTime.Now;
            var milliseconds = now.Millisecond.ToString("000");
            return $"AF-{now:yyyyMMdd}-{now:HHmmss}-{milliseconds}";
        }

        /// <summary>
        /// Belirtilen prefix ile özel fatura numarası oluşturur
        /// </summary>
        public string GenerateCustomInvoiceNumber(string prefix = "INV")
        {
            var now = DateTime.Now;
            var milliseconds = now.Millisecond.ToString("000");
            return $"{prefix}-{now:yyyyMMdd}-{now:HHmmss}-{milliseconds}";
        }

        /// <summary>
        /// GUID bazlı tamamen benzersiz fatura numarası oluşturur
        /// Format: SF-YYYYMMDD-GUID
        /// </summary>
        public string GenerateGuidBasedSalesInvoiceNumber()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid().ToString("N")[..8].ToUpper(); // İlk 8 karakter
            return $"SF-{now:yyyyMMdd}-{guid}";
        }

        /// <summary>
        /// GUID bazlı tamamen benzersiz alış fatura numarası oluşturur
        /// Format: AF-YYYYMMDD-GUID
        /// </summary>
        public string GenerateGuidBasedPurchaseInvoiceNumber()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid().ToString("N")[..8].ToUpper(); // İlk 8 karakter
            return $"AF-{now:yyyyMMdd}-{guid}";
        }

        /// <summary>
        /// Saniye bazında benzersizlik sağlayan fatura numarası oluşturur
        /// </summary>
        public string GenerateTimestampBasedInvoiceNumber(string prefix)
        {
            var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            return $"{prefix}-{timestamp}";
        }
    }
}
