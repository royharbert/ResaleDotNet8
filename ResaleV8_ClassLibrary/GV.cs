using ResaleV8_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary
{
    public class GV
    {
        public static string conString { get; set; } = null!;
        public static DateTime emptyDate { get; set; } = new DateTime(1900, 1, 1);
        public static List<string>? categories { get; set; }
        public static List<string>? storageLocations { get; set; }
        public static List<ItemModel>? itemList { get; set; }
        public static BusinessSummary businessSummary { get; set; }
    }

        
}

