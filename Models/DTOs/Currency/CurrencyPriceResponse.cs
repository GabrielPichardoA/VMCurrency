using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Currency
{
    public class CurrencyPriceResponse
    {
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public string? UpdatedDate { get; set; }
        public string CurrencyCode { get; set; }
    }
}
