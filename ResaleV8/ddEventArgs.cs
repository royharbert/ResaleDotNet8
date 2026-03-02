using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8
{
    public class DropDownEventArgs : EventArgs
    {
        public string? originalItem { get; set; }
        public string? escapedItem { get; set; }
        public string? unescapedItem { get; set; }
    }
}
