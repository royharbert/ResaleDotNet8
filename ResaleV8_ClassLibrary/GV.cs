using ResaleV8;
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
        public static DataMode dbMode { get; set; } = DataMode.LiveDB;
        public static DateTime emptyDate { get; set; } = new DateTime(1900, 1, 1);
        public static List<GenericModel>? Categories { get; set; } = new List<GenericModel>();
        public static List<GenericModel>? StorageLocations { get; set; } = new List<GenericModel>();
        public static List<GenericModel>? PurchaseSources { get; set; } = new List<GenericModel>();
        public static List<GenericModel>? Brands { get; set; } = new List<GenericModel>();
        public static List<ItemModel>? ItemList { get; set; } = new List<ItemModel>();
        public static BusinessSummary? BusinessSummary { get; set; } = new BusinessSummary();
        public static string[] DGVHeaders = new string[] { "ID", "Category", "Item Description", "Brand", "Purchase Source", "Quantity", "Purchase Date",
                "Purchase Price", "Where Listed", "Lister SKU", "Date Listed", "List Price", "Sale Date", "Sale Price", "Cost of Sale",
                "Discount Pct", "Days Held", "Profit", "Storage Location" };
        public static Mode MODE
        {
            get
            {
                return mode;
            }
            set
            {
                if (mode != PreviousMode)
                {
                    PreviousMode = mode;
                }
                mode = value;
            }
        }
        public static Mode PreviousMode { get; set; }
        public static List<GenericModel> WhereListed { get; set; } = new List<GenericModel>();
        

        public static Mode mode = Mode.None;

    }

        
}

