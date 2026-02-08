using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary.Models
{
    public class SellThruModel
    {
        public string Brand { get; set; }
        public int TotalItems { get; set; }
        public int TotalSold { get; set; }
        public Single SellThruPct { get; set; }
        public decimal ProfitPct { get; set; }
        public decimal FinancialPosition { get; set; }
    }
}