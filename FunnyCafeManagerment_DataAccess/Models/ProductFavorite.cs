using System;

namespace FunnyCafeManagerment_DataAccess.Models
{
    public class ProductFavorite
    {
        public int ProductFavoriteID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Revenue { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 