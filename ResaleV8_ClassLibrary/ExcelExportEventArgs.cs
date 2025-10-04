using ResaleV8_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary
{
    public class ExcelExportEventArgs : EventArgs
    {
        public List<ItemModel>? Items { get; set; }
    }
}
