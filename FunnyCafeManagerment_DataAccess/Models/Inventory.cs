using System;
using System.Collections.Generic;

namespace FunnyCafeManagerment_DataAccess.Models;

public partial class Inventory
{
    public string InventoryId { get; set; } = null!;

    public string? ProductId { get; set; }

    public int? StockQuantity { get; set; }

    public DateOnly? LastRestocked { get; set; }

    public virtual Product? Product { get; set; }
}
