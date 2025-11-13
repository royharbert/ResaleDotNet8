using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary.Models
{
    public class BrandModel
    {
        private string _data;

        public GenericModel Data { get; set; }
        public int ID { get; set; }
        public string Brand
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}
