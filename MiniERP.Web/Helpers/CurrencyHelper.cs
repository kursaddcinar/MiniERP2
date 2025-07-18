using System.Globalization;

namespace MiniERP.Web.Helpers
{
    public static class CurrencyHelper
    {
        /// <summary>
        /// Decimal değeri Türk Lirası formatında string'e çevirir
        /// </summary>
        /// <param name="amount">Formatlanacak miktar</param>
        /// <returns>Formatlanmış para birimi string'i</returns>
        public static string FormatCurrency(decimal amount)
        {
            if (amount == 0)
                return "0,00 ₺";
            
            return amount.ToString("N2", CultureInfo.GetCultureInfo("tr-TR")) + " ₺";
        }
        
        /// <summary>
        /// Razor View'larda kullanım için extension method
        /// </summary>
        /// <param name="amount">Formatlanacak miktar</param>
        /// <returns>Formatlanmış para birimi string'i</returns>
        public static string ToCurrency(this decimal amount)
        {
            return FormatCurrency(amount);
        }
        
        /// <summary>
        /// Nullable decimal için extension method
        /// </summary>
        /// <param name="amount">Formatlanacak miktar</param>
        /// <returns>Formatlanmış para birimi string'i</returns>
        public static string ToCurrency(this decimal? amount)
        {
            return FormatCurrency(amount ?? 0);
        }
    }
}
