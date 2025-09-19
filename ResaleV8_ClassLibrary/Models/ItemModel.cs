using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8_ClassLibrary.Models
{
    public class ItemModel
    {
        int _daysHeld = 0;
        DateTime _saleDate = new DateTime(1900,01,01);
        float _salePrice = 0.0f;
        float _profit = 0.0f;

        public  int Item_ID { get;}
        public string Item_Desc { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime Purchase_Date { get; set; }
        public float Purchase_Price { get; set; }
        public DateTime Sale_Date
        {
            get
            {
                return _saleDate;
            }
            set
            {
                _saleDate = value;
                _daysHeld = (Sale_Date - Purchase_Date).Days;
                if  (_daysHeld < 0)
                    _daysHeld = 0;
            }
        }
        public float Sale_Price
        {
            get
            {
                return _salePrice;
            }
            set
            {
                _salePrice = value;
                _profit = _salePrice - Purchase_Price;
            }
        }
        public string storage_location { get; set; } = null!;
        public int Product_Age
        {
            get
            {
                return _daysHeld; 
            }
        }
        public float Profit
        {
            get
            {
                return _profit;
            }
        }
    }
}
