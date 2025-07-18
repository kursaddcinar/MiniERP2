using System;
using System.Globalization;

namespace MiniERP.WinForms.Helpers
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
        /// DataGridView hücreleri için para birimi formatı
        /// </summary>
        /// <returns>DataGridView için format string'i</returns>
        public static string GetDataGridViewCurrencyFormat()
        {
            return "N2";
        }
    }
}


