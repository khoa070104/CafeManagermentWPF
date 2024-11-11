using System;
using System.Collections.Generic;

namespace FunnyCafeManagerment_DataAccess.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductImage { get; set; }

    public decimal? Price { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ProductFavorite> ProductFavorites { get; set; } = new List<ProductFavorite>();
}
