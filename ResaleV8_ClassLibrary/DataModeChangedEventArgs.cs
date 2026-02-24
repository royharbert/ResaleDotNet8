using ResaleV8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary
{
    public class DataModeChangedEventArgs : EventArgs
    {
        public string conString {  get; set; }
        public DataMode NewDataMode { get; set; }
    }
}
