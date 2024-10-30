using System;

namespace FunnyCafeManagerment_DataAccess.Models
{
    public class Revenue
    {
        public int RevenueId { get; set; }
        public DateTime RevenueDate { get; set; }
        public decimal? TotalRevenue { get; set; }
    }
} 