using System;
using System.Collections.Generic;

namespace FunnyCafeManagerment_DataAccess.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int? StockQuantity { get; set; }

    public DateTime? LastRestocked { get; set; }

    public virtual Product? Product { get; set; }
}
