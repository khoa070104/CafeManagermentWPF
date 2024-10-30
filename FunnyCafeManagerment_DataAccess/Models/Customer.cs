using System;

namespace FunnyCafeManagerment_DataAccess.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? Spending { get; set; }
        public string? Notes { get; set; }
    }
} 