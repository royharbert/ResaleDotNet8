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
        public static DateTime emptyDate { get; set; } = new DateTime(1900, 1, 1);
        public static List<string>? categories { get; set; } = new List<string>();
        public static List<string>? storageLocations { get; set; } = new List<string>();
        public static List<string> PurchaseSources { get; set; } = new List<string>();
        public static List<string> Brands { get; set; } = new List<string>();
        public static List<ItemModel>? itemList { get; set; } = new List<ItemModel>();
        public static BusinessSummary? businessSummary { get; set; } = new BusinessSummary();
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
        public static List<string> WhereListed { get; set; } = new List<string>();
        

        public static Mode mode = Mode.None;

    }

        
}

