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
        DateTime _saleDate = new DateTime(1900, 01, 01);
        DateTime _purchaseDate;
        decimal _salePrice = 0.0M;
        decimal _profit = 0.0M;
        decimal _CostOfSale = 0.0M;

        public int ItemID { get; set; }
        public string? Category { get; set; }
        public string ItemDesc { get; set; } = null!;
        public string? Brand { get; set; }
        public string? PurchaseSource { get; set; }
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
        public decimal PurchasePrice { get; set; }
        public string? WhereListed { get; set; }
        public DateTime DateListed { get; set; } = GV.emptyDate;
        public decimal ListPrice { get; set; }
        public DateTime SaleDate
        {
            get
            {
                return _saleDate;
            }
            set
            {
                _saleDate = value;
                _daysHeld = (_saleDate - _purchaseDate).Days;
            }
        }
        public decimal SalePrice
        {
            get
            {
                return _salePrice;
            }
            set
            {
                _salePrice = value;
               CalculateProfit(_salePrice, PurchasePrice, CostOfSale);
            }
        }

        public decimal CostOfSale
        {
            get
            {
                return _CostOfSale;
            }
            set
            {
                _CostOfSale = value;
                CalculateProfit(_salePrice, PurchasePrice, _CostOfSale);
            }
        }

        public int ProductAge
        {
            get
            {
                if (SaleDate == new DateTime(1900, 01, 01))
                {
                    _daysHeld = (DateTime.Now - _purchaseDate).Days;
                }
                else
                {
                    _daysHeld = (SaleDate - _purchaseDate).Days;
                }
                return _daysHeld;
            }
        }

        public decimal Profit
        {
            get
            {
                return _profit;
            }
        }
        public string? StorageLocation { get; set; } = null!;
    

    private decimal CalculateProfit(decimal salePrice, decimal purchasePrice, decimal costOfSale)
        {            
            _profit = salePrice - purchasePrice - costOfSale;
            return _profit;
        }
    }
}
