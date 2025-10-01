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
        DateTime _purchaseDate;
        float _salePrice = 0.0f;
        float _profit = 0.0f;

        public  int ItemID{ get;}
        public string Category { get; set; }
        public string ItemDesc { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime PurchaseDate
        {
            get
            {
                return _purchaseDate;
            }

            set
            {
                _purchaseDate = value;
                _daysHeld = (DateTime.Now - _purchaseDate).Days;
            }
        }
        public float PurchasePrice { get; set; }
        public DateTime SaleDate
        {
            get
            {
                return _saleDate;
            }
            set
            {
                _saleDate = value;
            }
        }
        public float SalePrice
        {
            get
            {
                return _salePrice;
            }
            set
            {
                _salePrice = value;
                _profit = _salePrice - PurchasePrice;
            }
        }
        public string StorageLocation { get; set; } = null!;
    }
}
