using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleV8
{  
    public enum Mode
    {
        Add,
        Retrieve,
        Edit,
        EditCategories,
        EditPurchaseSources,
        EditBrands,
        EditStorageLocations,
        EditWhereListed,
        Delete,
        Search,
        SellThru,
        None
    }

    public enum ExportType
    {
        SearchResults,
        Sold,
        Unsold
    }
}

