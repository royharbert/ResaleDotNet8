using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary
{
    public class BusinessSummary
    {
        public decimal TotalSales { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalMargin { get; set; }
        public decimal MarginPercentage { get; set; }
        public decimal UnsoldCost { get; set; }
        public decimal AvgUnsoldAge { get; set; }
        public decimal UnsoldItemsCount { get; set; }
    }
}
